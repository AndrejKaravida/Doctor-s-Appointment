using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [ServiceContract]
    public interface IDiagnosisService
    {
        [OperationContract]
        bool Add(int appointmentId, string Description);
        [OperationContract]
        bool Change(int appointmentId, string Description);
    }
}
