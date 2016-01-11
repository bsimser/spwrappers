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
namespace SharePointWrappers.ListsWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ListsSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class Lists : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Lists() {
            this.Url = "http://localhost/_vti_bin/Lists.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListCollection", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetListCollection() {
            object[] results = this.Invoke("GetListCollection", new object[0]);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListCollection(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListCollection", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetListCollection(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/DeleteList", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteList(string listName) {
            this.Invoke("DeleteList", new object[] {
                        listName});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteList(string listName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteList", new object[] {
                        listName}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndDeleteList(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/UpdateList", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode UpdateList(string listName, System.Xml.XmlNode listProperties, System.Xml.XmlNode newFields, System.Xml.XmlNode updateFields, System.Xml.XmlNode deleteFields, string listVersion) {
            object[] results = this.Invoke("UpdateList", new object[] {
                        listName,
                        listProperties,
                        newFields,
                        updateFields,
                        deleteFields,
                        listVersion});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateList(string listName, System.Xml.XmlNode listProperties, System.Xml.XmlNode newFields, System.Xml.XmlNode updateFields, System.Xml.XmlNode deleteFields, string listVersion, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateList", new object[] {
                        listName,
                        listProperties,
                        newFields,
                        updateFields,
                        deleteFields,
                        listVersion}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndUpdateList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/AddList", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode AddList(string listName, string description, int templateID) {
            object[] results = this.Invoke("AddList", new object[] {
                        listName,
                        description,
                        templateID});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddList(string listName, string description, int templateID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddList", new object[] {
                        listName,
                        description,
                        templateID}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndAddList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListAndView", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetListAndView(string listName, string viewName) {
            object[] results = this.Invoke("GetListAndView", new object[] {
                        listName,
                        viewName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListAndView(string listName, string viewName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListAndView", new object[] {
                        listName,
                        viewName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetListAndView(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetList", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetList(string listName) {
            object[] results = this.Invoke("GetList", new object[] {
                        listName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetList(string listName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetList", new object[] {
                        listName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/DeleteAttachment", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteAttachment(string listName, string listItemID, string url) {
            this.Invoke("DeleteAttachment", new object[] {
                        listName,
                        listItemID,
                        url});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteAttachment(string listName, string listItemID, string url, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteAttachment", new object[] {
                        listName,
                        listItemID,
                        url}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndDeleteAttachment(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetAttachmentCollection", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetAttachmentCollection(string listName, string listItemID) {
            object[] results = this.Invoke("GetAttachmentCollection", new object[] {
                        listName,
                        listItemID});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAttachmentCollection(string listName, string listItemID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAttachmentCollection", new object[] {
                        listName,
                        listItemID}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetAttachmentCollection(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/AddAttachment", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddAttachment(string listName, string listItemID, string fileName, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] System.Byte[] attachment) {
            object[] results = this.Invoke("AddAttachment", new object[] {
                        listName,
                        listItemID,
                        fileName,
                        attachment});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddAttachment(string listName, string listItemID, string fileName, System.Byte[] attachment, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddAttachment", new object[] {
                        listName,
                        listItemID,
                        fileName,
                        attachment}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndAddAttachment(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/UpdateListItems", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode UpdateListItems(string listName, System.Xml.XmlNode updates) {
            object[] results = this.Invoke("UpdateListItems", new object[] {
                        listName,
                        updates});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateListItems(string listName, System.Xml.XmlNode updates, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateListItems", new object[] {
                        listName,
                        updates}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndUpdateListItems(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListItemChanges", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetListItemChanges(string listName, System.Xml.XmlNode viewFields, string since, System.Xml.XmlNode contains) {
            object[] results = this.Invoke("GetListItemChanges", new object[] {
                        listName,
                        viewFields,
                        since,
                        contains});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListItemChanges(string listName, System.Xml.XmlNode viewFields, string since, System.Xml.XmlNode contains, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListItemChanges", new object[] {
                        listName,
                        viewFields,
                        since,
                        contains}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetListItemChanges(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetListItems", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetListItems(string listName, string viewName, System.Xml.XmlNode query, System.Xml.XmlNode viewFields, string rowLimit, System.Xml.XmlNode queryOptions) {
            object[] results = this.Invoke("GetListItems", new object[] {
                        listName,
                        viewName,
                        query,
                        viewFields,
                        rowLimit,
                        queryOptions});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetListItems(string listName, string viewName, System.Xml.XmlNode query, System.Xml.XmlNode viewFields, string rowLimit, System.Xml.XmlNode queryOptions, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetListItems", new object[] {
                        listName,
                        viewName,
                        query,
                        viewFields,
                        rowLimit,
                        queryOptions}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetListItems(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
    }
}
