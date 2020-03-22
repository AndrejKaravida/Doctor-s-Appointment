
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DBAccess
{
    public class Context : DbContext
    {
        #region Fields
       
        public DbSet<User> Users{ get; set; }
       
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        #endregion

        #region Constructor
        public Context() : base("Context") { }
        #endregion
    }
}
