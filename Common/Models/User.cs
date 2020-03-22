using Common.AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class User
    {
        #region Fields

        [Key]
        public String Username { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public USER_TYPE Type { get; set; }
        #endregion

        #region Constructor
        public User() { }

        public User(AppUser user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Type = user.Type;
        }
        public User(String userName, String password)
        {
            Username = userName;
            Password = password;
        }
        #endregion

    }
}
