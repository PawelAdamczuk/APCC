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

            lConnStr.Add("Data Source", "paweladamczuk.com.pl,4100");
            lConnStr.Add("Initial Catalog", "FOKA");
            lConnStr.Add("User Id", "sa");
            lConnStr.Add("Password", "foka");
            
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

