using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AppModels
{
    public class AppAppointment : ValidationBase
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string DiagnosisId { get; set; }
        public string Diagnosis { get; set; }
        public DateTime TimeStamp { get; set; }
        public AppAppointment() { }

        public AppAppointment(AppAppointment appointment)
        {
            this.Id = appointment.Id;
            this.AppointmentId = appointment.AppointmentId;
            this.Patient = appointment.Patient;
            this.Doctor = appointment.Doctor;
            this.AppointmentTime = appointment.AppointmentTime;
            this.TimeStamp = appointment.TimeStamp;
            try
            {
                this.DiagnosisId = appointment.DiagnosisId;
            }
            catch { }
        }

        public AppAppointment(Appointment appointment)
        {
            this.Id = appointment.Id;
            this.AppointmentId = appointment.AppointmentId;
            this.Patient = appointment.Patient;
            this.Doctor = appointment.Doctor;
            this.AppointmentTime = appointment.AppointmentTime;
            this.TimeStamp = appointment.TimeStamp;
            try
            {
                this.DiagnosisId = appointment.DiagnosisId.ToString();
            }
            catch { }
        }
        protected override void ValidateSelf()
        {
           

            if (string.IsNullOrWhiteSpace(this.Patient.ToString()) || String.IsNullOrEmpty(Patient.ToString()))
            {
                this.ValidationErrors["Patient"] = "Patient cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(this.Doctor.ToString()) || String.IsNullOrEmpty(Doctor.ToString()))
            {
                this.ValidationErrors["Doctor"] = "Doctor cannot be empty.";
            }
            if (string.IsNullOrWhiteSpace(this.AppointmentTime.ToString()) || String.IsNullOrEmpty(AppointmentTime.ToString()))
            {
                this.ValidationErrors["AppointmentTime"] = "AppointmentTime cannot be empty.";
            }
            else if(this.AppointmentTime < DateTime.Now)
            {
                this.ValidationErrors["AppointmentTime"] = "AppointmentTime cannot be in history.";
            }
        }
    }
}
