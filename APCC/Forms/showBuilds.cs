using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC.Forms
{
    public partial class showBuilds : Form
    {
        public showBuilds()
        {
            InitializeComponent();
        }

        private void showBuilds_Load(object sender, EventArgs e)
        {
            SqlCommand giveMeListOfBuilds = new SqlCommand(
                @"SELECT 
                    bldID, 
                    usrLogin, 
                    bldAccepted 
                FROM
                    BUILDS 
                        JOIN USERS ON
                            bldUserID = usrID",
                SqlConn.Connection);

            using(SqlDataReader r = giveMeListOfBuilds.ExecuteReader())
            {
                int id;
                string login;
                bool accepted;

                while (r.Read())
                {
                    id = (int)r["bldID"];
                    login = (string)r["usrLogin"];
                    accepted = (bool)r["bldAccepted"];

                    listBox1.Items.Add(id + " " + login + " " + accepted + "\n");
                }
            }
        }
    }
}
