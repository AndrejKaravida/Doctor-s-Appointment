using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.Adition
{
    public class Channel
    {
        public IUserService UserProxy { get; set; }
        public IDiagnosisService DiagnosisProxy { get; set; }
        
        public IAppointmentService AppointmentProxy { get; set; }
        public ILogger LogProxy { get; set; }

        private static Channel instance;

        //Singleton
        public static Channel Instance
        {
            get
            {
                if (instance == null)
                    instance = new Channel();
                return instance;
            }

        }

        public Channel()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;


            ChannelFactory<IUserService> channelFactoryUser = new ChannelFactory<IUserService>(binding, new EndpointAddress("net.tcp://localhost:11000/IUserService"));
            UserProxy = channelFactoryUser.CreateChannel();

            ChannelFactory<IDiagnosisService> channelFactoryDiagnosisItem = new ChannelFactory<IDiagnosisService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:11000/IDiagnosisService"));
            DiagnosisProxy = channelFactoryDiagnosisItem.CreateChannel();

            ChannelFactory<IAppointmentService> channelFactoryAppointment = new ChannelFactory<IAppointmentService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:11000/IAppointmentService"));
            AppointmentProxy = channelFactoryAppointment.CreateChannel();

            
            ChannelFactory<ILogger> channelFactoryLogger = new ChannelFactory<ILogger>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:11000/ILogger"));
            LogProxy = channelFactoryLogger.CreateChannel();
        }
    }
}
