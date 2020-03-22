using Common.AppModel;
using Common.AppModels;
using Common.Models;
using Server.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Initial
    {
        public Initial()
        {
            CheckAndFillData();
        }
        private void CheckAndFillData()
        {
            UserService userService = new UserService();
            if (userService.CheckExisting())
            {
                userService.AddUser(new AppUser { FirstName = "admin", Username = "admin", LastName = "admin", Password = "admin", Type = USER_TYPE.ADMIN });
                userService.AddUser(new AppUser { FirstName = "doctor1", Username = "doctor1", LastName = "doctor1", Password = "doctor1", Type = USER_TYPE.DOCTOR });
                userService.AddUser(new AppUser { FirstName = "doctor2", Username = "doctor2", LastName = "doctor2", Password = "doctor2", Type = USER_TYPE.DOCTOR });
                userService.AddUser(new AppUser { FirstName = "doctor3", Username = "doctor3", LastName = "doctor3", Password = "doctor3", Type = USER_TYPE.DOCTOR });
                userService.AddUser(new AppUser { FirstName = "doctor4", Username = "doctor4", LastName = "doctor4", Password = "doctor4", Type = USER_TYPE.DOCTOR });
                userService.AddUser(new AppUser { FirstName = "patient1", Username = "patient1", LastName = "patient1", Password = "patient1", Type = USER_TYPE.PATIENT });
                userService.AddUser(new AppUser { FirstName = "patient2", Username = "patient2", LastName = "patient2", Password = "patient2", Type = USER_TYPE.PATIENT });
                userService.AddUser(new AppUser { FirstName = "patient3", Username = "patient3", LastName = "patient3", Password = "patient3", Type = USER_TYPE.PATIENT });
                userService.AddUser(new AppUser { FirstName = "patient4", Username = "patient4", LastName = "patient4", Password = "patient4", Type = USER_TYPE.PATIENT });
            }

            AppointmentService appointmentService = new AppointmentService();
            if (appointmentService.CheckExisting())
            {
                appointmentService.Add(new AppAppointment() { Doctor = "doctor1",Patient = "patient1", AppointmentTime = DateTime.Now, DiagnosisId = "-1"});
                appointmentService.Add(new AppAppointment() { Doctor = "doctor2", Patient = "patient2", AppointmentTime = DateTime.Now, DiagnosisId = "-1" });
                appointmentService.Add(new AppAppointment() { Doctor = "doctor3", Patient = "patient3", AppointmentTime = DateTime.Now, DiagnosisId = "-1" });
                appointmentService.Add(new AppAppointment() { Doctor = "doctor4", Patient = "patient4", AppointmentTime = DateTime.Now, DiagnosisId = "-1" });


            }

            DiagnosisService diagnosisService  = new DiagnosisService();
            if (diagnosisService.CheckExisting())
            {
                diagnosisService.Add(1,"Diagnosis1");
                diagnosisService.Add(2, "Diagnosis2");
                diagnosisService.Add(3, "Diagnosis3");
                diagnosisService.Add(4, "Diagnosis4");
            }


        }
    }
}
