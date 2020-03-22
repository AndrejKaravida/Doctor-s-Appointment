
using Client.Adition;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public Window Window { get; set; }


        private string username;
        private string password;

        private string errorUsername;
        private string errorPassword;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string ErrorUsername
        {
            get { return errorUsername; }
            set
            {
                errorUsername = value;
                OnPropertyChanged("ErrorUsername");
            }
        }

        public string ErrorPassword
        {
            get { return errorPassword; }
            set
            {
                errorPassword = value;
                OnPropertyChanged("ErrorPassword");
            }
        }

        public MyICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new MyICommand(OnLogin);
        }

        public void OnLogin(object parameter)
        {
            errorPassword = "";

            if (String.IsNullOrWhiteSpace(Username))
                ErrorUsername = "Username can't be empty.";
            else
                ErrorUsername = "";
            if (String.IsNullOrWhiteSpace(Password))
                ErrorPassword = "Password can't be empty.";
            else
                ErrorPassword = "";
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password))
            {
                CurrentUser.Instance = Channel.Instance.UserProxy.Login(Username, Password);
                if (!String.IsNullOrWhiteSpace(CurrentUser.Instance.Username))
                {
                    new MainWindow().Show();
                    Window.Close();
                }
                else
                {

                    ErrorPassword = "Username and password doesn't match.";
                    CurrentUser.Instance = null;
                }
            }
        }
    }
}
