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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        LoginDAL obj = new DAL.LoginDAL();
        public bool GetUser(string name, string password)
        {
            try
            {
                bool response = obj.validateCredentials(name,password);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PostNewUser(UserType user)
        {
            try
            {
          
                Mapper.Initialize(cfg => { cfg.CreateMap<UserType, User>(); });
                User newuser = Mapper.Map<UserType, User>(user);
                bool response = obj.AddUser(newuser);
                if (response)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
