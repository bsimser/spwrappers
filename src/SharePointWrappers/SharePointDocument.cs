using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using SharePointWrappers.ListsWS;
using SharePointWrappers.VersionsWS;

namespace SharePointWrappers
{
	/// <summary>
	/// Summary description for SharepointDocument.
	/// </summary>
	public class SharePointDocument : SharePointObject
	{
		private string folderUrl;
		private string fileName;
		private string fullNameWithPath;
		private long sharepointVersion = -1; // starts out at -1, changes when sharepoint is queried
		private long sharepointId = -1; // starts out at -1, changes when sharepoint is queried

		private ArrayList versions = new ArrayList();

		/// <summary>
		/// Creates a new <see cref="SharePointDocument"/> instance.
		/// </summary>
		/// <param name="siteUrl">Site URL.</param>
		/// <param name="folder">Folder.</param>
		/// <param name="fileName">Name of the file.</param>
		public SharePointDocument(string siteUrl, string folder, string fileName) : base(siteUrl)
		{
			this.siteUrl = siteUrl;
			this.folderUrl = folder;
			this.fileName = fileName;

			this.fullNameWithPath = String.Concat(siteUrl, "/", folderUrl, "/", fileName);
		}

		/// <summary>
		/// This loads up all version information for a document (using the Versions web
		/// service) and stores it in a collection of <see cref="SharePointDocumentVersion"/>
		/// objects. Even if versioning isn't turned on in a document library, there's 
		/// always version 1.
		/// </summary>
		public void LoadVersions()
		{
			Versions ws = NewVersionsWebService();
			try
			{
				XmlNode node = ws.GetVersions(fullNameWithPath);
				foreach (XmlNode ver in node)
				{
					if(ver.Name == "result")
					{
						SharePointDocumentVersion version = new SharePointDocumentVersion(siteUrl);
						version.Version = ver.Attributes["version"].Value;
						version.CreatedBy = ver.Attributes["createdBy"].Value;
						version.Size = Convert.ToInt32(ver.Attributes["size"].Value);
						version.VersionUrl = ver.Attributes["url"].Value;
						version.Comments = ver.Attributes["comments"].Value;
						versions.Add(version);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		/// <summary>
		/// Updates the metadata of this document
		/// </summary>
		/// <param name="metadata">Collection of Metadata key-value pairs to set for this document.
		/// To set the Title of the document to MyNewTitle.doc, the hashtable would contain an 
		/// entry with the key of "Title" and the value of "MyNewTitle.doc"</param>
		/// <returns>True on success, false on failure</returns>
		public bool SetMetadata(Hashtable metadata)
		{
			// create update batch
			XmlDocument xd = new XmlDocument();
			XmlNode batch = xd.CreateElement("Batch");
			batch.InnerXml = CreateBatch(metadata);

			Lists lws = NewListsWebService();
			try 
			{
				string listName = folderUrl.Split('/')[0];
				XmlNode result = lws.UpdateListItems(listName, batch);
			
				// check result code
				string errCode = result.SelectSingleNode("./*/*").InnerText;
				if ("0x00000000" != errCode)
					return false;

				// success! grab new version
				sharepointVersion = long.Parse(result.SelectSingleNode("./*/@Version").Value);
				return true;
			} 
			catch (Exception e)
			{
				// probably some stupid SoapException
				Console.WriteLine("Exception Occurred trying to set metadata:");
				Console.WriteLine(e.Message);
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="SharePointDocument"/> is exists.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if exists; otherwise, <c>false</c>.
		/// </value>
		public bool Exists
		{
			get
			{
				try 
				{
					HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Format("{0}/{1}/{2}", siteUrl, folderUrl, fileName));
					request.Credentials = Credentials;
					request.Method = "HEAD";
					HttpWebResponse response = (HttpWebResponse) request.GetResponse();
					return (HttpStatusCode.NotFound != response.StatusCode);
				}
				catch (Exception e)
				{ 
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}


		#region Accessors
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return fileName; }
		}

		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <value></value>
		public long Version
		{
			get 
			{ 
				if (sharepointVersion < 0)
					GetVersionAndID();
				return sharepointVersion; 
			}
		}

		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value></value>
		public long ID
		{
			get 
			{ 
				if (sharepointId < 0)
					GetVersionAndID();
				return sharepointId; 
			}
		}

		/// <summary>
		/// Gets the versions.
		/// </summary>
		/// <value></value>
		public ArrayList Versions
		{
			get { return versions; }
		}

		#endregion

		#region Constants
		
		private const string GET_DOCID_QUERYOPTIONS = "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns><ViewAttributes Scope=\"Recursive\" />";
		private const string GET_DOCID_QUERY_FMT = "<Where><Eq><FieldRef Name=\"FileRef\" /><Value Type=\"Text\">{0}</Value></Eq></Where>";
		
		#endregion

		#region Private Helper Functions

		/// <summary>
		/// Gets the sharepoint version and ID for this document.
		/// </summary>
		private void GetVersionAndID()
		{
			// construct query
			XmlDocument xd = new XmlDocument();
			XmlNode query = xd.CreateElement("Query");
			string filePath = String.Format("{0}/{1}/{2}", Regex.Replace(siteUrl, "http://.*?/", ""), folderUrl, fileName);
			string listName = folderUrl.Split('/')[0];
			query.InnerXml = string.Format(GET_DOCID_QUERY_FMT, filePath);
			XmlNode queryOpts = xd.CreateElement("QueryOptions");
			queryOpts.InnerXml = GET_DOCID_QUERYOPTIONS;

			// send query via web service call
			Lists lws = NewListsWebService();
			try 
			{
				XmlNode result = lws.GetListItems(listName, null, query, null, null, queryOpts);
				long itemCount = long.Parse(result.SelectSingleNode("./*/@ItemCount").Value);

				if (1 == itemCount)
				{
					sharepointId = long.Parse(result.SelectSingleNode("./*/*/@ows_ID").Value);
					sharepointVersion = long.Parse(result.SelectSingleNode("./*/*/@ows_owshiddenversion").Value);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		/// <summary>
		/// Creates a batch method for doing metadata updates on a document.
		/// </summary>
		/// <param name="metadata">the metadate to update, as a collection of Key->Value pairs</param>
		/// <returns>the XML String for a batch method, suitable to use as InnerXml of the Batch element.</returns>
		private string CreateBatch(Hashtable metadata)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("<Method ID=\"1\" Cmd=\"Update\"><Field Name=\"ID\">{0}</Field><Field Name=\"owshiddenversion\">{1}</Field><Field Name=\"FileRef\">{2}/{3}/{4}</Field>", ID, Version, siteUrl, folderUrl, fileName);
			foreach (string key in metadata.Keys)
			{
				sb.AppendFormat("<Field Name=\"{0}\">{1}</Field>", key, SanitizeXML(metadata[key].ToString()));
			}
			sb.Append("</Method>");
			return sb.ToString();
		}

		private string SanitizeXML(string s)
		{
			return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
		}

		#endregion

	}
}
