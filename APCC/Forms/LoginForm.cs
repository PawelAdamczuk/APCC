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
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string login = textBox1.Text;
            try
            {
                using (SqlConnection conn = "Klasa Maćka")
                {
                    conn.Open();
                    using 
                }


            }
        }
    }
}
