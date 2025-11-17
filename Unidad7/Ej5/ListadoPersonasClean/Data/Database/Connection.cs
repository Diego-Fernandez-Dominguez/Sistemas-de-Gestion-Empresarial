using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    internal class Connection
    {
        public static string GetConnectionString()
        {
            return "server=dferdom.database.windows.net;database=PersonasDB;uid=prueba;pwd=123abc|@#;trustServerCertificate = true;";
        }
    }
}
