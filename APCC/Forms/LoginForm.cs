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
    public partial class LoginForm : Form
    {
      
        public LoginForm()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string login = textBox2.Text;
            try
            {
                using (SqlConnection conn = SqlConn.Connection)
                {
                    conn.Open();
                    using(SqlCommand com = new SqlCommand("SELECT dbo.getUsrId(@login,@password", conn))
                    {
                        com.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                        com.Parameters.Add("@password", SqlDbType.VarChar).Value = Utilities.StringHash(password);

                        int PrivilegeMode = (int)com.ExecuteScalar();

                        if(PrivilegeMode == 0)
                        {
                            label3.Visible = true;
                            textBox1.Clear();
                            textBox2.Clear();
                        }else
                        {
                            this.Close();
                        }
                    } 
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection failed!\n" + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
