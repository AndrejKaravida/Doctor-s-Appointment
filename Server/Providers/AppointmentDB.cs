using Common.AppModels;
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
    public class AppointmentDB : IAppointmentDB
    {
        public bool AddAppointment(AppAppointment appointment)
        {
            try
            {
                appointment.DiagnosisId = (appointment.DiagnosisId == "0") ? "-1" : appointment.DiagnosisId;
                Appointment app = new Appointment(appointment);
                int oldId = app.Id;
                using (var dbContext = new Context())
                {
                    foreach (Appointment item in dbContext.Appointments)
                    {
                        if (item.Id == app.Id)
                            return false;
                    }
                    app.TimeStamp = DateTime.Now;
                    dbContext.Appointments.Add(app);
                    dbContext.SaveChanges();
                    if (app.AppointmentId == 0)
                    {
                        app.AppointmentId = app.Id;
                        dbContext.SaveChanges();
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeAppointment(AppAppointment appointment)
        {
            Appointment app = new Appointment(appointment);
            bool found = false;
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == app.AppointmentId && item.TimeStamp == app.TimeStamp)
                    {
                        item.Doctor = app.Doctor;
                        item.AppointmentTime = app.AppointmentTime;
                        item.TimeStamp = DateTime.Now;
                        found = true;
                        break;
                       
                    }
                }
                if (found)
                {
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ChangeAppointmentForce(AppAppointment appointment)
        {
            Appointment app = new Appointment(appointment);
            bool found = false;
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == app.AppointmentId)
                    {
                        item.Doctor = app.Doctor;
                        item.DiagnosisId = app.DiagnosisId;
                        item.AppointmentTime = app.AppointmentTime;
                        found = true;
                        break;

                    }
                }
                if (found)
                {
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    dbContext.Appointments.Add(app);
                    dbContext.SaveChanges();
                    return true;
                }

            }
        }

        public bool CloneAppointment(AppAppointment appointment)
        {
            Appointment app = new Appointment(appointment);
            Appointment clonedApp = (Appointment)app.Clone();

            using (var context = new Context())
            {
                
                context.Appointments.Add(clonedApp);
                context.SaveChanges();
                clonedApp.AppointmentId = clonedApp.Id;
                context.SaveChanges();
            }

            return true;
        }

        public bool DeleteAppointment(AppAppointment appointment)
        {
            Appointment app = new Appointment(appointment);
            bool found = false;
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == app.AppointmentId && item.TimeStamp == app.TimeStamp)
                    {
                        app = item;
                        found = true;
                    }
                }
                if (found)
                {

                    dbContext.Appointments.Remove(app);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteAppointmentForce(AppAppointment appointment)
        {
            Appointment app = new Appointment(appointment);
            bool found = false;
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == app.AppointmentId)
                    {
                        app = item;
                        found = true;
                    }
                }
                if (found)
                {

                    dbContext.Appointments.Remove(app);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public BindingList<AppAppointment> GetAllAppointments()
        {
            BindingList<AppAppointment> retVal = new BindingList<AppAppointment>();
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    AppAppointment temp = new AppAppointment(item);
                    if (temp.DiagnosisId == "-1" || temp.DiagnosisId == "0")
                    {
                        temp.DiagnosisId = "-1";
                        temp.Diagnosis = "There is no diagnosis.";
                    }
                    else
                        temp.Diagnosis = dbContext.Diagnosis.ToList().Find(x => x.Id.ToString() == temp.DiagnosisId).Description;

                    retVal.Add(temp);
                }
            }

            return new BindingList<AppAppointment>( retVal.ToList().OrderBy(x=>x.AppointmentTime).ToList());
        }

        public BindingList<AppAppointment> Search(DateTime dateTime, string condition)
        {
            BindingList<AppAppointment> retVal = new BindingList<AppAppointment>();
            if (condition == "<")
            {
                
                using (var dbContext = new Context())
                {
                    foreach (Appointment item in dbContext.Appointments)
                    {
                        if (item.AppointmentTime <= dateTime)
                        {
                            AppAppointment temp = new AppAppointment(item);
                            if (temp.DiagnosisId == "-1" || temp.DiagnosisId == "0")
                            {
                                temp.DiagnosisId = "-1";
                                temp.Diagnosis = "There is no diagnosis.";
                            }
                            else
                                temp.Diagnosis = dbContext.Diagnosis.ToList().Find(x => x.Id.ToString() == temp.DiagnosisId).Description;

                            retVal.Add(temp);
                        }
                    }
                }

               
            }
            else if(condition == "=")
            {
               
                using (var dbContext = new Context())
                {
                    foreach (Appointment item in dbContext.Appointments)
                    {
                        if (item.AppointmentTime == dateTime)
                        {
                            AppAppointment temp = new AppAppointment(item);
                            if (temp.DiagnosisId == "-1" || temp.DiagnosisId == "0")
                            {
                                temp.DiagnosisId = "-1";
                                temp.Diagnosis = "There is no diagnosis.";
                            }
                            else
                                temp.Diagnosis = dbContext.Diagnosis.ToList().Find(x => x.Id.ToString() == temp.DiagnosisId).Description;

                            retVal.Add(temp);
                        }
                    }
                }
            }
            else if(condition == ">")
            {
                
                using (var dbContext = new Context())
                {
                    foreach (Appointment item in dbContext.Appointments)
                    {
                        if (item.AppointmentTime >= dateTime)
                        {
                            AppAppointment temp = new AppAppointment(item);
                            if (temp.DiagnosisId == "-1" || temp.DiagnosisId == "0")
                            {
                                temp.DiagnosisId = "-1";
                                temp.Diagnosis = "There is no diagnosis.";
                            }
                            else
                                temp.Diagnosis = dbContext.Diagnosis.ToList().Find(x => x.Id.ToString() == temp.DiagnosisId).Description;

                            retVal.Add(temp);
                        }
                    }
                }
            }

            return new BindingList<AppAppointment>(retVal.ToList().OrderBy(x => x.AppointmentTime).ToList());
        }

        public AppAppointment GetLast()
        {
            using (var dbContext = new Context())
            {
                return new AppAppointment( dbContext.Appointments.ToList().Last());
            }
        }

        public AppAppointment GetOne(int id)
        {
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == id)
                        return new AppAppointment(item);
                }

                return null;
            }
        }
    }
}
