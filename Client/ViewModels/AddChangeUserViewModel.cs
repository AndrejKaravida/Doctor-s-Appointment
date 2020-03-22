using Client.Adition;
using Common.AppModel;
using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class AddChangeUserViewModel : BindableBase
    {
        public Window Window { get; set; }
        AppUser user;
        public AppUser User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        string checkUsername;

        public string CheckUsername
        {
            get { return checkUsername; }
            set
            {
                checkUsername = value;
                OnPropertyChanged("CheckUsername");
            }
        }
        bool isDoctor;

        public bool IsDoctor
        {
            get { return isDoctor; }
            set
            {
                isDoctor = value;
                OnPropertyChanged("IsDoctor");
            }
        }
        
            string checkBoxVisible;

        public string CheckBoxVisible
        {
            get { return checkBoxVisible; }
            set
            {
                checkBoxVisible = value;
                OnPropertyChanged("CheckBoxVisible");
            }
        }
        string titleContent;

        public string TitleContent
        {
            get { return titleContent; }
            set
            {
                titleContent = value;
                OnPropertyChanged("TitleContent");
            }
        }

        public MyICommand AddChangeUserCommand { get; set; }

        public AddChangeUserViewModel(AppUser user)
        {
            if(user == null)
            {
                CheckBoxVisible = "Visible";
                User = new AppUser();
                AddChangeUserCommand = new MyICommand(OnAddUser);
                TitleContent = "ADD";
            }
            else
            {
                CheckBoxVisible = "Hidden";
                User = user;
                AddChangeUserCommand = new MyICommand(OnChangeUser);
                TitleContent = "CHANGE";
            }
        }

        public void OnAddUser(object parameter)
        {
            CheckUsername = "";
            User.Validate();

            if (User.IsValid)
            {
                if (IsDoctor)
                    User.Type = USER_TYPE.DOCTOR;
                else
                    User.Type = USER_TYPE.PATIENT;


                if (Channel.Instance.UserProxy.AddUser(User))
                {
                    MessageBox.Show("Success");
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add User info command done.");

                    Window.Close();
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Add User info command (username alredy exists) not done.");
                    CheckUsername = "Username alredy exists.";
                }
            }
        }

        public void OnChangeUser(object parameter)
        {
            LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change User info command.");

            CheckUsername = "";
            User.Validate();

            if (User.IsValid)
            {
                if (Channel.Instance.UserProxy.ChangeInfo(User))
                {
                    MessageBox.Show("Success");
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change User info command done.");

                    CurrentUser.Instance.FirstName = User.FirstName;
                    CurrentUser.Instance.LastName = User.LastName;
                    CurrentUser.Instance.Username = User.Username;
                    CurrentUser.Instance.Password = User.Password;

                    Window.Close();
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Change User info command not done.");
                }
            }
            else
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Change User info command (User info not valid) not done.");
            }
        }
    }
}
