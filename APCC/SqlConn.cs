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
            //SqlConnectionStringBuilder lConnStr = new SqlConnectionStringBuilder();

            //lConnStr.Add("Data Source", "(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)))");
            //lConnStr.Add("User Id", "test");
            //lConnStr.Add("Password", "test");

            string connectionString = "Data Source=paweladamczuk.com.pl,4100;Initial Catalog=Foka;User ID=sa;Password=foka";

            mSC = new SqlConnection(connectionString);
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

