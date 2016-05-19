using System;
using System.Collections;
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
    public partial class AddComponentForm : Form
    {
        ArrayList types;


        public AddComponentForm()
        {
            InitializeComponent();

            types = new ArrayList();

            string connString = String.Format("SELECT * FROM TYPES");
            SqlCommand cmd = new SqlCommand(connString, SqlConn.Connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                }
            }






        }

        private void AddComponentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
