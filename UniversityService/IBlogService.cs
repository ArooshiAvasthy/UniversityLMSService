using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        List<BlogType> GetBlog();

        [OperationContract]
        bool PostBlog(BlogType blogData);

        [OperationContract]
        BlogType GetBlogDetails(string title);
       
    }

    [DataContract]
    public class BlogType
    {
        [DataMember]
        public int BlogId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string IntroWords { get; set; }
        [DataMember]
        public string ImagePath2 { get; set; }
    }
}
