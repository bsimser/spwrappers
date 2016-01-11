using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Web.Services.Protocols;
using SharePointWrappers.DwsWS;
using SharePointWrappers.SiteDataWS;

namespace SharePointWrappers
{
	/// <summary>
	/// This represents a SharePoint document library. While a document
	/// library is really a specialization of a list, this contains extra
	/// methods like accessing document and folders.
	/// </summary>
	/// <remarks>This class and <see cref="SharePointList"/> need to be reworked as 
	/// Document Libraries should be similar and derive from the same base class.</remarks>
	public class SharePointDocLib : SharePointObject
	{
		private string libName;
		private string libPath;
		private Guid libGuid;

		// Document libraries can contain both folders and documents
		private ArrayList folderList = new ArrayList();
		private ArrayList documents = new ArrayList();

		/// <summary>
		/// Creates a new <see cref="SharePointDocLib"/> instance.
		/// </summary>
		/// <param name="url">Url to the SharePoint site</param>
		/// <param name="name">Name of the document library</param>
		/// <param name="path">Path to the document library (relative to the SharePoint site)</param>
		/// <param name="guid">Guid of the document library</param>
		public SharePointDocLib(string url, string name, string path, Guid guid) : base(url)
		{
			siteUrl = url;
			libName = name;
			libPath = path;
			libGuid = guid;
		}

		#region Accessors
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return libName; }
			set { libName = value; }
		}

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value></value>
		public Guid Id
		{
			get { return libGuid; }
			set { libGuid = value; }
		}

		/// <summary>
		/// Gets the folder list.
		/// </summary>
		/// <value></value>
		public ArrayList FolderList
		{
			get { return folderList; }
		}

		/// <summary>
		/// Gets the documents.
		/// </summary>
		/// <value></value>
		public ArrayList Documents
		{
			get { return documents; }
		}
		#endregion

		/// <summary>
		/// Allows you to add a document to the current document
		/// library folder from a local path. Can be modified or
		/// extended to accept a stream, etc. Uses basic HTTP PUT
		/// to upload the document.
		/// 
		/// If the document library is versioned, uploading a file
		/// with the same name creates a new version.
		/// </summary>
		/// <param name="localFile">the path to the file to upload</param>
		/// <param name="remoteFile">the filename to use on sharepoint</param>
		/// <param name="contentType">the mime type (e.g. "application/octet-stream")</param>
		public SharePointDocument AddDocument(string localFile, string remoteFile, string contentType)
		{
			// Read in the local file
			FileStream fstream = new FileStream(localFile, FileMode.Open, FileAccess.Read);
			byte [] buffer = new byte[fstream.Length];
			fstream.Read(buffer, 0, Convert.ToInt32(fstream.Length));
			fstream.Close();

			return AddDocument(buffer, remoteFile, contentType);
		}

		/// <summary>
		/// Allows you to add a document to the current document
		/// library folder from a byte array. 
		/// 
		/// If the document library is versioned, uploading a file
		/// with the same name creates a new version.
		/// </summary>
		/// <param name="file">the file to upload</param>
		/// <param name="remoteFileName">the filename to use on sharepoint</param>
		/// <param name="contentType">the mime type (e.g. "application/octet-stream")</param>
		public SharePointDocument AddDocument(byte[] file, string remoteFileName, string contentType)
		{
			// Create the web request object
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(siteUrl + "/" + libPath + "/" + remoteFileName);
			request.Credentials = Credentials;
			request.ContentType = contentType;
			request.ContentLength = file.Length;
			request.Method = "PUT";
			
			// Write the local file to the remote system
			Stream reqStream = request.GetRequestStream();
			reqStream.Write(file, 0, file.Length);
			reqStream.Close();

			// Get a response back from the website
			HttpWebResponse	response = (HttpWebResponse)request.GetResponse();
			response.Close();

			SharePointDocument spDoc = new SharePointDocument(siteUrl, libPath, remoteFileName);
			spDoc.Credentials = Credentials;

			// Add the newly uploaded document to our collection
			documents.Add(spDoc);

			return spDoc;
		}

		/// <summary>
		/// Enumerates the content of the document library (via the
		/// SiteData web service) and loads up anything it finds that's
		/// a document.
		/// </summary>
		public void LoadDocuments()
		{
			SiteData dws = NewSiteDataWebService();
			try
			{
				_sFPUrl[] enArray = null;
				string path = siteUrl+"/"+libPath;
				dws.EnumerateFolder(path, out enArray);
				foreach(_sFPUrl item in enArray)
				{
					if(!item.IsFolder)
					{
						int lastSlashPos = item.Url.LastIndexOf("/");
						string filename = item.Url.Substring(lastSlashPos+1);
						documents.Add(new SharePointDocument(siteUrl, this.Name, filename));
					}
				}
			}
			catch (NullReferenceException nullEx)
			{
				// handles empty folders
				Console.WriteLine(nullEx.Message);
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Loads the folders.
		/// </summary>
		public void LoadFolders()
		{
			SiteData dws = NewSiteDataWebService();
			try
			{
				_sFPUrl[] enArray = null;
				dws.EnumerateFolder(siteUrl+"/"+libPath, out enArray);
				foreach(_sFPUrl folder in enArray)
				{
					if(folder.IsFolder)
					{
						SharePointDocLibFolder spFold = new SharePointDocLibFolder(siteUrl, folder.Url);
						spFold.Credentials = Credentials;
						folderList.Add(spFold);
					}
				}
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Creates a new folder under the current folder structure
		/// using the Document Workspace Web Service.
		/// </summary>
		/// <param name="folderName"></param>
		public SharePointDocLibFolder CreateFolder(string folderName)
		{
			SharePointDocLibFolder newFolder = null;
			Dws dws = NewDwsWebService();
			try
			{
				string newFolderName = libPath + "/" + folderName;
				string strResult = dws.CreateFolder(newFolderName);
				if(IsDwsErrorResult(strResult))
				{
					// Simple solution just to write out
					// the message to the console. You may
					// want to parse this and act accordingly
					Console.WriteLine(strResult);
				}
				else
				{
					newFolder = new SharePointDocLibFolder(siteUrl, newFolderName);
					newFolder.Credentials = Credentials;
					folderList.Add(newFolder);
					return newFolder;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return newFolder;
		}
	}
}
