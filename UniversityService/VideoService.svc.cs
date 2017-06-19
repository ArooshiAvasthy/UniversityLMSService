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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VideoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VideoService.svc or VideoService.svc.cs at the Solution Explorer and start debugging.
    public class VideoService : IVideoService
    {
        VideoDAL videoObj = new VideoDAL();
        public List<VideoType> GetSpecificVideos(string course)
        {
            try
            {
                var data = videoObj.GetSpecificVideos(course);
                List<VideoType> courseList = new List<VideoType>();
                Mapper.Initialize(cfg => { cfg.CreateMap<Video, VideoType>(); });

                if (data.Any())
                {
                    //Mapper initialization and creation
                    Mapper.Initialize(cfg => { cfg.CreateMap<Video, VideoType>(); });
                    foreach (var item in data)
                    {
                        VideoType infoModel = Mapper.Map<Video, VideoType>(item);
                        courseList.Add(infoModel);
                    }
                }

                return courseList;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VideoType> GetAllVideos()
        {
            try
            {
                var data = videoObj.GetAllVideos();
                List<VideoType> courseList = new List<VideoType>();
                Mapper.Initialize(cfg => { cfg.CreateMap<Video, VideoType>(); });

                if (data.Any())
                {
                    //Mapper initialization and creation
                    Mapper.Initialize(cfg => { cfg.CreateMap<Video, VideoType>(); });
                    foreach (var item in data)
                    {
                        VideoType infoModel = Mapper.Map<Video, VideoType>(item);
                        courseList.Add(infoModel);
                    }
                }

                return courseList;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
