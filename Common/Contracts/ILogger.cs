﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        bool LogMessage(LOG_TYPE logType, String message);
    }
}
