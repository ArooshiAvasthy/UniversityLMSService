using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceClient.Models;
using ServiceClient.VideoServiceReference;
using AutoMapper;

namespace ServiceClient.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        VideoServiceClient videoObj = new VideoServiceClient();
        public ActionResult GuestLectureVideos()
        {
            return View();
        }

        //Course related videos stored in solution and record maintained in DB
        public ActionResult SpecificCourseVideos()
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    return View("PleaseLogin");

                }
                else
                {
                    
                    var data = videoObj.GetSpecificVideos(Session["Course"].ToString());
                    Mapper.Initialize(cfg => { cfg.CreateMap<VideoType, VideoModel>(); });
                    List<VideoModel> vdList = new List<VideoModel>();
                    if(data.Any())
                    {
                        foreach(var item in data)
                        {
                            VideoModel obj = Mapper.Map<VideoType, VideoModel>(item);
                            vdList.Add(obj);
                        }
                    }
                    return View(vdList);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult AllCourseVideos()
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    return View("PleaseLogin");

                }
                else
                {
                    var data = videoObj.GetAllVideos();
                    Mapper.Initialize(cfg => { cfg.CreateMap<VideoType, VideoModel>(); });
                    List<VideoModel> vdList = new List<VideoModel>();
                    if(data.Any())
                    {
                        foreach(var item in data)
                        {
                            VideoModel obj = Mapper.Map<VideoType, VideoModel>(item);
                            vdList.Add(obj);
                        }
                    }
                    return View(vdList);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
	}
}