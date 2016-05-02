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
using System.Windows.Input;

namespace APCC.Forms
{
    public partial class LoginForm : Form
    {
        private MainForm parent;

        public LoginForm(MainForm _parent)
        {
            InitializeComponent();
            parent = _parent;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string password = txbPswd.Text;
            string login = txbLogin.Text;

            try
            {   
                    using(SqlCommand com = new SqlCommand("SELECT dbo.getUsrId(@login, @password)", SqlConn.Connection))
                    {
                        com.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                        com.Parameters.Add("@password", SqlDbType.VarChar).Value = Utilities.StringHash(password);

                        string tmpString = com.ExecuteScalar().ToString();

                        if (tmpString == "")
                        {
                            MessageBox.Show("Incorrect login or password!");
                            txbPswd.Clear();
                        }else{
                            LoginData.Login(int.Parse(tmpString));

                            parent.setPrivilegeMode(LoginData.GetUserRoleID());
                            this.Close();
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
