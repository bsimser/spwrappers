using System;
using System.Collections;
using System.Net;
using System.Web.Services.Protocols;
using System.Xml;
using SharePointWrappers.ListsWS;
using SharePointWrappers.ViewWS;
using SharePointWrappers.WebPartPagesWS;
using SharePointWrappers.WebsWS;

namespace SharePointWrappers
{
	/// <summary>
	/// This class represents a SharePoint 2003 site
	/// and contains the collection of any subsites it owns.
	/// </summary>
	public class SharePointSite : SharePointObject
	{
		private string siteName;
		private ArrayList subSites = new ArrayList();
		private ArrayList docLibs = new ArrayList();
		private ArrayList lists = new ArrayList();

		/// <summary>
		/// Creates a new <see cref="SharePointSite"/> instance.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="url">Url.</param>
		public SharePointSite(string name, string url) : base(url)
		{
			siteName = name;
			siteUrl = url;
		}

		#region Accessors
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return siteName; }
		}

		/// <summary>
		/// Gets the sub sites.
		/// </summary>
		/// <value></value>
		public ArrayList SubSites
		{
			get { return subSites; }
		}

		/// <summary>
		/// Gets the doc libs.
		/// </summary>
		/// <value></value>
		public ArrayList DocLibs
		{
			get { return docLibs; }
		}

		/// <summary>
		/// Gets the lists.
		/// </summary>
		/// <value></value>
		public ArrayList Lists
		{
			get { return lists; }
		}

		#endregion

		/// <summary>
		/// Loads up the collection for document libraries and lists
		/// in a site and creates objects to represent each library and list
		/// so we can refer to them later without having
		/// to call additional web services.
		/// </summary>
		public void LoadDocumentLibraries()
		{
			Lists ws = NewListsWebService();
			try
			{
				XmlNode listNodes = ws.GetListCollection();
				foreach(XmlNode list in listNodes)
				{
					string serverTemplate = list.Attributes["ServerTemplate"].Value;
					if(serverTemplate == "101")
					{
						string url = list.Attributes["DefaultViewUrl"].Value;
						string path = "/";

						if(url != "")
						{
							string delimStr = "/";
							char[] delimiter = delimStr.ToCharArray();
							string[] arr = url.Split(delimiter);
							path = arr[arr.Length - 3];
						}

						string name = list.Attributes["Title"].Value;
						string guid = list.Attributes["ID"].Value;

						SharePointDocLib docLib = new SharePointDocLib(siteUrl, name, path, new Guid(guid));
						docLib.Credentials = Credentials;
						
						docLibs.Add(docLib);
					}
				}
			}
			catch (WebException wex)
			{
				Console.WriteLine(wex.Message);
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Detail.ToString());
			}
		}

		/// <summary>
		/// Loads up the collection for document libraries and lists
		/// in a site and creates objects to represent each library and list
		/// so we can refer to them later without having
		/// to call additional web services.
		/// </summary>
		public void LoadLists()
		{
			Lists ws = NewListsWebService();
			try
			{
				XmlNode listNodes = ws.GetListCollection();
				foreach(XmlNode list in listNodes)
				{
					string serverTemplate = list.Attributes["ServerTemplate"].Value;
					if(serverTemplate != "101")
					{
						string url = list.Attributes["DefaultViewUrl"].Value;
						string path = "/";

						if(url != "")
						{
							string delimStr = "/";
							char[] delimiter = delimStr.ToCharArray();
							string[] arr = url.Split(delimiter);
							path = arr[arr.Length - 3];
						}

						string name = list.Attributes["Title"].Value;
						string guid = list.Attributes["ID"].Value;

						SharePointList subList = new SharePointList(siteUrl, name, path, new Guid(guid));
						subList.Credentials = Credentials;

						lists.Add(subList);
					}
				}
			}
			catch (WebException wex)
			{
				Console.WriteLine(wex.Message);
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Detail.ToString());
			}
		}

		/// <summary>
		/// Adds a web part from XML to the current site. This
		/// dynamically configures the webs web service based
		/// on the site url and hides any web services we call 
		/// from the client.
		/// </summary>
		/// <param name="webPartXml">The XML representation of 
		/// a web part. This can be loaded up from .dwp file from
		/// a client calling it.</param>
		public bool AddWebPart(string webPartXml)
		{
			bool rc = false;
			WebPartPagesWebService ws = NewWebPartPagesWebService();
			string pageUrl = String.Concat(siteUrl, "/default.aspx");
			try
			{
				ws.AddWebPart(pageUrl, webPartXml, Storage.Shared);
				rc = true;
			}
			catch (SoapException sex)
			{
				Console.WriteLine(sex.Message);
			}
			return rc;
		}

		/// <summary>
		/// Delete a web part from a site based on the name.
		/// </summary>
		/// <param name="webPartName"></param>
		/// <returns></returns>
		public bool DeleteWebPart(string webPartName)
		{
			// Have to get all web parts from the page then iterate
			// through them all to find the title that matches. Once
			// we do that we get the Guid and delete it with another service
			bool rc = false;
			WebPartPagesWebService ws = NewWebPartPagesWebService();
			string pageUrl = String.Concat(siteUrl, "/default.aspx");
			try
			{
				XmlNode resultNode = ws.GetWebPartProperties(pageUrl, Storage.Shared);
				foreach(XmlNode node in resultNode)
				{
					string partTitle = node["Title"].InnerText;
					if(partTitle.ToUpper() == webPartName.ToUpper())
					{
						string partId = node.Attributes["ID"].InnerText;
						Guid storageKey = new Guid(partId);
						ws.DeleteWebPart(pageUrl, storageKey, Storage.Shared);
						rc = true;
					}
				}
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return rc;
		}

		/// <summary>
		/// Creates a new list in the current site.
		/// </summary>
		/// <param name="listName">Name of the list</param>
		/// <param name="listDescription">Description for the list</param>
		/// <param name="templateId">Template ID to use when creating the list. 100 is for custom
		/// list. For other types please refer to the SharePoint SDK</param>
		/// <returns>A new <see cref="SharePointList"/> object.</returns>
		public SharePointList CreateList(string listName, string listDescription, int templateId)
		{
			Lists lws = NewListsWebService();
			lws.AddList(listName, listDescription, templateId);
			XmlNode nodeList = lws.GetList(listName);
			Guid listGuid = new Guid(nodeList.Attributes["ID"].Value.ToString());
			
			string version = nodeList.Attributes["Version"].Value.ToString();
			string convertedListName = listName.Replace(" ", "%20");
			string listPath = siteUrl + "/Lists/" + convertedListName;
			
			SharePointList list = new SharePointList(siteUrl, listName, listPath, listGuid);
			list.Version = version;
			return list;
		}

		/// <summary>
		/// Delete a list from a site based on a name.
		/// </summary>
		/// <param name="listName"></param>
		/// <returns></returns>
		public bool DeleteList(string listName)
		{
			bool rc = false;
			Lists ws = NewListsWebService();
			try
			{
				ws.DeleteList(listName);
				rc = true;
			}
			catch (SoapException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return rc;
		}

		/// <summary>
		/// Helper function that gets all the views for a list
		/// and returns the Guid for the view. The Guid is needed
		/// for view functions like deleting the view.
		/// </summary>
		/// <param name="listName"></param>
		/// <param name="viewName"></param>
		/// <returns></returns>
		private string GetViewGuidByName(string listName, string viewName)
		{
			string viewGuid = "";
			Views ws = NewViewsWebService();
			
			try
			{
				XmlNode viewList = ws.GetViewCollection(listName);
				foreach(XmlNode view in viewList)
				{
					string viewTitle = view.Attributes["DisplayName"].Value;
					if(viewTitle.ToUpper() == viewName.ToUpper())
					{
						viewGuid = view.Attributes["Name"].Value;
						break;
					}
				}
			}
			catch (SoapException sex)
			{
				Console.WriteLine(sex.Detail.InnerText);
			}

			return viewGuid;
		}

		/// <summary>
		/// Delete a named view from a given list.
		/// </summary>
		/// <param name="listName">Name of the list to delete. "*" will delete the
		/// specified view from all lists. Handy when you want to delete something like
		/// Explorer view from all Document Libraries.</param>
		/// <param name="viewName">Name of the view to delete.</param>
		/// <returns></returns>
		public bool DeleteView(string listName, string viewName)
		{
			bool rc = false;
			Lists ws = NewListsWebService();
			Views vws = NewViewsWebService();

			// "*" gets the collection of lists from the server then
			// proceeds to delete the view from each list
			if(listName.ToUpper() == "*")
			{
				XmlNode listCollection = ws.GetListCollection();
				foreach(XmlNode list in listCollection)
				{
					listName = list.Attributes["Title"].Value;
					try
					{
						string viewGuid = GetViewGuidByName(listName, viewName);
						if(viewGuid != "")
						{
							vws.DeleteView(listName, viewGuid);
							rc = true;
						}
					}
					catch (SoapException ex)
					{
						Console.WriteLine(ex.Detail.InnerText);
					}
				}
			}
			else
			{
				string viewGuid = GetViewGuidByName(listName, viewName);
				if(viewGuid != "")
				{
					try
					{
						vws.DeleteView(listName, viewGuid);
						rc = true;
					}
					catch (SoapException ex)
					{
						Console.WriteLine(ex.Detail.InnerText);
					}
				}
			}
			return rc;
		}

		/// <summary>
		/// This dynamically creates the loads the webs 
		/// web service and gets the web collection for the 
		/// current site. Once this is done, you can iterate
		/// through the collection and retrieve information
		/// about a single site through the GetWeb service.
		/// </summary>
		/// <remarks>Needs to be redone to get the sites from
		/// something other than the Sites list as this doesn't
		/// guarantee that all sites are registered this way.</remarks>
		public void LoadWebCollection()
		{
			Webs ws = NewWebsWebService();
			try
			{
				XmlNode root = ws.GetWebCollection();
				XmlNodeList siteList = root.SelectNodes("*");
				foreach(XmlNode node in siteList)
				{
					string newSiteName = node.Attributes["Title"].Value;
					string newSiteUrl = node.Attributes["Url"].Value;
					SharePointSite spSite = new SharePointSite(newSiteName, newSiteUrl);
					spSite.Credentials = Credentials;
					subSites.Add(spSite);
				}
			}
			catch (WebException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (SoapException sex)
			{
				Console.WriteLine(sex.Message);
			}
		}
	}
}
