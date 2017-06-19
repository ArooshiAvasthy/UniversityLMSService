using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDAL
    {
        University2Entities obj = new University2Entities();
        public bool validateCredentials(string username, string password)
        {
            try
            {
                using (University2Entities obj = new University2Entities())
                {
                    var record = (from c in obj.Users
                                  where c.UserName == username && c.Password == password
                                  select c).First();

                    if (record == null)
                        return false;
                    else
                        return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool AddUser(User newuser)
        {
            try
            {
                obj.Users.Add(newuser);
                obj.SaveChanges();
                return true;

            }

            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
