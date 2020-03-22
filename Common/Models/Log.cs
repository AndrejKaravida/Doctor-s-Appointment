using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Log
    {
        #region Fields
        String type;
        String text;

        public String Type { get => type; set => type = value; }
        public String Text { get => text; set => text = value; }
        #endregion

        #region Constructor
        public Log() { }
        #endregion
    }
}
