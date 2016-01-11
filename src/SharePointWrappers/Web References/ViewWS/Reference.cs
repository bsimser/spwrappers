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
namespace SharePointWrappers.ViewWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ViewsSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public class Views : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Views() {
            this.Url = "http://localhost/_vti_bin/Views.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetViewCollection", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetViewCollection(string listName) {
            object[] results = this.Invoke("GetViewCollection", new object[] {
                        listName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetViewCollection(string listName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetViewCollection", new object[] {
                        listName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetViewCollection(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/UpdateViewHtml", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode UpdateViewHtml(string listName, string viewName, System.Xml.XmlNode viewProperties, System.Xml.XmlNode toolbar, System.Xml.XmlNode viewHeader, System.Xml.XmlNode viewBody, System.Xml.XmlNode viewFooter, System.Xml.XmlNode viewEmpty, System.Xml.XmlNode rowLimitExceeded, System.Xml.XmlNode query, System.Xml.XmlNode viewFields, System.Xml.XmlNode aggregations, System.Xml.XmlNode formats, System.Xml.XmlNode rowLimit) {
            object[] results = this.Invoke("UpdateViewHtml", new object[] {
                        listName,
                        viewName,
                        viewProperties,
                        toolbar,
                        viewHeader,
                        viewBody,
                        viewFooter,
                        viewEmpty,
                        rowLimitExceeded,
                        query,
                        viewFields,
                        aggregations,
                        formats,
                        rowLimit});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateViewHtml(
                    string listName, 
                    string viewName, 
                    System.Xml.XmlNode viewProperties, 
                    System.Xml.XmlNode toolbar, 
                    System.Xml.XmlNode viewHeader, 
                    System.Xml.XmlNode viewBody, 
                    System.Xml.XmlNode viewFooter, 
                    System.Xml.XmlNode viewEmpty, 
                    System.Xml.XmlNode rowLimitExceeded, 
                    System.Xml.XmlNode query, 
                    System.Xml.XmlNode viewFields, 
                    System.Xml.XmlNode aggregations, 
                    System.Xml.XmlNode formats, 
                    System.Xml.XmlNode rowLimit, 
                    System.AsyncCallback callback, 
                    object asyncState) {
            return this.BeginInvoke("UpdateViewHtml", new object[] {
                        listName,
                        viewName,
                        viewProperties,
                        toolbar,
                        viewHeader,
                        viewBody,
                        viewFooter,
                        viewEmpty,
                        rowLimitExceeded,
                        query,
                        viewFields,
                        aggregations,
                        formats,
                        rowLimit}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndUpdateViewHtml(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/UpdateView", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode UpdateView(string listName, string viewName, System.Xml.XmlNode viewProperties, System.Xml.XmlNode query, System.Xml.XmlNode viewFields, System.Xml.XmlNode aggregations, System.Xml.XmlNode formats, System.Xml.XmlNode rowLimit) {
            object[] results = this.Invoke("UpdateView", new object[] {
                        listName,
                        viewName,
                        viewProperties,
                        query,
                        viewFields,
                        aggregations,
                        formats,
                        rowLimit});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateView(string listName, string viewName, System.Xml.XmlNode viewProperties, System.Xml.XmlNode query, System.Xml.XmlNode viewFields, System.Xml.XmlNode aggregations, System.Xml.XmlNode formats, System.Xml.XmlNode rowLimit, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateView", new object[] {
                        listName,
                        viewName,
                        viewProperties,
                        query,
                        viewFields,
                        aggregations,
                        formats,
                        rowLimit}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndUpdateView(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/AddView", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode AddView(string listName, string viewName, System.Xml.XmlNode viewFields, System.Xml.XmlNode query, System.Xml.XmlNode rowLimit, string type, bool makeViewDefault) {
            object[] results = this.Invoke("AddView", new object[] {
                        listName,
                        viewName,
                        viewFields,
                        query,
                        rowLimit,
                        type,
                        makeViewDefault});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddView(string listName, string viewName, System.Xml.XmlNode viewFields, System.Xml.XmlNode query, System.Xml.XmlNode rowLimit, string type, bool makeViewDefault, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddView", new object[] {
                        listName,
                        viewName,
                        viewFields,
                        query,
                        rowLimit,
                        type,
                        makeViewDefault}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndAddView(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/DeleteView", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteView(string listName, string viewName) {
            this.Invoke("DeleteView", new object[] {
                        listName,
                        viewName});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDeleteView(string listName, string viewName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DeleteView", new object[] {
                        listName,
                        viewName}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndDeleteView(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetViewHtml", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetViewHtml(string listName, string viewName) {
            object[] results = this.Invoke("GetViewHtml", new object[] {
                        listName,
                        viewName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetViewHtml(string listName, string viewName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetViewHtml", new object[] {
                        listName,
                        viewName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetViewHtml(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetView", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetView(string listName, string viewName) {
            object[] results = this.Invoke("GetView", new object[] {
                        listName,
                        viewName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetView(string listName, string viewName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetView", new object[] {
                        listName,
                        viewName}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndGetView(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
    }
}