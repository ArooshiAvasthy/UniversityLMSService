using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVideoService" in both code and config file together.
    [ServiceContract]
    public interface IVideoService
    {
        [OperationContract]
        List<VideoType> GetSpecificVideos(string course);
        [OperationContract]
        List<VideoType> GetAllVideos();
       
    }

    [DataContract]
    public class VideoType
    {
        [DataMember]
        public int videoID { get; set; }
        [DataMember]
        public string VideoName { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string CourseID { get; set; }
        [DataMember]
        public string Poster { get; set; }
    }
}
