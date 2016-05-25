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
    public partial class UsersManageForm : Form
    {

        private int lastId;

        public UsersManageForm()
        {
            InitializeComponent();
        }

        public void LoadUsers()
        {
            dgvUsers.Rows.Clear();
            listBox2.Items.Clear();
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

                    dgvUsers.Rows.Add(id, fName, sName, rName);
                }

            }
        }

        private void UsersManageForm_Load(object sender, EventArgs e)
        {
            // Privilege
            if (!(LoginData.GetUserRoleID() == (int)LoginData.Role.ADMINISTRATOR))
            {
                btnAdd.Visible = false;
            }

            btnEdit.Visible = false;
            LoadUsers();
            dgvUsers.ClearSelection();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            if (dgvUsers.SelectedRows.Count == 1)
            {
                int idUsr = int.Parse(dgvUsers[0, dgvUsers.CurrentCell.RowIndex].Value.ToString());

                if (idUsr != LoginData.GetUserID())
                {
                    using (SqlCommand deleteUser = new SqlCommand("deleteUser", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                    {
                        deleteUser.Parameters.AddWithValue("@pID",idUsr);
                        deleteUser.ExecuteNonQuery();
                    }
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("You cannot delete yourself, moron!");
                }
            }
        }

        // Add user
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addingNewUserForm addingNewUserForm = new addingNewUserForm();

            addingNewUserForm.Owner = this;
            addingNewUserForm.ShowDialog();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvUsers.SelectedRows.Count == 1)
            {
                int idUsr = int.Parse(dgvUsers[0, dgvUsers.CurrentCell.RowIndex].Value.ToString());

                if (idUsr != lastId)
                {
                    lastId = idUsr;
                    listBox2.Items.Clear();
                    using (SqlCommand giveMeBuilds = new SqlCommand("getUsrBuilds", SqlConn.Connection) { CommandType = CommandType.StoredProcedure })
                    {
                        giveMeBuilds.Parameters.Add("@uID", SqlDbType.Int);
                        giveMeBuilds.Parameters["@uID"].Value = idUsr;
                        using (SqlDataReader buildReader = giveMeBuilds.ExecuteReader())
                        {
                            while (buildReader.Read())
                            {
                                listBox2.Items.Add(buildReader["bldName"].ToString());
                            }
                        }
                    }

                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            var selectedBuild = listBox2.SelectedItem;

            if (selectedBuild != null)
            {
                string buildName = selectedBuild.ToString();

                Form tmpForm = Utilities.FindMdiFormByType(typeof(BuildsManagerForm), this);

                if (tmpForm == null)
                {
                    BuildsManagerForm loginForm = new BuildsManagerForm();
                    loginForm.MdiParent = this.MdiParent;
                    loginForm.Show();
                    loginForm.selectIndex(buildName);
                }
                else
                {
                    tmpForm.Activate();
                    ((BuildsManagerForm)tmpForm).selectIndex(buildName);
                    tmpForm.WindowState = FormWindowState.Normal;
                    
                }
            }
        }
    }
}
