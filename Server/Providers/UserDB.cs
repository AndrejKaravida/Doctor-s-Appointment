using Common.AppModel;
using Common.Contracts;
using Common.Models;
using Server.DBAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Providers
{
    public class UserDB : IUserDB
    {
        #region User
        public bool AddUser(AppUser user)
        {
            user.Username = user.Username.ToLower();
            using (var dbContext = new Context())
            {
                foreach (User u in dbContext.Users)
                {
                    if (u.Username.ToLower() == user.Username.ToLower())
                        return false;

                }

                dbContext.Users.Add(new User(user));
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool ChangeInfo(AppUser user)
        {
            user.Username = user.Username.ToLower();
            using (var dbContext = new Context())
            {
                foreach (User u in dbContext.Users)
                {
                    if (u.Username.ToLower() == user.Username.ToLower())
                    {
                        u.FirstName = user.FirstName;
                        u.LastName = user.LastName;
                        u.Password = user.Password;
                        break;
                    }


                }


                dbContext.SaveChanges();
                return true;
            }
        }

        public AppUser Login(string username, string password)
        {
            using (var dbContext = new Context())
            {
                foreach (User user in dbContext.Users)
                {
                    if (username.ToLower() == user.Username.ToLower() && password == user.Password)
                    {

                        return new AppUser(user);
                    }
                }
                return null;
            }
        }

        public int GetCount()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Users.Count();
            }
        }

        public BindingList<string> GetPatients()
        {
            BindingList<string> retVal = new BindingList<string>();
            using (var dbContext = new Context())
            {
                foreach (User item in dbContext.Users)
                {
                    if(item.Type == USER_TYPE.PATIENT)
                        retVal.Add(item.Username);
                }
            }
            return retVal;
        }

        public BindingList<string> GetDoctors()
        {
            BindingList<string> retVal = new BindingList<string>();
            using (var dbContext = new Context())
            {
                foreach (User item in dbContext.Users)
                {
                    if (item.Type == USER_TYPE.DOCTOR)
                        retVal.Add(item.Username);
                }
            }
            return retVal;
        }

        #endregion
    }
}
