using Common.AppModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    
    public interface IAppointmentDB
    {
        bool AddAppointment(AppAppointment appointment);

        bool ChangeAppointment(AppAppointment appointment);
        bool ChangeAppointmentForce(AppAppointment appointment);

        bool DeleteAppointment(AppAppointment appointment);
        bool DeleteAppointmentForce(AppAppointment appointment); 

        bool CloneAppointment(AppAppointment appointment);
        AppAppointment GetLast();
        AppAppointment GetOne(int id);

        BindingList<AppAppointment> GetAllAppointments();
        BindingList<AppAppointment> Search(DateTime dateTime, string condition);
    }
}
