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

            if(textBox1.Text != "")
            {
                SqlCommand checkPaswd = new SqlCommand("SELECT [dbo].[checkPassword] (@idUsr, @newPasswd) as [result]", SqlConn.Connection);
                checkPaswd.Parameters.AddWithValue("@idUsr", LoginData.GetUserID());
                checkPaswd.Parameters.AddWithValue("@newPasswd", Utilities.StringHash(textBox1.Text));

                bool exist = (bool)(checkPaswd.ExecuteScalar());

                if (exist == true) MessageBox.Show("Enter a diffrent password");
                else
                {
                    SqlCommand updatePassword = new SqlCommand("UPDATE USERS SET usrPasswd = '" + Utilities.StringHash(textBox1.Text)+"' WHERE usrID = " + LoginData.GetUserID(), SqlConn.Connection);
                    updatePassword.ExecuteNonQuery();
                    MessageBox.Show("You have changed your password");
                }
            }
            else
            {
                MessageBox.Show("Enter a new password");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
