  using Client.Adition;
using Client.Views;
using Common.AppModel;
using Common.AppModels;
using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public Window Window { get; set; }
        string adminVisibility;


        public string AdminVisibility
        {
            get { return adminVisibility; }
            set
            {
                adminVisibility = value;
                OnPropertyChanged("AdminVisibility");
            }
        }
        string doctorVisibility;


        public string DoctorVisibility
        {
            get { return doctorVisibility; }
            set
            {
                doctorVisibility = value;
                OnPropertyChanged("DoctorVisibility");
            }
        }

    

        private BindingList<Log> loggers { get; set; }
        public BindingList<Log> Loggers
        {
            get
            {
                return loggers;
            }
            set
            {
                loggers = value;
                OnPropertyChanged("Loggers");
            }
        }

        private BindingList<AppAppointment> appointments { get; set; }
        public BindingList<AppAppointment> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                appointments = value;
                OnPropertyChanged("Appointments");
            }
        }
        private BindingList<string> dateConditionContent { get; set; }
        public BindingList<string> DateConditionContent
        {
            get
            {
                return dateConditionContent;
            }
            set
            {
                dateConditionContent = value;
                OnPropertyChanged("DateConditionContent");
            }
        }

        private string selectedDateContent;
        public string SelectedDateContent
        {
            get { return selectedDateContent; }
            set
            {
                selectedDateContent = value;
                OnPropertyChanged("SelectedDateContent");
            }
        }
     

        public AppAppointment SelectedAppointment { get; set; }
        public MyICommand AddUserCommand { get; set; }
        public MyICommand ChangeInfoCommand { get; set; }
        public MyICommand LogoutCommand { get; set; }

        public MyICommand AddAppointmentCommand { get; set; }

        public MyICommand ChangeAppointmentCommand { get; set; }

        public MyICommand AddDiagnosisCommand { get; set; }

        public MyICommand ChangeDiagnosisCommand { get; set; }

        public MyICommand DeleteAppointmentCommand { get; set; }

        public DateTime DateContent { get; set; }
        public MyICommand SearchCommand { get; set; }
        public MyICommand UndoCommand { get; set; }
        public MyICommand RedoCommand { get; set; }
        public MyICommand RefreshCommand { get; set; }

        public MyICommand CloneAppointmentCommand { get; set; }

        public static MyICommand Refresh { get; set; }
        public MainWindowViewModel()
        {
            DateConditionContent = new BindingList<string>() { "<", "=", ">" };
            DateContent = DateTime.Now;
            Appointments = Channel.Instance.AppointmentProxy.GetAll();
            LoggerHelper.Instance.MainWindowViewModel = this;
            Loggers = new BindingList<Log>();
            
            if (CurrentUser.Instance.Type == USER_TYPE.ADMIN)
            {
                AdminVisibility = "Visible";
                DoctorVisibility = "Hidden";
                AddUserCommand = new MyICommand(OnAddUser);
            }
            else if(CurrentUser.Instance.Type == USER_TYPE.DOCTOR)
            {
                DoctorVisibility = "Visible";
                AdminVisibility = "Hidden";
            }
            else
            {
                DoctorVisibility = "Hidden";
                AdminVisibility = "Hidden";
            }
            ChangeInfoCommand = new MyICommand(OnChangeInfo);
            LogoutCommand = new MyICommand(OnLogout);
            AddAppointmentCommand = new MyICommand(OnAddAppointment);
            ChangeAppointmentCommand = new MyICommand(OnChangeAppointment);
            AddDiagnosisCommand = new MyICommand(OnAddDiagnosis);
            ChangeDiagnosisCommand = new MyICommand(OnChangeDiagnosis);
            DeleteAppointmentCommand = new MyICommand(OnDeleteAppointmentExecute, OnDeleteAppointmentUnExecute);
            CloneAppointmentCommand = new MyICommand(OnCloneAppointment);
            SearchCommand = new MyICommand(OnSearch);
            RefreshCommand = new MyICommand(OnRefresh);
            Refresh = new MyICommand(OnRefresh);
            UndoCommand = new MyICommand(OnUndo);
            RedoCommand = new MyICommand(OnRedo);
        }

        public void OnSearch(object parameter)
        {
            if (SelectedDateContent != null && (DateContent != null || DateContent.ToString() != ""))
            {
                try
                {
                    Appointments = Channel.Instance.AppointmentProxy.Search(DateContent, SelectedDateContent);
                }
                catch
                {
                    DateContent = DateTime.Now;
                    SelectedDateContent = null;
                    DateConditionContent = new BindingList<string>() { "<", "=", ">" };
                }


            }
        }
        public void OnCloneAppointment(object parameter)
        {
            if (SelectedAppointment != null)
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO ,"Clone Appointment started.");
                if (Channel.Instance.AppointmentProxy.Clone(SelectedAppointment))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Clone Appointment success.");
                }
                else
                {

                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Clone Appointment unsuccess.");
                }

                OnRefresh(null);
            }
        }

        public bool CanUndo
        {
            get
            {
                if (CommandHandler.Instance.undoCommands.Count != 0)
                    return true;
                else
                    return false;
            }
        }

        public void OnUndo(object parameter)
        {
            LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Undo operation.");
            if (CanUndo)
            {
                CommandHandler.Instance.Undo();
            }
        }



        public bool CanRedo
        {
            get
            {
                if (CommandHandler.Instance.redoCommands.Count != 0)
                    return true;
                else
                    return false;
            }
        }




        public void OnRedo(object parameter)
        {
            LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Redo operation.");
            if (CanRedo)
            {
                CommandHandler.Instance.Redo();
            }
        }
        public void OnRefresh(object parameter)
        {
            DateContent = DateTime.Now;
            DateConditionContent = null;
            DateConditionContent = new BindingList<string>() { "<", "=", ">" };

            Appointments = Channel.Instance.AppointmentProxy.GetAll();
        }

        public void OnDeleteAppointmentExecute(object parameter)
        {

            if (parameter == null)
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Delete Appointment command.");
                
                if (Channel.Instance.AppointmentProxy.Delete(SelectedAppointment))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Delete Appointment command done.");

                    CommandHandler.Instance.AddAndExecute(DeleteAppointmentCommand, SelectedAppointment);
                    Refresh.Execute(null);
                
                }
                else
                {
                    if (MessageBox.Show("Would you like to override it?", "Appointment modified or deleted", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (Channel.Instance.AppointmentProxy.DeleteForce(SelectedAppointment))
                        {
                            LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Force delete Appointment command done.");
                            CommandHandler.Instance.AddAndExecute(DeleteAppointmentCommand, SelectedAppointment);

                        }
                    }
                    else
                    {
                        LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Delete Appointment command not done.");
                    }
                    MainWindowViewModel.Refresh.Execute(null);
                }

            }
            else
            {
                if (Channel.Instance.AppointmentProxy.DeleteForce((AppAppointment)parameter))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Delete Appointment command redo done.");
                    CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = new AppAppointment((AppAppointment)parameter);
                    MainWindowViewModel.Refresh.Execute(null);
                }
            }
        }

        public void OnDeleteAppointmentUnExecute(object parameter)
        {
            if (Channel.Instance.AppointmentProxy.Add((AppAppointment)parameter))
            {

                AppAppointment appointment = Channel.Instance.AppointmentProxy.GetOne(((AppAppointment)parameter).AppointmentId);

                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Delete Appointment command undo done.");
                CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = new AppAppointment(appointment);
                MainWindowViewModel.Refresh.Execute(null);
            }
        }

     

        public void OnLogout(object parameter)
        {
            CurrentUser.Instance = null;
            new Login().Show();
            Window.Close();
        }
        public void OnAddUser(object parameter)
        {
            new AddChangeUser(null).ShowDialog();
        }

        public void OnAddAppointment(object parameter)
        {
            new AddChangeAppointment(null).ShowDialog();
        }

        public void OnChangeAppointment(object parameter)
        {
            if (SelectedAppointment != null)
            {
                new AddChangeAppointment(SelectedAppointment).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select appointment first");
            }

        }

        public void OnAddDiagnosis(object parameter)
        {
            if (SelectedAppointment != null)
            {
                new AddChangeDiagnosis(SelectedAppointment).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select appointment first");
            }
          
        }

        public void OnChangeDiagnosis(object parameter)
        {
            if (SelectedAppointment != null)
            {
                new AddChangeDiagnosis(SelectedAppointment).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select appointment first");
            }

        }

        public void OnChangeInfo(object parameter)
        {
            new AddChangeUser(CurrentUser.Instance).ShowDialog();
        }

    }
}
