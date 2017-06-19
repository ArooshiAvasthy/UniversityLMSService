using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceClient.Models;
using ServiceClient.LoginServiceReference;
using AutoMapper;

namespace ServiceClient.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        LoginServiceClient loginObj = new LoginServiceClient();

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string UserName, string Password)
        {
            //PutAsjsonAsync username and password and verify
            Session["UserName"] = UserName;
            Session["Password"] = Password;
            Session["Login"] = null;
            Session["Name"] = null;

            return RedirectToAction("Authorization");
        }

        public ActionResult Authorization()
        {
            bool response = loginObj.GetUser(Session["UserName"].ToString(), Session["Password"].ToString());

            if (response)
            {
                return RedirectToAction("SetSession");
            }
            else
            {

                return RedirectToAction("SignUp");
            }
            //return View();
        }

        //[WebMethod(EnableSession = true)]
        public ActionResult SetSession()
        {
            Session["Login"] = "Success";
            Session["Name"] = Session["UserName"];
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["Password"] = null;
            Session["Login"] = null;
            Session["Name"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel usermodel)
        {

            try
            {
                Mapper.Initialize(cfg => {cfg.CreateMap<UserModel, UserType>(); });
                UserType obj = Mapper.Map<UserModel, UserType>(usermodel);
                loginObj.PostNewUser(obj);

                return RedirectToAction("SignUp", "Login");
            }
            catch
            {
                return View();
            }

        }
    }
}