using Common.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Adition
{
    public class CurrentUser
    {
        private static AppUser instance = null;

        private CurrentUser()
        {
        }

        public static AppUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppUser();
                }
                return instance;
            }
            set
            {
                if (instance == null)
                {
                    instance = value;
                }
                else
                {
                    instance = null;
                }
            }
        }
    }
}
