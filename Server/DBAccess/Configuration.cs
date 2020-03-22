using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DBAccess
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        #region Constructor
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Context";
        }
        #endregion
    }
}
