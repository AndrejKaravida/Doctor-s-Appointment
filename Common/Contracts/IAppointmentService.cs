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
    [ServiceContract]
    public interface IAppointmentService
    {
        [OperationContract]
        bool Add(AppAppointment appointment);

        [OperationContract]
        bool ChangeForce(AppAppointment appointment);

        [OperationContract]
        bool DeleteForce(AppAppointment appointment);


        [OperationContract]
        bool Change(AppAppointment appointment);
        [OperationContract]
        AppAppointment GetLast();

        [OperationContract]
        AppAppointment GetOne(int id);

        [OperationContract]
        bool Delete(AppAppointment appointment);

        [OperationContract]
        bool Clone(AppAppointment appointment);

        [OperationContract]
        BindingList<AppAppointment> GetAll();

        [OperationContract]
        BindingList<AppAppointment> Search(DateTime dateTime, string condition);
    }
}
