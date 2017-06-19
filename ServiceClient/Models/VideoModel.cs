using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceClient.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string Path { get; set; }
        public Nullable<int> CourseID { get; set; }
        public string Poster { get; set; }
    }
}