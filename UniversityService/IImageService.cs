using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImageService" in both code and config file together.
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        List<ImageType> GetImages();
    }

    [DataContract]
    public class ImageType
    {
        [DataMember]
        public int ImageId { get; set; }
        [DataMember]
        public string ImageName { get; set; }
        [DataMember]
        public string Path { get; set; }
    }
}
