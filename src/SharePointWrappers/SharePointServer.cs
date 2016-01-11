using System;
using System.Collections;
using System.Web.Services.Protocols;
using System.Xml;
using SharePointWrappers.ListsWS;
using SharePointWrappers.SiteDataWS;
using SharePointWrappers.WebsWS;

namespace SharePointWrappers
{
	/// <summary>
	/// This class represents an entire SharePoint server
	/// and is the starting point for accessing sites, subsites
	/// and document libraries that are connected to the server
	/// </summary>
	public class SharePointServer : SharePointObject
	{
		private string serverName;
		private string serverDescription;
		private DateTime lastModified;
		private ArrayList siteCollection;
		private ArrayList webCollection;

		/// <summary>
		/// Creates a new <see cref="SharePointServer"/> instance.
		/// </summary>
		/// <param name="siteUrl">Server URL.</param>
		public SharePointServer(string siteUrl) : base(siteUrl)
		{
			this.siteUrl = siteUrl;
			siteCollection = new ArrayList();
			webCollection = new ArrayList();
		}

		#region Accessors
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get { return serverName; }
		}

		/// <summary>
		/// Gets the server description.
		/// </summary>
		/// <value></value>
		public string ServerDescription
		{
			get { return serverDescription; }
		}

		/// <summary>
		/// Gets the site collection.
		/// </summary>
		/// <value></value>
		public ArrayList SiteCollection
		{
			get { return siteCollection; }
		}

		/// <summary>
		/// Gets the web collection.
		/// </summary>
		/// <value></value>
		public ArrayList WebCollection
		{
			get { return webCollection; }
		}

		/// <summary>
		/// Gets the last modified.
		/// </summary>
		/// <value></value>
		public DateTime LastModified
		{
			get { return lastModified; }
		}
		#endregion

		/// <summary>
		/// Connects to the sharepoint server given a name. All
		/// this does is setup the server url and get the site title
		/// through the SiteData web service.
		/// </summary>
		public void Connect()
		{
			SiteData ws = NewSiteDataWebService();
			_sWebMetadata webMetadata = null;
			_sSiteMetadata siteMetadata = null;
			_sWebWithTime[] siteTime = null;
			_sListWithTime[] listMData = null;
			_sFPUrl[] urls = null;
			string roles;
			string[] roleUsers;
			string[] roleGroups;
			string users;
			string groups;
			string[] crossSiteGroups;

			siteCollection.Clear();

			try
			{
				// First grab the web metadata
				ws.GetWeb(out webMetadata, out siteTime, out listMData, out urls,
					out roles, out roleUsers, out roleGroups);

				// All this just to get a server name but can be extended for other properties
				serverName = webMetadata.Title;
				serverDescription = webMetadata.Description;

				// Now grab the site metadata (contains different info than the web metadata)
				ws.GetSite(out siteMetadata, out siteTime, out users, out groups,
					out crossSiteGroups);

				// For now just set the last modified DateTime but can be expanded
				lastModified = siteMetadata.LastModified;
			}
			catch (SoapException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Loads the web collection for a given SharePoint server or
		/// top level site collection. If used on a portal server, you'll
		/// get all kinds of values like C1, C2, etc. for all areas.
		/// </summary>
		public void LoadWebCollection()
		{
			Webs ws = NewWebsWebService();
			XmlNode xml = ws.GetWebCollection();
			foreach (XmlNode xmlNode in xml)
			{
				string name = xmlNode.Attributes["Title"].Value;
				string url = CreateFQDN(xmlNode.Attributes["Url"].Value);
				SharePointSite web = new SharePointSite(name, url);
				web.Credentials = Credentials;
				webCollection.Add(web);
			}
		}

		/// <summary>
		/// This loads the top level sites based on the site
		/// list obtained through the SiteDirectory and the list
		/// web service. This creates a new SharePointSite object
		/// which then in turn recursively loads up any subsites
		/// it owns.
		/// </summary>
		/// <remarks>
		/// NOTE: This uses the Sites list from the SiteDirectory
		/// so it assumes all sites are recorded through this so this has
		/// a heavy dependancy on how your sites are recorded. If you want
		/// to get the raw list you can use <see cref="LoadWebCollection"/> 
		/// as this will get everything. The only thing with that method is
		/// that you'll get sitenames like C1, C2, etc. when you do it at
		/// the portal level.
		/// </remarks>
		public void LoadSiteCollection()
		{
			Lists ws = NewSiteDirectoryListsWebService();
			
			XmlNode lists = ws.GetListCollection();
			foreach(XmlNode list in lists)
			{
				string listName = list.Attributes["Title"].Value;
				if(listName.ToUpper() == "SITES")
				{
					// Get the list data from the site list
					string rowLimit = Convert.ToString(1000);

					XmlNode nodListItems = ws.GetListItems(listName, "", null, null, rowLimit, null);
					if(nodListItems.HasChildNodes)
					{
						// Rows are members of the second child node
						XmlNode nodRows = nodListItems.ChildNodes[1];
						if(nodRows.HasChildNodes)
						{
							foreach(XmlNode node in nodRows.ChildNodes)
							{
								if(node.NodeType == XmlNodeType.Element)
								{
									string name = node.Attributes["ows_SiteTitle"].Value;
									string url = CreateFQDN(node.Attributes["ows_SiteURL"].Value);

									SharePointSite site = new SharePointSite(name, url);
									site.Credentials = Credentials;

									siteCollection.Add(site);
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// This adds the child sites to a list based on a filter.
		/// This allows us to recursively add all children regardless
		/// of the parent type.
		/// </summary>
		/// <param name="parentSite"></param>
		/// <param name="filter"></param>
		/// <param name="list"></param>
		public void AddChildSitesToList(SharePointSite parentSite, string filter, ArrayList list)
		{
			foreach(SharePointSite site in parentSite.SubSites)
			{
				list.Add(site);
				if(site.SubSites.Count > 0)
					AddChildSitesToList(site, filter, list);
			}
		}

		/// <summary>
		/// Sometimes a site url is recorded as "/sites/url" instead of a fully qualified
		/// domain name like "http://servername/sites/url" so fix it here
		/// </summary>
		/// <param name="url">Url.</param>
		/// <returns></returns>
		private string CreateFQDN(string url)
		{
			if(!url.StartsWith("http://"))
				url = String.Concat(this.siteUrl, url);

			return url;
		}
	}
}
