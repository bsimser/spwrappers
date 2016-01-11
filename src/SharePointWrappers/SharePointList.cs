using System;
using System.Collections;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace SharePointWrappers
{
	/// <summary>
	/// Summary description for SharePointList.
	/// </summary>
	/// <remarks>This class and <see cref="SharePointDocLib"/> need to be reworked as 
	/// Document Libraries should be similar and derive from the same base class.</remarks>
	public class SharePointList: SharePointObject
	{
		private string listName;
		private string listPath;
		private Guid listGuid;
		private string version;
		private ArrayList fields = new ArrayList();

		#region Accessors

		/// <summary>
		/// Gets the fields.
		/// </summary>
		/// <value></value>
		public ArrayList Fields
		{
			get { return fields; }
		}

		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		/// <value></value>
		public string Version
		{
			get { return version; }
			set { version = value; }
		}

		/// <summary>
		/// Gets the site u r l.
		/// </summary>
		/// <value></value>
		public string SiteURL
		{
			get { return siteUrl; }
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return listName; }
		}

		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value></value>
		public string Path
		{
			get { return listPath; }
		}

		#endregion

		/// <summary>
		/// Creates a new <see cref="SharePointList"/> instance.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <param name="name">Name.</param>
		/// <param name="path">Path.</param>
		/// <param name="guid">Guid.</param>
		public SharePointList(string url, string name, string path, Guid guid) : base(url)
		{
			siteUrl = url;
			listName = name;
			listPath = path;
			listGuid = guid;
		}

		/// <summary>
		/// Updates the properties.
		/// </summary>
		public void UpdateProperties()
		{
			XmlDocument xmlDoc = new System.Xml.XmlDocument();

			XmlNode ndDeleteFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndProperties = xmlDoc.CreateNode(XmlNodeType.Element, "List", "");
			XmlAttribute ndTitleAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Title", "");
			XmlAttribute ndDescriptionAttrib = (XmlAttribute)xmlDoc.CreateNode(XmlNodeType.Attribute, "Description", "");
			XmlNode ndNewFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");
			XmlNode ndUpdateFields = xmlDoc.CreateNode(XmlNodeType.Element, "Fields", "");

			ndTitleAttrib.Value = listName;

			ndProperties.Attributes.Append(ndTitleAttrib);
			ndProperties.Attributes.Append(ndDescriptionAttrib);

			StringBuilder sb = new StringBuilder();
			foreach(SharePointListProperty field in fields)
			{
				sb.Append("<Method ID='" + fields.IndexOf(field) + "'>");

				if (null != field.Properties)
				{
					sb.Append("<Field");
					foreach (string key in field.Properties.Keys)
					{
						sb.Append(" " + key.ToString() + "='" + field.Properties[key] + "'");
					}
					sb.Append("></Field>");
				}

				sb.Append("</Method>");
			}
			
			ndNewFields.InnerXml = sb.ToString();

			try
			{
				ListsWS.Lists lws = NewListsWebService();
				lws.UpdateList(listGuid.ToString(), ndProperties, ndNewFields, null, null, version);
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
				Console.WriteLine(ex.Detail.ToString());
			}		
		}

		/// <summary>
		/// Creates the item.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <returns></returns>
		public SharePointListItem CreateItem(string title)
		{
			return CreateItem(title, null);
		}

		/// <summary>
		/// Creates the item.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="fieldValues">Field values.</param>
		/// <returns></returns>
		public SharePointListItem CreateItem(string title, Hashtable fieldValues)
		{
			// construct batch
			XmlDocument doc = new XmlDocument();
			XmlElement xmlBatch = doc.CreateElement("Batch");
			
			xmlBatch.SetAttribute("OnError", "Continue");
			xmlBatch.SetAttribute("ListVersion", version);

			StringBuilder sb = new StringBuilder();
			sb.Append("<Method ID='1' Cmd='New'><Field Name='ID'>New</Field>");
			sb.AppendFormat("<Field Name='Title'>{0}</Field>", title);
			if (null != fieldValues)
			{
				foreach (string key in fieldValues.Keys)
				{
					// Determine the type of the value being set
					// and optionally add the appropriate XML
					string fieldEntry = "";
					
					// TODO: maybe override hashtable to get key, value pair?
					// Add any new types you want to support here. There must be a 
					// better way to do this!
					if(fieldValues[key] is DateTime)
					{
						// Have to format DateTime into ISO8601 format
						// (yyyy-mm-ddThh:mm:ssZ)
						DateTime dtUTC = (DateTime)fieldValues[key];
						string dateTimeUTC = dtUTC.ToString("yyyy-MM-ddTHH:mm:ssZ");
						fieldEntry = String.Format("<Field Name='{0}'>{1}</Field>", key, dateTimeUTC);
					}
					else
					{
						// default to string with no type
						fieldEntry = String.Format("<Field Name='{0}'>{1}</Field>", key, fieldValues[key]);
					}

					sb.Append(fieldEntry);
				}
			}
			sb.Append("</Method>");
			xmlBatch.InnerXml = sb.ToString();

			// submit batch update
			ListsWS.Lists lws = NewListsWebService();
			XmlNode result = lws.UpdateListItems(listName, xmlBatch);

			// check result return value
			// Correct way to do this is probably using XPath, but doing things
			// like result.SelectSingleNode("Result/ErrorCode") barf, with
			// or without an XmlNamespaceManager.  If you can figure it out
			// feel free to change it.
			
			string resultCode = result.SelectSingleNode("*/*").InnerText.ToString();
			if ("0x00000000" != resultCode)
				return null;

			// OK.  Construct new listitem
			long id = long.Parse(Regex.Match(result.InnerXml, "ows_ID=\"(.*?)\"").Groups[1].Value);
			Guid guid = new Guid(Regex.Match(result.InnerXml, "ows_GUID=\"(.*?)\"").Groups[1].Value);
			SharePointListItem item = new SharePointListItem(this, id, guid);
			item.Credentials = Credentials;
			return item;
		}
	}
}
