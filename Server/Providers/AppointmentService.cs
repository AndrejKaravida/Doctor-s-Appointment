using Common.AppModels;
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
    public class AppointmentService : IAppointmentService
    {
        ILogger log = Logger.Instance;
        IAppointmentDB manager = new AppointmentDB();
        object x = new object();
        public bool Add(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.AddAppointment(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Add appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Add appointment executed unsuccesfuly.");
                return false;
            }
        }
        public bool CheckExisting()
        {
            log.LogMessage(LOG_TYPE.INFO, "Checking existing User data.");
            if (manager.GetAllAppointments().Count == 0)
                return true;
            else
                return false;

        }
        public bool Change(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.ChangeAppointment(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Change appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Change appointment executed unsuccesfuly.");
                return false;
            }
        }
       
        public bool ChangeForce(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.ChangeAppointmentForce(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Change appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Change appointment executed unsuccesfuly.");
                return false;
            }
        }

        public bool Clone(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.CloneAppointment(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Clone appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Clone appointment executed unsuccesfuly.");
                return false;
            }
        }

        public bool Delete(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.DeleteAppointment(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Delete appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Delete appointment executed unsuccesfuly.");
                return false;
            }
        }
        public bool DeleteForce(AppAppointment appointment)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.DeleteAppointmentForce(appointment);
                    log.LogMessage(LOG_TYPE.INFO, "Delete appointment executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Delete appointment executed unsuccesfuly.");
                return false;
            }
        }

        public BindingList<AppAppointment> GetAll()
        {
            log.LogMessage(LOG_TYPE.INFO, "Get All appointments executed succesfuly.");
            return manager.GetAllAppointments();
        }

        public BindingList<AppAppointment> Search(DateTime dateTime,string condition)
        {
            log.LogMessage(LOG_TYPE.INFO, "Get searched appointments executed succesfuly.");
            return manager.Search(dateTime,condition);
        }

        public AppAppointment GetLast()
        {
            log.LogMessage(LOG_TYPE.INFO, "Get last appointment executed succesfuly.");
            return manager.GetLast();
        }

        public AppAppointment GetOne(int id)
        {
            log.LogMessage(LOG_TYPE.INFO, "Get last appointment executed succesfuly.");
            return manager.GetOne(id);
        }
    }
}
