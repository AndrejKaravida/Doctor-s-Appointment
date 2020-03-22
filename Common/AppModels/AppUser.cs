using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.AppModel
{
    [DataContract]
    public class AppUser : ValidationBase
    {
        #region Fields

        [DataMember]
        public String Username { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public USER_TYPE Type { get; set; }
        #endregion

        #region Constructor
        public AppUser() { }

        public AppUser(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Type = user.Type;
        }

        public AppUser(AppUser user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Type = user.Type;
        }
        public AppUser(String userName, String password)
        {
            Username = userName;
            Password = password;
        }
        #endregion

        #region Strategy pattern

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.FirstName) || String.IsNullOrEmpty(FirstName))
            {
                this.ValidationErrors["FirstName"] = "Name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(this.LastName) || String.IsNullOrEmpty(LastName))
            {
                this.ValidationErrors["LastName"] = "LastName cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(this.Username) || String.IsNullOrEmpty(Username))
            {
                this.ValidationErrors["Username"] = "Username cannot be empty.";
            }

            if (this.Username.Count() < 5)
            {
                this.ValidationErrors["Username"] = "Username must have at least 5 characters.";
            }

            if (this.Password.Count() < 5)
            {
                this.ValidationErrors["Password"] = "Username must have at least 5 characters.";
            }

            if (string.IsNullOrWhiteSpace(this.Password) || String.IsNullOrEmpty(Password))
            {
                this.ValidationErrors["Password"] = "Password cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(this.Type.ToString()) || String.IsNullOrEmpty(Type.ToString()))
            {
                this.ValidationErrors["Type"] = "Type cannot be empty.";
            }
        }
        #endregion

    }
}
