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
    public partial class showBuildsForm : Form
    {

        public showBuildsForm()
        {
            InitializeComponent();
        }

        private void loadBuilds()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            SqlCommand giveMeListOfBuilds = new SqlCommand(
                @"SELECT 
                    bldID, 
                    usrLogin, 
                    bldAccepted 
                FROM
                    BUILDS 
                        JOIN USERS ON
                            bldUserID = usrID",
                SqlConn.Connection);

            using (SqlDataReader r = giveMeListOfBuilds.ExecuteReader())
            {
                int id;
                string login, accepted;
                bool acc = false;

                while (r.Read())
                {
                    id = (int)r["bldID"];
                    login = (string)r["usrLogin"];
                    acc = (bool)r["bldAccepted"];

                    if (acc == false) accepted = "Not accepted";
                    else accepted = "Accepted";

                    listBox1.Items.Add(id + " " + login + " " + accepted + "\n");
                }
            }
        }

        private void showBuilds_Load(object sender, EventArgs e)
        {
            loadBuilds();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = (sender as ListBox).SelectedItem;

            if(selectedUser != null)
            {
                int idBuild = Int32.Parse(selectedUser.ToString().Split(' ')[0]);

                    listBox2.Items.Clear();
                    using (SqlCommand giveMeComponents = new SqlCommand("getBuildsComp", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                    {
                        giveMeComponents.Parameters.AddWithValue("@id", idBuild);
                        using(SqlDataReader r = giveMeComponents.ExecuteReader())
                        {
                            int id;
                            string name;
                            
                            while (r.Read())
                            {
                                id = (int)r["blcComID"];
                                name = (string)r["comName"];

                                listBox2.Items.Add(id + " " + name + "\n");
                            }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)//Accept
        {
            var selectedBuild = listBox1.SelectedItem;

            if (selectedBuild != null)
            {
                int idBuild = Int32.Parse(selectedBuild.ToString().Split(' ')[0]);
                using(SqlCommand acceptBuild = new SqlCommand("acceptBuild", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                {
                    acceptBuild.Parameters.Add("@pBuildID", SqlDbType.Int);
                    acceptBuild.Parameters.Add("@pTesterID", SqlDbType.Int);

                    acceptBuild.Parameters["@pBuildID"].Value = idBuild;
                    acceptBuild.Parameters["@pTesterID"].Value = LoginData.GetUserID();

                    SqlParameter oMsg = acceptBuild.Parameters.Add("@oMsg", SqlDbType.VarChar, 100);
                    oMsg.Direction = ParameterDirection.Output;

                    acceptBuild.ExecuteNonQuery();
                }
                loadBuilds();
            }
            
        }
        private void button2_Click(object sender, EventArgs e)//deleteBuild
        {
            var selectedBuild = listBox1.SelectedItem;

            if (selectedBuild != null)
            {
                int buildID = Int32.Parse(selectedBuild.ToString().Split(' ')[0]);

                using (SqlCommand deleteBuild = new SqlCommand("deleteBuild", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                {
                    deleteBuild.Parameters.AddWithValue("@id", buildID);
                    deleteBuild.ExecuteNonQuery();
                }

                loadBuilds();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedComponents = listBox2.SelectedItem;

            if(selectedComponents != null)
            {
                int id = Int32.Parse(selectedComponents.ToString().Split(' ')[0]);
                Description Description = new Description(id);
                Description.MdiParent = this.MdiParent;
                Description.Show();
            }
           
        }
    }
}
