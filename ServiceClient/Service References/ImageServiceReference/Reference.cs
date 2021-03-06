﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceClient.ImageServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageType", Namespace="http://schemas.datacontract.org/2004/07/UniversityService")]
    [System.SerializableAttribute()]
    public partial class ImageType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ImageIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ImageId {
            get {
                return this.ImageIdField;
            }
            set {
                if ((this.ImageIdField.Equals(value) != true)) {
                    this.ImageIdField = value;
                    this.RaisePropertyChanged("ImageId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageName {
            get {
                return this.ImageNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageNameField, value) != true)) {
                    this.ImageNameField = value;
                    this.RaisePropertyChanged("ImageName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path {
            get {
                return this.PathField;
            }
            set {
                if ((object.ReferenceEquals(this.PathField, value) != true)) {
                    this.PathField = value;
                    this.RaisePropertyChanged("Path");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageServiceReference.IImageService")]
    public interface IImageService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/GetImages", ReplyAction="http://tempuri.org/IImageService/GetImagesResponse")]
        ServiceClient.ImageServiceReference.ImageType[] GetImages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/GetImages", ReplyAction="http://tempuri.org/IImageService/GetImagesResponse")]
        System.Threading.Tasks.Task<ServiceClient.ImageServiceReference.ImageType[]> GetImagesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IImageServiceChannel : ServiceClient.ImageServiceReference.IImageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageServiceClient : System.ServiceModel.ClientBase<ServiceClient.ImageServiceReference.IImageService>, ServiceClient.ImageServiceReference.IImageService {
        
        public ImageServiceClient() {
        }
        
        public ImageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceClient.ImageServiceReference.ImageType[] GetImages() {
            return base.Channel.GetImages();
        }
        
        public System.Threading.Tasks.Task<ServiceClient.ImageServiceReference.ImageType[]> GetImagesAsync() {
            return base.Channel.GetImagesAsync();
        }
    }
}
