using Common.AppModel;
using Common.Contracts;
using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Providers
{
    class UserService : IUserService
    {
        ILogger log = Logger.Instance;
        IUserDB manager = new UserDB();
        object x = new object();
        public bool AddUser(AppUser user)
        {
            try
            {
                lock (x)
                {
                    bool retVal = manager.AddUser(user);
                    log.LogMessage(LOG_TYPE.INFO, "Add User executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Add User executed unsuccesfuly.");
                return false;
            }
        }

        public bool ChangeInfo(AppUser user)
        {
            try
            {
                lock (x)
                {
                    bool retVal = manager.ChangeInfo(user);
                    log.LogMessage(LOG_TYPE.INFO, "Change User executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Change User executed unsuccesfuly.");
                return false;
            }
        }

        public AppUser Login(string username, string password)
        {

            try
            {
                AppUser retVal = manager.Login(username, password);
                log.LogMessage(LOG_TYPE.INFO, "Login User executed succesfuly.");
                return retVal;

            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Login User executed unsuccesfuly.");
                return null;
            }
        }

       
        public bool CheckExisting()
        {
            log.LogMessage(LOG_TYPE.INFO, "Checking existing User data.");
            if (manager.GetCount() == 0)
                return true;
            else
                return false;

        }

        public BindingList<string> GetPatients()
        {
            try
            {
                BindingList<string> retVal = manager.GetPatients();
                log.LogMessage(LOG_TYPE.INFO, "Get Patients executed succesfuly.");
                return retVal;

            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Get Patients executed unsuccesfuly.");
                return null;
            }
        }

        public BindingList<string> GetDoctors()
        {
            try
            {
                BindingList<string> retVal = manager.GetDoctors();
                log.LogMessage(LOG_TYPE.INFO, "Get Doctors executed succesfuly.");
                return retVal;

            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Get Doctors executed unsuccesfuly.");
                return null;
            }
        }
    }
   
}
