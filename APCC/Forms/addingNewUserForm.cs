using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace APCC.Forms
{
    public partial class addingNewUserForm : Form
    {
       
        public addingNewUserForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int numberOfRole(string role)
        {
            int r = 0;

            if (role.CompareTo("Configurator") == 0) r = 1;
            else if (role.CompareTo("Tester") == 0) r = 2;
            else if (role.CompareTo("Administrator") == 0) r = 3;

            return r;
        }

        private bool checkCorrectDate(string fName, string lName, string login, string password, string position)
        {
            if(fName == "" || lName == "" || login == "" || password == "" || position == "")
            {
                MessageBox.Show("You entered incorrect date");
                return false;
            }

            using (SqlCommand checkLogin = new SqlCommand("SELECT usrLogin FROM USERS WHERE usrLogin = '" + login + "'", SqlConn.Connection) { CommandType = CommandType.Text })
            {
                using (SqlDataReader r = checkLogin.ExecuteReader())
                {
                    if (r.HasRows == true)
                    {
                        MessageBox.Show("The user name has taken");
                        return false;
                    }
                }
                
            }
                return true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string fName = textBox1.Text,
                   lName = textBox2.Text,
                   login = textBox3.Text,
                   password = textBox4.Text,
                   position;

            if (listBox1.SelectedItem != null) position = listBox1.SelectedItem.ToString();
            else position = "";

            if (checkCorrectDate(fName, lName, login, password, position) == true)
            {
                using (SqlCommand addUser = new SqlCommand("addUser", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                {
                    addUser.Parameters.AddWithValue("@pFName", fName);
                    addUser.Parameters.AddWithValue("@pSName", lName);
                    addUser.Parameters.AddWithValue("@pLogin", login);
                    addUser.Parameters.AddWithValue("@pPswd", Utilities.StringHash(password));
                    addUser.Parameters.AddWithValue("@pRoleId", numberOfRole(position));

                    addUser.ExecuteNonQuery();
                    MessageBox.Show("You have added a new user");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                }
            }
        }

        private void ignoreWhiteChar(TextBox txtBox)
        {
            if (txtBox.Text.All(char.IsLetterOrDigit) == false)
            {
                txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1);

                if (txtBox.Text.Length != 0)
                    txtBox.SelectionStart = txtBox.Text.Length;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ignoreWhiteChar(textBox1);    
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ignoreWhiteChar(textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ignoreWhiteChar(textBox3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ignoreWhiteChar(textBox4);
        }
    }
}
