using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using SharePointWrappers.DwsWS;
using SharePointWrappers.ListsWS;
using SharePointWrappers.SiteDataWS;
using SharePointWrappers.VersionsWS;
using SharePointWrappers.ViewWS;
using SharePointWrappers.WebPartPagesWS;
using SharePointWrappers.WebsWS;

namespace SharePointWrappers
{
	/// <summary>
	/// This is the base class for all classes in this library. It's also the central place 
	/// for storing credentials as well as being a facade to the the web services. It allows you to 
	/// create a new webservice and automatically assign it with the right credentials no matter where 
	/// the service is being created from (SPS portal, SPS area, WSS site, etc.)
	/// </summary>
	public abstract class SharePointObject
	{
		#region Private member variables

		private string siteDirectoryListsUrl;
		private ICredentials credentials;

		#endregion

		#region Protected member variables

		/// <summary>
		/// 
		/// </summary>
		protected string siteUrl;

		#endregion

		#region Accessors

		/// <summary>
		/// Gets the URL.
		/// </summary>
		/// <value></value>
		public string Url
		{
			get { return this.siteUrl; }
		}
		
		#endregion

		/// <summary>
		/// Creates a new <see cref="SharePointObject"/> instance.
		/// </summary>
		/// <param name="siteUrl">Site URL.</param>
		public SharePointObject(string siteUrl)
		{
			credentials = CredentialCache.DefaultCredentials;
			this.siteUrl = siteUrl + "/_vti_bin/";
			siteDirectoryListsUrl = String.Concat(Regex.Match(siteUrl + "/", "http://.*?/").Value, "SiteDirectory/_vti_bin/Lists.asmx");
		}

		/// <summary>
		/// Gets the site directory lists URL.
		/// </summary>
		/// <value></value>
		protected string SiteDirectoryListsUrl
		{
			get { return siteDirectoryListsUrl; }
		}

		/// <summary>
		/// Gets or sets the credentials.
		/// </summary>
		/// <value></value>
		public ICredentials Credentials
		{
			get { return credentials; }
			set { credentials = value; }
		}

		/// <summary>
		/// News the lists web service.
		/// </summary>
		/// <returns></returns>
		public Lists NewListsWebService()
		{
			Lists ws = new Lists();
			ws.Url = siteUrl + "Lists.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the versions web service.
		/// </summary>
		/// <returns></returns>
		public Versions NewVersionsWebService()
		{
			Versions ws = new Versions();
			ws.Url = siteUrl + "Versions.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the web part pages web service.
		/// </summary>
		/// <returns></returns>
		public WebPartPagesWebService NewWebPartPagesWebService()
		{
			WebPartPagesWebService ws = new WebPartPagesWebService();
			ws.Url = siteUrl + "WebPartPages.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the views web service.
		/// </summary>
		/// <returns></returns>
		public Views NewViewsWebService()
		{
			Views ws = new Views();
			ws.Url = siteUrl + "Views.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the webs web service.
		/// </summary>
		/// <returns></returns>
		public Webs NewWebsWebService()
		{
			Webs ws = new Webs();
			ws.Url = siteUrl + "Webs.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the site data web service.
		/// </summary>
		/// <returns></returns>
		public SiteData NewSiteDataWebService()
		{
			SiteData ws = new SiteData();
			ws.Url = siteUrl + "SiteData.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the site directory lists web service.
		/// </summary>
		/// <returns></returns>
		public Lists NewSiteDirectoryListsWebService()
		{
			Lists ws = new Lists();
			ws.Url = SiteDirectoryListsUrl;
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// News the DWS web service.
		/// </summary>
		/// <returns></returns>
		public Dws NewDwsWebService()
		{
			Dws ws = new Dws();
			ws.Url = siteUrl + "Dws.asmx";
			ws.Credentials = Credentials;
			return ws;
		}

		/// <summary>
		/// Helper function to parse Document Workspace WS
		/// error messages.
		/// </summary>
		/// <param name="ResultFragment"></param>
		/// <returns></returns>
		protected bool IsDwsErrorResult(string ResultFragment)
		{
			bool result = false;
			StringReader srResult = new StringReader(ResultFragment);
			XmlTextReader xtr = new XmlTextReader(srResult);
			xtr.Read();
			if(xtr.Name == "Error")
			{
				result = true;
			}
			return result;
		}
	}
}
