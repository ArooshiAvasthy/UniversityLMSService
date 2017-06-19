using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;
using AutoMapper;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BlogService : IBlogService
    {
        BlogDAL blogObj = new BlogDAL();
        public List<BlogType> GetBlog()
        {
            try
            {
                var data = blogObj.GetBlogs();
                Mapper.Initialize(cfg => { cfg.CreateMap<Blog, BlogType>(); });
                List<BlogType> blogList = new List<BlogType>();

                if (data.Any())
                {
                    foreach (var item in data)
                    {
                        BlogType obj = Mapper.Map<Blog, BlogType>(item);
                        blogList.Add(obj);
                    }
                }
                return blogList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool PostBlog(BlogType blogData)
        {
            try
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<BlogType, Blog>(); });
                Blog obj = Mapper.Map<BlogType, Blog>(blogData);

                bool response=blogObj.PostBlogData(obj);

                return response;
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public BlogType GetBlogDetails(string title)
        {
            try
            {
                var data = blogObj.GetBlogDetails(title);
                Mapper.Initialize(cfg => { cfg.CreateMap<Blog, BlogType>(); });
                BlogType obj = Mapper.Map<Blog, BlogType>(data);

                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
