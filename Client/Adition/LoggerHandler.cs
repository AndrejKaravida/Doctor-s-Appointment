using Client.ViewModels;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Adition
{
    class LoggerHelper
    {
        #region Fields
        private MainWindowViewModel mainWindowViewModel;
        private static LoggerHelper instance;

        //Singleton sa viewmodel-om poljem za koriscenje liste logova
        public static LoggerHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoggerHelper();
                return instance;
            }
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel;
            }
            set
            {

                mainWindowViewModel = value;

            }
        }
        #endregion

        #region Operation
        public void LogManagerLogging(LOG_TYPE type, String text)
        {
            Channel.Instance.LogProxy.LogMessage(type, text);
            MainWindowViewModel.Loggers.Add(new Log() { Type = type.ToString(), Text = text });
        }
        #endregion
    }
}
