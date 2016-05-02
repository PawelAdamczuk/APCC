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
    public partial class UsersManageForm : Form
    {
        public UsersManageForm()
        {
            InitializeComponent();
        }

        private void UsersManageForm_Load(object sender, EventArgs e)
        {
            DataSet users = null;
            SqlCommand giveMeUsers = new SqlCommand("SELECT * FROM UsersManage");
            SqlDataReader r = giveMeUsers.ExecuteReader();

            int id;
            string fName, sName, rName;

            while (r.Read())
            {
                id = (int)r["usrID"];
                fName = (string)r["usrFName"];
                sName = (string)r["usrSName"];
                rName = (string)r["rlsName"];

                listBox1.Text += (id + " " + fName + " " + sName + " " + rName + "\n");   
            }

        }
    }
}
