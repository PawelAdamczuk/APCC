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

namespace APCC
{
    public partial class ProfilManage : Form
    {
        public ProfilManage()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ProfilManage_Load(object sender, EventArgs e)
        {
            string []str = LoginData.GetUserName().Split(' ');
            label2.Text = str[0];
            label4.Text = str[1];
            label6.Text = LoginData.GetUserRoleName();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand getPaswd = new SqlCommand("SELECT usrPasswd FROM [dbo].[Users] WHERE usrID = " + LoginData.GetUserID(), SqlConn.Connection);
            
                using (SqlDataReader r = getPaswd.ExecuteReader())
                {
                    if (textBox1.Text != "" && r["usrPasswd"].ToString() != Utilities.StringHash(textBox1.Text))
                    {
                        SqlCommand setNewPaswd = new SqlCommand("UPDATE [dbo].[USERS] SET usrPasswd = " + Utilities.StringHash(textBox1.Text), SqlConn.Connection);
                        setNewPaswd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Enter new password if you want to change it");
                    }

                }
                       
        }
    }
}
