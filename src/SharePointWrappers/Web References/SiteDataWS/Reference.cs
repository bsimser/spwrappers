﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace SharePointWrappers.SiteDataWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SiteDataSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class SiteData : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public SiteData() {
            this.Url = "http://localhost/_vti_bin/SiteData.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListCollection", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetListCollection([System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sList[] vLists) {
            object[] results = this.Invoke("GetListCollection", new object[0]);
            vLists = ((_sList[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListCollection(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListCollection", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetListCollection(System.IAsyncResult asyncResult, out _sList[] vLists) {
            object[] results = this.EndInvoke(asyncResult);
            vLists = ((_sList[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetURLSegments", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetURLSegments(string strURL, out string strWebID, out string strBucketID, out string strListID, out string strItemID) {
            object[] results = this.Invoke("GetURLSegments", new object[] {
                        strURL});
            strWebID = ((string)(results[1]));
            strBucketID = ((string)(results[2]));
            strListID = ((string)(results[3]));
            strItemID = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetURLSegments(string strURL, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetURLSegments", new object[] {
                        strURL}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndGetURLSegments(System.IAsyncResult asyncResult, out string strWebID, out string strBucketID, out string strListID, out string strItemID) {
            object[] results = this.EndInvoke(asyncResult);
            strWebID = ((string)(results[1]));
            strBucketID = ((string)(results[2]));
            strListID = ((string)(results[3]));
            strItemID = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/EnumerateFolder", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 EnumerateFolder(string strFolderUrl, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sFPUrl[] vUrls) {
            object[] results = this.Invoke("EnumerateFolder", new object[] {
                        strFolderUrl});
            vUrls = ((_sFPUrl[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginEnumerateFolder(string strFolderUrl, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("EnumerateFolder", new object[] {
                        strFolderUrl}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndEnumerateFolder(System.IAsyncResult asyncResult, out _sFPUrl[] vUrls) {
            object[] results = this.EndInvoke(asyncResult);
            vUrls = ((_sFPUrl[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetAttachments", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetAttachments(string strListName, string strItemId, out string[] vAttachments) {
            object[] results = this.Invoke("GetAttachments", new object[] {
                        strListName,
                        strItemId});
            vAttachments = ((string[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAttachments(string strListName, string strItemId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAttachments", new object[] {
                        strListName,
                        strItemId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetAttachments(System.IAsyncResult asyncResult, out string[] vAttachments) {
            object[] results = this.EndInvoke(asyncResult);
            vAttachments = ((string[])(results[1]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListItems", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListItems(string strListName, string strQuery, string strViewFields, System.UInt32 uRowLimit) {
            object[] results = this.Invoke("GetListItems", new object[] {
                        strListName,
                        strQuery,
                        strViewFields,
                        uRowLimit});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListItems(string strListName, string strQuery, string strViewFields, System.UInt32 uRowLimit, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListItems", new object[] {
                        strListName,
                        strQuery,
                        strViewFields,
                        uRowLimit}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetListItems(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetList", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetList(string strListName, out _sListMetadata sListMetadata, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sProperty[] vProperties) {
            object[] results = this.Invoke("GetList", new object[] {
                        strListName});
            sListMetadata = ((_sListMetadata)(results[1]));
            vProperties = ((_sProperty[])(results[2]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetList(string strListName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetList", new object[] {
                        strListName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetList(System.IAsyncResult asyncResult, out _sListMetadata sListMetadata, out _sProperty[] vProperties) {
            object[] results = this.EndInvoke(asyncResult);
            sListMetadata = ((_sListMetadata)(results[1]));
            vProperties = ((_sProperty[])(results[2]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetWeb", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetWeb(out _sWebMetadata sWebMetadata, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sWebWithTime[] vWebs, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sListWithTime[] vLists, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sFPUrl[] vFPUrls, out string strRoles, out string[] vRolesUsers, out string[] vRolesGroups) {
            object[] results = this.Invoke("GetWeb", new object[0]);
            sWebMetadata = ((_sWebMetadata)(results[1]));
            vWebs = ((_sWebWithTime[])(results[2]));
            vLists = ((_sListWithTime[])(results[3]));
            vFPUrls = ((_sFPUrl[])(results[4]));
            strRoles = ((string)(results[5]));
            vRolesUsers = ((string[])(results[6]));
            vRolesGroups = ((string[])(results[7]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWeb(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWeb", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetWeb(System.IAsyncResult asyncResult, out _sWebMetadata sWebMetadata, out _sWebWithTime[] vWebs, out _sListWithTime[] vLists, out _sFPUrl[] vFPUrls, out string strRoles, out string[] vRolesUsers, out string[] vRolesGroups) {
            object[] results = this.EndInvoke(asyncResult);
            sWebMetadata = ((_sWebMetadata)(results[1]));
            vWebs = ((_sWebWithTime[])(results[2]));
            vLists = ((_sListWithTime[])(results[3]));
            vFPUrls = ((_sFPUrl[])(results[4]));
            strRoles = ((string)(results[5]));
            vRolesUsers = ((string[])(results[6]));
            vRolesGroups = ((string[])(results[7]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetSite", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetSite(out _sSiteMetadata sSiteMetadata, [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] out _sWebWithTime[] vWebs, out string strUsers, out string strGroups, out string[] vGroups) {
            object[] results = this.Invoke("GetSite", new object[0]);
            sSiteMetadata = ((_sSiteMetadata)(results[1]));
            vWebs = ((_sWebWithTime[])(results[2]));
            strUsers = ((string)(results[3]));
            strGroups = ((string)(results[4]));
            vGroups = ((string[])(results[5]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetSite(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetSite", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetSite(System.IAsyncResult asyncResult, out _sSiteMetadata sSiteMetadata, out _sWebWithTime[] vWebs, out string strUsers, out string strGroups, out string[] vGroups) {
            object[] results = this.EndInvoke(asyncResult);
            sSiteMetadata = ((_sSiteMetadata)(results[1]));
            vWebs = ((_sWebWithTime[])(results[2]));
            strUsers = ((string)(results[3]));
            strGroups = ((string)(results[4]));
            vGroups = ((string[])(results[5]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetSiteAndWeb", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.UInt32 GetSiteAndWeb(string strUrl, out string strSite, out string strWeb) {
            object[] results = this.Invoke("GetSiteAndWeb", new object[] {
                        strUrl});
            strSite = ((string)(results[1]));
            strWeb = ((string)(results[2]));
            return ((System.UInt32)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetSiteAndWeb(string strUrl, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetSiteAndWeb", new object[] {
                        strUrl}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.UInt32 EndGetSiteAndWeb(System.IAsyncResult asyncResult, out string strSite, out string strWeb) {
            object[] results = this.EndInvoke(asyncResult);
            strSite = ((string)(results[1]));
            strWeb = ((string)(results[2]));
            return ((System.UInt32)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sList {
        
        /// <remarks/>
        public string InternalName;
        
        /// <remarks/>
        public string Title;
        
        /// <remarks/>
        public string Description;
        
        /// <remarks/>
        public string BaseType;
        
        /// <remarks/>
        public string BaseTemplate;
        
        /// <remarks/>
        public string DefaultViewUrl;
        
        /// <remarks/>
        public string LastModified;
        
        /// <remarks/>
        public string PermId;
        
        /// <remarks/>
        public bool InheritedSecurity;
        
        /// <remarks/>
        public bool AllowAnonymousAccess;
        
        /// <remarks/>
        public bool AnonymousViewListItems;
        
        /// <remarks/>
        public int ReadSecurity;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sSiteMetadata {
        
        /// <remarks/>
        public System.DateTime LastModified;
        
        /// <remarks/>
        public System.DateTime LastModifiedForceRecrawl;
        
        /// <remarks/>
        public bool SmallSite;
        
        /// <remarks/>
        public string PortalUrl;
        
        /// <remarks/>
        public string UserProfileGUID;
        
        /// <remarks/>
        public bool ValidSecurityInfo;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sListWithTime {
        
        /// <remarks/>
        public string InternalName;
        
        /// <remarks/>
        public System.DateTime LastModified;
        
        /// <remarks/>
        public bool IsEmpty;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sWebWithTime {
        
        /// <remarks/>
        public string Url;
        
        /// <remarks/>
        public System.DateTime LastModified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sWebMetadata {
        
        /// <remarks/>
        public string WebID;
        
        /// <remarks/>
        public string Title;
        
        /// <remarks/>
        public string Description;
        
        /// <remarks/>
        public string Author;
        
        /// <remarks/>
        public System.UInt32 Language;
        
        /// <remarks/>
        public System.DateTime LastModified;
        
        /// <remarks/>
        public System.DateTime LastModifiedForceRecrawl;
        
        /// <remarks/>
        public string NoIndex;
        
        /// <remarks/>
        public bool ValidSecurityInfo;
        
        /// <remarks/>
        public bool InheritedSecurity;
        
        /// <remarks/>
        public bool AllowAnonymousAccess;
        
        /// <remarks/>
        public bool AnonymousViewListItems;
        
        /// <remarks/>
        public string Permissions;
        
        /// <remarks/>
        public bool ExternalSecurity;
        
        /// <remarks/>
        public string CategoryId;
        
        /// <remarks/>
        public string CategoryName;
        
        /// <remarks/>
        public string CategoryIdPath;
        
        /// <remarks/>
        public bool IsBucketWeb;
        
        /// <remarks/>
        public bool UsedInAutocat;
        
        /// <remarks/>
        public string CategoryBucketID;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sProperty {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Title;
        
        /// <remarks/>
        public string Type;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sListMetadata {
        
        /// <remarks/>
        public string Title;
        
        /// <remarks/>
        public string Description;
        
        /// <remarks/>
        public string BaseType;
        
        /// <remarks/>
        public string BaseTemplate;
        
        /// <remarks/>
        public string DefaultViewUrl;
        
        /// <remarks/>
        public System.DateTime LastModified;
        
        /// <remarks/>
        public System.DateTime LastModifiedForceRecrawl;
        
        /// <remarks/>
        public string Author;
        
        /// <remarks/>
        public bool ValidSecurityInfo;
        
        /// <remarks/>
        public bool InheritedSecurity;
        
        /// <remarks/>
        public bool AllowAnonymousAccess;
        
        /// <remarks/>
        public bool AnonymousViewListItems;
        
        /// <remarks/>
        public int ReadSecurity;
        
        /// <remarks/>
        public string Permissions;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class _sFPUrl {
        
        /// <remarks/>
        public string Url;
        
        /// <remarks/>
        public System.DateTime LastModified;
        
        /// <remarks/>
        public bool IsFolder;
    }
}
