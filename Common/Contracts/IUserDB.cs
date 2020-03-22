using Common.AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IUserDB
    {
        bool AddUser(AppUser user);
        bool ChangeInfo(AppUser user);
        AppUser Login(string username, string password);
        int GetCount();
        BindingList<string> GetPatients();
        BindingList<string> GetDoctors();
    }
}
