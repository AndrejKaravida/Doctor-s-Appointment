using Common.AppModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Appointment : Prototype
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int DiagnosisId { get; set; }
        public DateTime TimeStamp { get; set; }

        public Appointment() { }

        public Appointment(Appointment appointment)
        {
            this.Id = appointment.Id;
            this.AppointmentId = appointment.AppointmentId;
            this.Patient = appointment.Patient;
            this.Doctor = appointment.Doctor;
            this.AppointmentTime = appointment.AppointmentTime;
            try
            {
                this.DiagnosisId = appointment.DiagnosisId;
            }
            catch { }
            this.TimeStamp = appointment.TimeStamp;
        }

        public Appointment(AppAppointment appointment)
        {
            this.Id = appointment.Id;
            this.AppointmentId = appointment.AppointmentId;
            this.Patient = appointment.Patient;
            this.Doctor = appointment.Doctor;
            this.AppointmentTime = appointment.AppointmentTime;
            try
            {
                this.DiagnosisId = int.Parse(appointment.DiagnosisId);
            }
            catch { }
            
            this.TimeStamp = appointment.TimeStamp;
        }
        public override Prototype Clone()
        {
            return (Appointment)this.MemberwiseClone();
        }
    }
}
