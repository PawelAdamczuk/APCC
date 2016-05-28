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
        //
        // VAR
        //
        private MainForm parent;

        //
        // INIT
        //

        public LoginForm(MainForm _parent)
        {
            InitializeComponent();
            parent = _parent;
        }

        // On load
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        //
        // FORM
        //

        // Login
        private void button1_Click(object sender, EventArgs e)
        {
            string password = txbPswd.Text;
            string login = txbLogin.Text;

            try
            {   
                using (SqlCommand com = new SqlCommand("SELECT dbo.getUsrId(@login, @password)", SqlConn.Connection))
                {
                    com.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    com.Parameters.Add("@password", SqlDbType.VarChar).Value = Utilities.StringHash(password);

                    string tmpString = com.ExecuteScalar().ToString();

                    if (tmpString == "")
                    {
                        MessageBox.Show("Incorrect login or password!");
                        txbPswd.Clear();
                    }
                    else
                    {
                        LoginData.Login(int.Parse(tmpString));

                        MessageBox.Show("Logged in as " + LoginData.GetUserName());

                        string tmpString2 = "Logged in as " + LoginData.GetUserName() + " (" + LoginData.GetUserRoleName() + ")";
                        parent.statusStrip.Items[0].Text = tmpString2;

                        parent.setPermissions();

                        this.Close();
                    }
                } 
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Connection failed!\n" + ex.Message);
            }
        }

    }
}
