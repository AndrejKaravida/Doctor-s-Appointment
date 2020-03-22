using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IDiagnosisDB
    {
        bool AddDiagnosis(int appointmentId, string Description);
        bool ChangeDiagnosis(int appointmentId, string Description);
        int GetCount();
    }
}
