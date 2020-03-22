using Common.Contracts;
using Server.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Channel
    {
        #region Fields

        private static ServiceHost UserServiceHost;
        private static ServiceHost DiagnosisServiceHost;
        private static ServiceHost AppointmentServiceHost;
        private static ServiceHost LogServiceHost;

        #endregion
        public Channel()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            UserServiceHost = new ServiceHost(typeof(UserService));
            UserServiceHost.AddServiceEndpoint(typeof(IUserService), binding, new Uri("net.tcp://localhost:11000/IUserService"));

            AppointmentServiceHost = new ServiceHost(typeof(AppointmentService));
            AppointmentServiceHost.AddServiceEndpoint(typeof(IAppointmentService), new NetTcpBinding(), new Uri("net.tcp://localhost:11000/IAppointmentService"));

            DiagnosisServiceHost = new ServiceHost(typeof(DiagnosisService));
            DiagnosisServiceHost.AddServiceEndpoint(typeof(IDiagnosisService), new NetTcpBinding(), new Uri("net.tcp://localhost:11000/IDiagnosisService"));

            LogServiceHost = new ServiceHost(typeof(Logger));
            LogServiceHost.AddServiceEndpoint(typeof(ILogger), new NetTcpBinding(), new Uri("net.tcp://localhost:11000/ILogger"));


        }

        public void Open()
        {
            UserServiceHost.Open();
            AppointmentServiceHost.Open();
            DiagnosisServiceHost.Open();
            LogServiceHost.Open();
            Console.WriteLine("Service hosts are opened at " + DateTime.Now);
        }

        public void Close()
        {
            UserServiceHost.Close();
            AppointmentServiceHost.Close();
            DiagnosisServiceHost.Close();
            LogServiceHost.Close();
            Console.WriteLine("Service hosts are closed at " + DateTime.Now);
        }
    }
}
