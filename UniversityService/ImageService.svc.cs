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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageService.svc or ImageService.svc.cs at the Solution Explorer and start debugging.
    public class ImageService : IImageService
    {
         ImageDAL imgObj = new ImageDAL();
        public List<ImageType> GetImages()
        {
            try
            {
                var data = imgObj.GetImages();
                List<ImageType> imgList = new List<ImageType>();
                Mapper.Initialize(cfg => { cfg.CreateMap<Image, ImageType>(); });

                if (data.Any())
                {
                    //Mapper initialization and creation
                    Mapper.Initialize(cfg => { cfg.CreateMap<Image, ImageType>(); });
                    foreach (var item in data)
                    {
                        ImageType infoModel = Mapper.Map<Image, ImageType>(item);
                        imgList.Add(infoModel);
                    }
                }

                return imgList;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
