using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICourseService
    {

        [OperationContract]
        List<CourseType> GetDisplayAllCourses();

        [OperationContract]
        bool PostEnrolledUser(string username,string course);
       
        [OperationContract]
         List<FileType> GetCourseFiles(string courseName);
       
        [OperationContract]
         FileType GetSpecificFile(int id);

        [OperationContract]
         void PostFile(FileType fileObj);
      
    }

    [DataContract]
    public class FileType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public byte[] data { get; set; }
        [DataMember]
        public string Courses { get; set; }
    }

    [DataContract]
    public class CourseType
    {
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public string Stream { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImagePath { get; set; }

    }

    [DataContract]
    public class infoType
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Coursename { get; set; }
    }
   
}
