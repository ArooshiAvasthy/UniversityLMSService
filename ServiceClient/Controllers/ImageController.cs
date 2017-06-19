using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceClient.ImageServiceReference;
using ServiceClient.Models;

namespace ServiceClient.Controllers
{
    public class ImageController : Controller
    {
        ImageServiceClient imgObj = new ImageServiceClient();

        // GET: /Image/
        public ActionResult ImageGallery2()
        {
            try
            {
                var data = imgObj.GetImages();
                Mapper.Initialize(cfg => { cfg.CreateMap<ImageType, ImageModel>();});
                List<ImageModel> imgList = new List<ImageModel>();
                if(data.Any())
                {
                    foreach(var item in data)
                    {
                        ImageModel obj= Mapper.Map<ImageType,ImageModel>(item);
                        imgList.Add(obj);
                    }
                }
                
                return View(imgList);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}