using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL;
using AutoMapper;

namespace UniversityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CourseService : ICourseService
    {
        CourseDAL courseObj = new CourseDAL();
        public List<CourseType> GetDisplayAllCourses()
        {
            try
            {
  
            var data = courseObj.GetAllCourses();
            List<CourseType> courseList = new List<CourseType>();
            Mapper.Initialize(cfg => { cfg.CreateMap<Course, CourseType>(); });

            if (data.Any())
            {
                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<Course, CourseType>(); });
                foreach (var item in data)
                {
                    CourseType infoModel = Mapper.Map<Course, CourseType>(item);
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

        public bool PostEnrolledUser(string username,string course)
        {
            try
            {
                //string username = enrollmentInfo.Name;
                //string coursename = enrollmentInfo.Coursename;
                bool response= courseObj.EnrolledUser(username, course);

                return response;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<FileType> GetCourseFiles(string courseName)
        {
            try
            {
                var files = courseObj.GetFiles(courseName);
                Mapper.Initialize(cfg => { cfg.CreateMap<PDFFile, FileType>(); });
                List<FileType> fileList = new List<FileType>();
                if (files.Any())
                {
                    foreach (var item in files)
                    {
                        FileType fileObj = Mapper.Map<PDFFile, FileType>(item);
                        fileList.Add(fileObj);
                    }
                }
                return fileList; 
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public FileType GetSpecificFile(int id)
        {
            try
            {
                var data = courseObj.GetSpecificFile(id);
                Mapper.Initialize(cfg => { cfg.CreateMap<PDFFile, FileType>(); });

                FileType fileObj = Mapper.Map<PDFFile, FileType>(data);


                return fileObj;
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }

        public void PostFile(FileType fileObj)
        {
            try
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<FileType, PDFFile>(); });
                PDFFile obj = Mapper.Map<FileType, PDFFile>(fileObj);
                courseObj.AddFile(obj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
