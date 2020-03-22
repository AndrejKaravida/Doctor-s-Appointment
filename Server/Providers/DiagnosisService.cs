using Common.Contracts;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Providers
{
    public class DiagnosisService : IDiagnosisService
    {
        ILogger log = Logger.Instance;
        IDiagnosisDB manager = new DiagnosisDB();
        object x = new object();
        public bool Add(int appointmentId, string Description)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.AddDiagnosis(appointmentId,Description);
                    log.LogMessage(LOG_TYPE.INFO, "Add Diagnosis executed succesfuly.");
                    return retVal;
                }
            }
            catch(Exception e)
            {
                log.LogMessage(LOG_TYPE.ERROR, "Add Diagnosis executed unsuccesfuly.");
                return false;
            }
        }
        public bool CheckExisting()
        {
            log.LogMessage(LOG_TYPE.INFO, "Checking existing User data.");
            if (manager.GetCount() == 0)
                return true;
            else
                return false;

        }
        public bool Change(int appointmentId, string Description)
        {
            try
            {
                lock (x)
                {

                    bool retVal = manager.ChangeDiagnosis(appointmentId, Description);
                    log.LogMessage(LOG_TYPE.INFO, "Change Diagnosis executed succesfuly.");
                    return retVal;
                }
            }
            catch
            {
                log.LogMessage(LOG_TYPE.ERROR, "Change Diagnosis executed unsuccesfuly.");
                return false;
            }
        }
    }
}
