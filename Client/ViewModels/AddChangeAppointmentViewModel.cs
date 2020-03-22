using Client.Adition;
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
    class AddChangeAppointmentViewModel : BindableBase
    {
        public Window Window { get; set; }

        AppAppointment appointment = new AppAppointment();
        public AppAppointment Appointment
        {
            get { return appointment; }
            set
            {
                appointment = value;
                OnPropertyChanged("Appointment");
            }
        }
        string patientVisible;
        public string PatientVisible
        {
            get { return patientVisible; }
            set
            {
                patientVisible = value;
                OnPropertyChanged("PatientVisible");
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
        string hour;
        public string Hour
        {
            get { return hour; }
            set
            {
                hour = value;
                OnPropertyChanged("Hour");
            }
        }
        BindingList<string> hours = new BindingList<string>();

        public BindingList<string> Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged("Hours");
            }
        }
        BindingList<string> doctors = new BindingList<string>();

        public BindingList<string> Doctors
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertyChanged("Doctors");
            }
        }
       
        BindingList<string> patients = new BindingList<string>();

        public BindingList<string> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged("Patients");
            }
        }

        public MyICommand AddChangeAppointmentCommand { get; set; }
        AppAppointment oldAppointment;
        public AddChangeAppointmentViewModel(AppAppointment appointment)
        {
            
            Hours = new BindingList<string>() {"8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", };
            Doctors = Channel.Instance.UserProxy.GetDoctors();
            Patients = Channel.Instance.UserProxy.GetPatients();
            if (appointment == null)
            {
                if (CurrentUser.Instance.Type == USER_TYPE.PATIENT)
                {
                    PatientVisible = "Hidden";
                    Appointment.Patient = CurrentUser.Instance.Username;
                }
                else
                {
                    PatientVisible = "Visible";
                }
                Appointment = new AppAppointment();
                Appointment.AppointmentTime = DateTime.Now;
                TitleContent = "ADD";
                AddChangeAppointmentCommand = new MyICommand(OnAddAppointmentExecute, OnAddAppointmentUnExecute);
            }
            else
            {
                Hour = appointment.AppointmentTime.TimeOfDay.ToString().Split(':')[0]+":"+ appointment.AppointmentTime.TimeOfDay.ToString().Split(':')[1];
                TitleContent = "CHANGE";
                Appointment = appointment;
                oldAppointment = new AppAppointment(appointment);
                AddChangeAppointmentCommand = new MyICommand(OnChangeAppointmentExecute, OnChangeAppointmentUnExecute);
            }
        }
      
        public void OnAddAppointmentExecute(object parameter)
        {
            if (parameter == null)
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Appointment command.");
                if (string.IsNullOrEmpty(Hour) || string.IsNullOrWhiteSpace(Hour))
                    Appointment.AppointmentTime = new DateTime();

                Appointment.Validate();
                if (Appointment.IsValid)
                {
                    Appointment.AppointmentTime = new DateTime(Appointment.AppointmentTime.Year, Appointment.AppointmentTime.Month, Appointment.AppointmentTime.Day, int.Parse(Hour.Split(':')[0]), int.Parse(Hour.Split(':')[1]), 0);
                    
                   
                    if (Channel.Instance.AppointmentProxy.Add(Appointment))
                    {
                        LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Appointment command done.");
                        AppAppointment appointment = Channel.Instance.AppointmentProxy.GetLast();
                        CommandHandler.Instance.AddAndExecute(AddChangeAppointmentCommand, appointment);
                        MainWindowViewModel.Refresh.Execute(null);
                        Window.Close();
                    }
                    else
                    {
                        LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Add Appointment command (Id alredy exists) not done.");
                    }
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Add Appointment command (Appointment info not valid) not done.");
                }
            }
            else
            {
                if (Channel.Instance.AppointmentProxy.Add((AppAppointment)parameter))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Appointment command redo done.");
                    AppAppointment appointment = Channel.Instance.AppointmentProxy.GetLast();
                    CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = new AppAppointment(appointment);
                    MainWindowViewModel.Refresh.Execute(null);
                }
            }
        }
        public void OnAddAppointmentUnExecute(object parameter)
        {
            if (Channel.Instance.AppointmentProxy.DeleteForce((AppAppointment)parameter))
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Appointment command undo done.");
                CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = new AppAppointment((AppAppointment)parameter);
                MainWindowViewModel.Refresh.Execute(null);
            }
        }

        public void OnChangeAppointmentExecute(object parameter)
        {
            if (parameter == null)
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change Appointment command.");
                if (string.IsNullOrEmpty(Hour) || string.IsNullOrWhiteSpace(Hour))
                    Appointment.AppointmentTime = new DateTime();

                Appointment.Validate();
                if (Appointment.IsValid)
                {
                    Appointment.AppointmentTime = new DateTime(Appointment.AppointmentTime.Year, Appointment.AppointmentTime.Month, Appointment.AppointmentTime.Day, int.Parse(Hour.Split(':')[0]), int.Parse(Hour.Split(':')[1]), 0);

                    if (Channel.Instance.AppointmentProxy.Change(Appointment))
                    {
                        LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change Appointment command done.");
                      
                        CommandHandler.Instance.AddAndExecute(AddChangeAppointmentCommand, oldAppointment);
                        MainWindowViewModel.Refresh.Execute(null);
                        Window.Close();
                    }
                    else
                    {
                        if (MessageBox.Show("Would you like to override it?", "Appointment modified or deleted", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (Channel.Instance.AppointmentProxy.ChangeForce(Appointment))
                            {
                                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Force Change Appointment command done.");
                                CommandHandler.Instance.AddAndExecute(AddChangeAppointmentCommand, oldAppointment);

                            }
                        }
                        else
                        {
                            LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Change Appointment command not done.");
                        }
                        MainWindowViewModel.Refresh.Execute(null);
                    }
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Change Appointment command (Appointment info not valid) not done.");
                }
            }
            else
            {
                AppAppointment appointment = Channel.Instance.AppointmentProxy.GetOne(((AppAppointment)parameter).AppointmentId);

                if (Channel.Instance.AppointmentProxy.ChangeForce((AppAppointment)parameter))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change Appointment command redo done.");
                    CommandHandler.Instance.undoObjects[CommandHandler.Instance.undoObjects.Count - 1] = new AppAppointment(appointment);
                    MainWindowViewModel.Refresh.Execute(null);
                }
            }
        }
        public void OnChangeAppointmentUnExecute(object parameter)
        {
            AppAppointment appointment = Channel.Instance.AppointmentProxy.GetOne(((AppAppointment)parameter).AppointmentId);

            if (Channel.Instance.AppointmentProxy.ChangeForce((AppAppointment)parameter))
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Change Appointment command undo done.");
                CommandHandler.Instance.redoObjects[CommandHandler.Instance.redoObjects.Count - 1] = new AppAppointment(appointment);
                MainWindowViewModel.Refresh.Execute(null);
            }
        }
    }
}
