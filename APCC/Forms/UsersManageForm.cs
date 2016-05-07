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
            try
            {
                SqlCommand giveMeUsers = new SqlCommand("SELECT * FROM [dbo].[UsersManage]", SqlConn.Connection);

                SqlDataReader reader = giveMeUsers.ExecuteReader();

                int id;
                string fName, sName, rName;

                while (reader.Read())
                {
                    id = (int)reader["usrID"];
                    fName = (string)reader["usrFName"];
                    sName = (string)reader["usrSName"];
                    rName = (string)reader["rlsName"];

                    listBox1.Items.Add(id + " " + fName + " " + sName + " " + rName + "\n");
                }
                
            }catch(Exception ex){

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
