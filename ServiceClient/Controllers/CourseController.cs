using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ServiceClient.CourseServiceReference;
using AutoMapper;
using ServiceClient.Models;
using System.IO;

namespace ServiceClient.Controllers
{
    public class CourseController : Controller
    {

        CourseServiceClient courseObj = new CourseServiceClient();

        [HttpGet]
        public ActionResult AllCourses()
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    return View("PleaseLogin");

                }
                else
                {
                    var data = courseObj.GetDisplayAllCourses();
                    List<CourseModel> courseList = new List<CourseModel>();

                    if (data.Any())
                    {
                        //Mapper initialization and creation
                        Mapper.Initialize(cfg => { cfg.CreateMap<CourseType,CourseModel>(); });
                        foreach (var item in data)
                        {
                            CourseModel infoModel = Mapper.Map<CourseType, CourseModel>(item);
                            courseList.Add(infoModel);
                        }
                    }

                    return View(courseList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Enroll(string CourseName)
        {
   
            try
            {

                string Name = Session["UserName"].ToString();


                bool response = courseObj.PostEnrolledUser(Name, CourseName);

                if (response)
                {

                    return RedirectToAction("CoursePage", "Course", new { coursename = CourseName });
                }

                else
                    return RedirectToAction("Error");
                

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult CoursePage(string coursename)
        {
            try
            {
                Session["Course"] = coursename;
                var data = courseObj.GetCourseFiles(coursename);
                List<FileModel> courseList = new List<FileModel>();

                if (data.Any())
                {
                    //Mapper initialization and creation
                    Mapper.Initialize(cfg => { cfg.CreateMap<FileType, FileModel>(); });
                    foreach (var item in data)
                    {
                        FileModel infoModel = Mapper.Map<FileType, FileModel>(item);
                        courseList.Add(infoModel);
                    }
                }

                return View(courseList);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Download File
        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
          
            try
            {
                var data = courseObj.GetSpecificFile(id);
                Mapper.Initialize(cfg=>cfg.CreateMap<FileType,FileModel>());
                FileModel fileObj = Mapper.Map<FileType, FileModel>(data);

                return File(fileObj.data, "application/pdf/doc", fileObj.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Upload File
        public ActionResult FileUpload()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase files)
        {
            try
            {
                String FileExt = Path.GetExtension(files.FileName).ToUpper();

                if (FileExt == ".PDF")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    FileModel Fd = new Models.FileModel();
                    Fd.Name = files.FileName;
                    Fd.data = FileDet;
                    Fd.Type = "application/pdf";
                    Fd.Courses = Session["Course"].ToString();
                    Mapper.Initialize(cfg => { cfg.CreateMap<FileModel, FileType>(); });
                    FileType fileObj = Mapper.Map<FileModel, FileType>(Fd);
                    courseObj.PostFile(fileObj);
                    return RedirectToAction("CoursePage", new { coursename = Fd.Courses });
                }

                else if (FileExt == ".PPT")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    FileModel Fd = new Models.FileModel();
                    Fd.Name = files.FileName;
                    Fd.data = FileDet;
                    Fd.Type = "application/ppt";
                    Fd.Courses = Session["Course"].ToString();
                    Mapper.Initialize(cfg => { cfg.CreateMap<FileModel, FileType>(); });
                    FileType fileObj = Mapper.Map<FileModel, FileType>(Fd);
                    courseObj.PostFile(fileObj);
                    return RedirectToAction("CoursePage", new { coursename = Fd.Courses });
                }

                else if (FileExt == ".DOCX")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    FileModel Fd = new Models.FileModel();
                    Fd.Name = files.FileName;
                    Fd.data = FileDet;
                    Fd.Type = "application/docx";
                    Fd.Courses = Session["Course"].ToString();
                    Mapper.Initialize(cfg => { cfg.CreateMap<FileModel, FileType>(); });
                    FileType fileObj = Mapper.Map<FileModel, FileType>(Fd);
                    courseObj.PostFile(fileObj);
                    return RedirectToAction("CoursePage", new { coursename = Fd.Courses });
                }
                else if (FileExt == ".XLSX")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    FileModel Fd = new Models.FileModel();
                    Fd.Name = files.FileName;
                    Fd.data = FileDet;
                    Fd.Type = "application/excel";
                    Fd.Courses = Session["Course"].ToString();
                    Mapper.Initialize(cfg => { cfg.CreateMap<FileModel, FileType>(); });
                    FileType fileObj = Mapper.Map<FileModel, FileType>(Fd);
                    courseObj.PostFile(fileObj);
                    return RedirectToAction("CoursePage", new { coursename = Fd.Courses });
                }
                else
                {

                    //ViewBag.FileStatus = "Invalid file format.";
                    return View("Invalid");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

	}
}