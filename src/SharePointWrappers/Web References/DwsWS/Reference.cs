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
namespace SharePointWrappers.DwsWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DwsSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/dws/")]
    public class Dws : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Dws() {
            this.Url = "http://localhost/SiteDirectory/_vti_bin/Dws.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/DeleteFolder", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DeleteFolder(string url) {
            object[] results = this.Invoke("DeleteFolder", new object[] {
                        url});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteFolder(string url, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteFolder", new object[] {
                        url}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndDeleteFolder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/CreateFolder", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CreateFolder(string url) {
            object[] results = this.Invoke("CreateFolder", new object[] {
                        url});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCreateFolder(string url, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CreateFolder", new object[] {
                        url}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCreateFolder(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/CanCreateDwsUrl", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CanCreateDwsUrl(string url) {
            object[] results = this.Invoke("CanCreateDwsUrl", new object[] {
                        url});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCanCreateDwsUrl(string url, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CanCreateDwsUrl", new object[] {
                        url}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCanCreateDwsUrl(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/FindDwsDoc", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FindDwsDoc(string id) {
            object[] results = this.Invoke("FindDwsDoc", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginFindDwsDoc(string id, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("FindDwsDoc", new object[] {
                        id}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndFindDwsDoc(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/RenameDws", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RenameDws(string title) {
            object[] results = this.Invoke("RenameDws", new object[] {
                        title});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRenameDws(string title, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RenameDws", new object[] {
                        title}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndRenameDws(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/RemoveDwsUser", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RemoveDwsUser(string id) {
            object[] results = this.Invoke("RemoveDwsUser", new object[] {
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRemoveDwsUser(string id, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RemoveDwsUser", new object[] {
                        id}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndRemoveDwsUser(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/UpdateDwsData", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UpdateDwsData(string updates, string meetingInstance) {
            object[] results = this.Invoke("UpdateDwsData", new object[] {
                        updates,
                        meetingInstance});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateDwsData(string updates, string meetingInstance, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateDwsData", new object[] {
                        updates,
                        meetingInstance}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUpdateDwsData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/GetDwsData", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetDwsData(string document, string lastUpdate) {
            object[] results = this.Invoke("GetDwsData", new object[] {
                        document,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDwsData(string document, string lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDwsData", new object[] {
                        document,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetDwsData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/GetDwsMetaData", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetDwsMetaData(string document, string id, bool minimal) {
            object[] results = this.Invoke("GetDwsMetaData", new object[] {
                        document,
                        id,
                        minimal});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDwsMetaData(string document, string id, bool minimal, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDwsMetaData", new object[] {
                        document,
                        id,
                        minimal}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetDwsMetaData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/DeleteDws", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DeleteDws() {
            object[] results = this.Invoke("DeleteDws", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteDws(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteDws", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndDeleteDws(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/dws/CreateDws", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/dws/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CreateDws(string name, string users, string title, string documents) {
            object[] results = this.Invoke("CreateDws", new object[] {
                        name,
                        users,
                        title,
                        documents});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCreateDws(string name, string users, string title, string documents, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CreateDws", new object[] {
                        name,
                        users,
                        title,
                        documents}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCreateDws(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
