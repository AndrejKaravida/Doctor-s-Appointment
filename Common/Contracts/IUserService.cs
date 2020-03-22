using Common.AppModel;
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
    public interface IUserService
    {
        [OperationContract]
        AppUser Login(string username, string password);

        [OperationContract]
        bool AddUser(AppUser user);

        [OperationContract]
        bool ChangeInfo(AppUser user);

        [OperationContract]
        BindingList<string> GetPatients();

        [OperationContract]
        BindingList<string> GetDoctors();
    }
}
