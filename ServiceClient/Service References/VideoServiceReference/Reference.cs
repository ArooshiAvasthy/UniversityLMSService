﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceClient.VideoServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VideoType", Namespace="http://schemas.datacontract.org/2004/07/UniversityService")]
    [System.SerializableAttribute()]
    public partial class VideoType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourseIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PosterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VideoNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int videoIDField;
        
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
        public string CourseID {
            get {
                return this.CourseIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseIDField, value) != true)) {
                    this.CourseIDField = value;
                    this.RaisePropertyChanged("CourseID");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Poster {
            get {
                return this.PosterField;
            }
            set {
                if ((object.ReferenceEquals(this.PosterField, value) != true)) {
                    this.PosterField = value;
                    this.RaisePropertyChanged("Poster");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VideoName {
            get {
                return this.VideoNameField;
            }
            set {
                if ((object.ReferenceEquals(this.VideoNameField, value) != true)) {
                    this.VideoNameField = value;
                    this.RaisePropertyChanged("VideoName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int videoID {
            get {
                return this.videoIDField;
            }
            set {
                if ((this.videoIDField.Equals(value) != true)) {
                    this.videoIDField = value;
                    this.RaisePropertyChanged("videoID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VideoServiceReference.IVideoService")]
    public interface IVideoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoService/GetSpecificVideos", ReplyAction="http://tempuri.org/IVideoService/GetSpecificVideosResponse")]
        ServiceClient.VideoServiceReference.VideoType[] GetSpecificVideos(string course);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoService/GetSpecificVideos", ReplyAction="http://tempuri.org/IVideoService/GetSpecificVideosResponse")]
        System.Threading.Tasks.Task<ServiceClient.VideoServiceReference.VideoType[]> GetSpecificVideosAsync(string course);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoService/GetAllVideos", ReplyAction="http://tempuri.org/IVideoService/GetAllVideosResponse")]
        ServiceClient.VideoServiceReference.VideoType[] GetAllVideos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoService/GetAllVideos", ReplyAction="http://tempuri.org/IVideoService/GetAllVideosResponse")]
        System.Threading.Tasks.Task<ServiceClient.VideoServiceReference.VideoType[]> GetAllVideosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVideoServiceChannel : ServiceClient.VideoServiceReference.IVideoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VideoServiceClient : System.ServiceModel.ClientBase<ServiceClient.VideoServiceReference.IVideoService>, ServiceClient.VideoServiceReference.IVideoService {
        
        public VideoServiceClient() {
        }
        
        public VideoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VideoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceClient.VideoServiceReference.VideoType[] GetSpecificVideos(string course) {
            return base.Channel.GetSpecificVideos(course);
        }
        
        public System.Threading.Tasks.Task<ServiceClient.VideoServiceReference.VideoType[]> GetSpecificVideosAsync(string course) {
            return base.Channel.GetSpecificVideosAsync(course);
        }
        
        public ServiceClient.VideoServiceReference.VideoType[] GetAllVideos() {
            return base.Channel.GetAllVideos();
        }
        
        public System.Threading.Tasks.Task<ServiceClient.VideoServiceReference.VideoType[]> GetAllVideosAsync() {
            return base.Channel.GetAllVideosAsync();
        }
    }
}
