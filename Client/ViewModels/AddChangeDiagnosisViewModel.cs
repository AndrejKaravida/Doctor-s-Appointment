using Client.Adition;
using Common.AppModels;
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
    public class AddChangeDiagnosisViewModel : BindableBase
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
        string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public MyICommand AddChangeDiagnosisCommand { get; set; }

        public AddChangeDiagnosisViewModel(AppAppointment appointment)
        {
            Appointment = appointment;

            if (appointment.DiagnosisId == "-1")
            {
                Description = "";
                TitleContent = "ADD";
                AddChangeDiagnosisCommand = new MyICommand(OnAddDiagnosis);
            }
            else
            {
                Description = Appointment.Diagnosis;
                TitleContent = "CHANGE";


                AddChangeDiagnosisCommand = new MyICommand(OnChangeDiagnosis);
            }
        }

        public void OnAddDiagnosis(object parameter)
        {
            if(Description != "")
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Diagnosis started.");
                if(Channel.Instance.DiagnosisProxy.Add(Appointment.AppointmentId, description))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Diagnosis success.");
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Add Diagnosis unsuccess.");
                }
            }
            else
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.WARN, "Add Diagnosis didn't executed.");
            }
            MainWindowViewModel.Refresh.Execute(null);
            Window.Close();
        }
        public void OnChangeDiagnosis(object parameter)
        {
            if (Description != "")
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Diagnosis started.");
                if (Channel.Instance.DiagnosisProxy.Add(Appointment.AppointmentId, description))
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.INFO, "Add Diagnosis success.");
                }
                else
                {
                    LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.ERROR, "Add Diagnosis unsuccess.");
                }
            }
            else
            {
                LoggerHelper.Instance.LogManagerLogging(LOG_TYPE.WARN, "Change Diagnosis didn't executed.");
            }
            MainWindowViewModel.Refresh.Execute(null);
            Window.Close();
        }
    }
}
