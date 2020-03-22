using Common.Contracts;
using Common.Models;
using Server.DBAccess;
using System;
using System.Linq;

namespace Server.Providers
{
    public class DiagnosisDB : IDiagnosisDB
    {
        public bool AddDiagnosis(int appointmentId, string Description)
        {
            bool found = false;
            Diagnosis diagnosis = new Diagnosis();
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if(item.AppointmentId == appointmentId)
                    {
                        diagnosis = new Diagnosis() { Description = Description};
                        dbContext.Diagnosis.Add(diagnosis);
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    dbContext.SaveChanges();
                    foreach (Appointment item in dbContext.Appointments)
                    {
                        if (item.AppointmentId == appointmentId)
                        {
                            item.TimeStamp = DateTime.Now;
                            item.DiagnosisId = diagnosis.Id;
                        }
                    }
                    dbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public bool ChangeDiagnosis(int appointmentId, string Description)
        {
            using (var dbContext = new Context())
            {
                foreach (Appointment item in dbContext.Appointments)
                {
                    if (item.AppointmentId == appointmentId)
                    {
                        foreach (Diagnosis d in dbContext.Diagnosis)
                        {
                            if(d.Id == item.DiagnosisId)
                            {
                                item.TimeStamp = DateTime.Now;
                                d.Description = Description;
                                dbContext.SaveChanges();
                                return true;
                            }
                        }
                        break;
                    }

                }
                return false;
            }
        }

        public int GetCount()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Diagnosis.ToList().Count;
            }
        }
    }
}