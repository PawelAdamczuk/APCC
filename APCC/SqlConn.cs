using System.Data.Sql;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC
{
    public sealed class SqlConn
    {
        private static SqlConnection mSC;

        static SqlConn()
        {
            SqlConnectionStringBuilder lConnStr = new SqlConnectionStringBuilder();

            lConnStr.Add("Data Source", "(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)))");
            lConnStr.Add("User Id", "test");
            lConnStr.Add("Password", "test");
            
            mSC = new SqlConnection(lConnStr.ConnectionString);
        }

        public static SqlConnection Connection
        {
            get
            {
                return mSC;
            }
        }

    }

}

