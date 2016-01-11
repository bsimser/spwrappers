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
	/// This class represents a document library folder
	/// in a SharePoint doclib
	/// </summary>
	public class SharePointDocLibFolder : SharePointObject
	{
		private string folderUrl;
		private ArrayList subFolders = new ArrayList();
		private ArrayList documents = new ArrayList();

		/// <summary>
		/// Creates a new <see cref="SharePointDocLibFolder"/> instance.
		/// </summary>
		/// <param name="url">Url.</param>
		/// <param name="folder">Folder.</param>
		public SharePointDocLibFolder(string url, string folder) : base(url)
		{
			siteUrl = url;
			folderUrl = folder;
		}

		#region Accessors
		
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return folderUrl; }
		}

		/// <summary>
		/// Gets the sub folders.
		/// </summary>
		/// <value></value>
		public ArrayList SubFolders
		{
			get { return subFolders; }
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
		/// Allows you to add a new document to the current document
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
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(siteUrl + "/" + folderUrl + "/" + remoteFileName);
			request.Credentials = Credentials;
			request.ContentType = contentType;
			request.ContentLength = file.Length;
			request.Method = "PUT";
			
			// Write the local file to the remote system
			Stream reqStream = request.GetRequestStream();
			reqStream.Write(file, 0, file.Length);
			reqStream.Close();

			// Get a web response back
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			response.Close();
			SharePointDocument spDoc = new SharePointDocument(siteUrl, folderUrl, remoteFileName);
			spDoc.Credentials = Credentials;
			return spDoc;
		}

		/// <summary>
		/// Iterate through and load all items in a folder
		/// as new <see cref="SharePointDocument"/> objects.
		/// </summary>
		public void LoadDocuments()
		{
			SiteData dws = NewSiteDataWebService();
			try
			{
				_sFPUrl[] enArray = null;
				string path = siteUrl+"/"+folderUrl;
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
		/// Load on demand the sub folders for a WSS Document Library
		/// </summary>
		public void LoadSubFolders()
		{
			SiteData dws = NewSiteDataWebService();
			try
			{
				_sFPUrl[] enArray = null;
				string path = siteUrl+"/"+folderUrl;
				dws.EnumerateFolder(path, out enArray);
				foreach(_sFPUrl folder in enArray)
				{
					if(folder.IsFolder)
						subFolders.Add(new SharePointDocLibFolder(siteUrl, folder.Url));
					//EnumerateFolder(dws, siteUrl+"/"+folder.Url);
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
				string newFolderName = folderUrl + "/" + folderName;
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
					subFolders.Add(newFolder);
					return newFolder;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return newFolder;
		}

		/// <summary>
		/// Deletes this folder from SharePoint using the dws web service.
		/// </summary>
		public void Delete()
		{
			Dws dws = NewDwsWebService();
			try
			{
				dws.DeleteFolder(folderUrl);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Recursively process a folder url and all subfolders,
		/// creating new SharePointDocLibFolder objects on the fly
		/// and adding them to the list of subfolders in this class.
		/// This creates a heiarchy of folders we can recurse through
		/// in the gui or for processing.
		/// </summary>
		/// <param name="dws">The SiteData Web Service</param>
		/// <param name="folderUrl">A url to the folder you want to enumerate</param>
		/// <remarks>This is a private method and not currently used
		/// but might want to be refactored to be public.</remarks>
		private void EnumerateFolder(SiteData dws, string folderUrl)
		{
			_sFPUrl[] enArray = null;

			try
			{
				dws.EnumerateFolder(folderUrl, out enArray);
				foreach(_sFPUrl folder in enArray)
				{
					if(folder.IsFolder)
						subFolders.Add(new SharePointDocLibFolder(siteUrl, folder.Url));
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
	}
}
