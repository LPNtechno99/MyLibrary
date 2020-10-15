using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNtechLibrarySQLite.Utilitys
{
    public class Global
    {
        private static string _ConnectionString;
        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
    }
}
