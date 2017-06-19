using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ServiceClient.Models;
using ServiceClient.BlogServiceReference;

namespace ServiceClient.Controllers
{
    public class TinyMCEController : Controller
    {
        BlogServiceClient blogObj = new BlogServiceClient();

        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return View("PleaseLogin");

            }
            else
            {
                return View();
            }

        }

        // An action that will accept your Html Content
        [HttpPost]
        public ActionResult Index(BlogModel model)
        {
            try
            {

                model.Author = Session["UserName"].ToString();
                model.ImagePath2 = "~/Images/Blog_70x70.png";

                Mapper.Initialize(cfg => { cfg.CreateMap<BlogModel, BlogType>(); });
                BlogType obj = Mapper.Map<BlogModel, BlogType>(model);
                bool response=blogObj.PostBlog(obj);
                 if (response)
                    {

                        return RedirectToAction("BlogPage");
                    }

                    else
                        return RedirectToAction("Error");

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult BlogPage()
        {

            try
            {
                var data= blogObj.GetBlog();
                Mapper.Initialize(cfg => { cfg.CreateMap<BlogType, BlogModel>(); });
                List <BlogModel> blogList= new List<BlogModel>();
                if(data.Any())
                {
                    foreach(var item in data)
                    {
                        BlogModel obj = Mapper.Map<BlogType, BlogModel>(item);
                        blogList.Add(obj);
                    }
                }
                return View(blogList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult BlogPageTopFive()
        {

            try
            {
                var data = blogObj.GetBlog();
                Mapper.Initialize(cfg => { cfg.CreateMap<BlogType, BlogModel>(); });
                List<BlogModel> blogList = new List<BlogModel>();
                if (data.Any())
                {
                    foreach (var item in data)
                    {
                        BlogModel obj = Mapper.Map<BlogType, BlogModel>(item);
                        blogList.Add(obj);
                    }
                }

                var topFive = blogList.Take(5);
                return View(topFive);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult BlogDetails(string Title)
        {
            try
            {
                Mapper.Initialize(cfg=>{cfg.CreateMap<BlogType,BlogModel>();});
                var data = blogObj.GetBlogDetails(Title);
                BlogModel obj = Mapper.Map<BlogType, BlogModel>(data);
            
                return View(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}