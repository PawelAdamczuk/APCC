﻿using System;
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

        private int lastId;

        public UsersManageForm()
        {
            InitializeComponent();
        }

        private void UsersManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand giveMeUsers = new SqlCommand("SELECT * FROM [dbo].[UsersManage]", SqlConn.Connection);

                int id;
                string fName, sName, rName;
                using (SqlDataReader reader = giveMeUsers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["usrID"];
                        fName = (string)reader["usrFName"];
                        sName = (string)reader["usrSName"];
                        rName = (string)reader["rlsName"];

                        listBox1.Items.Add(id + " " + fName + " " + sName + " " + rName + "\n");
                    }

                }

            }catch(Exception ex)
            {
                listBox1.Items.Add(ex.Message.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = (sender as ListBox).SelectedItem;

            if(selectedUser != null)
            {
                int idUsr = Int32.Parse(selectedUser.ToString().Split(' ')[0]);

                if(idUsr != lastId)
                {
                    listBox2.Items.Clear();
                    using (SqlCommand giveMeBuilds = new SqlCommand("getUsrBuilds", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                    {
                        giveMeBuilds.Parameters.Add("@uID", SqlDbType.Int);
                        giveMeBuilds.Parameters["@uID"].Value = idUsr;
                        using(SqlDataReader buildReader = giveMeBuilds.ExecuteReader())
                        {
                            while (buildReader.Read())
                            {
                                listBox2.Items.Add((int)buildReader["bldID"]);
                            }
                        }
                    }
                      
                }
            }
       }

    }
}
