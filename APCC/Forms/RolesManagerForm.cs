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
    public partial class RolesManagerForm : Form
    {
        //
        // INIT 
        //

        public RolesManagerForm()
        {
            InitializeComponent();
        }

        // On load
        private void RolesEditForm_Load(object sender, EventArgs e)
        {
            this.refreshDgvRoles();
            this.setPermissions();
        }

        //
        // FORM
        //

        public void refreshDgvRoles()
        {
            string lStmt;

            try
            {
                lStmt = @"
                            SELECT
                                rlsID,
                                rlsName 
                            FROM 
                                ROLES
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvRoles.DataSource = lTable;

                    dgvRoles.Columns["rlsID"].Visible = false;

                    dgvRoles.Columns["rlsName"].Visible = true;
                    dgvRoles.Columns["rlsName"].HeaderText = "Name";
                    dgvRoles.Columns["rlsName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setPermissions() {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            if (LoginData.havePermission("ADD_ROLES", LoginData.AccessControl.YES))
                btnAdd.Enabled = true;
            if (LoginData.havePermission("DELETE_ROLES", LoginData.AccessControl.YES))
                btnDelete.Enabled = true;
            if (LoginData.havePermission("EDIT_ROLES", LoginData.AccessControl.YES))
                btnEdit.Enabled = true;
        }

        //
        // BUTTONS
        //

        // Add role
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditForms.RoleEditForm childForm = new EditForms.RoleEditForm();
         
            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Edit role
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count <= 0)
                return;

            EditForms.RoleEditForm childForm = new EditForms.RoleEditForm();

            childForm.txbID.Text = dgvRoles.SelectedRows[0].Cells["rlsID"].Value.ToString();
            childForm.txbName.Text = dgvRoles.SelectedRows[0].Cells["rlsName"].Value.ToString();

            childForm.Owner = this;
            childForm.ShowDialog();

        }

        // Delete role
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want delete selected role ?", "Notification", MessageBoxButtons.YesNo) 
                == DialogResult.No ||
                dgvRoles.SelectedRows.Count <= 0 ) {

                return;
            }

            SqlCommand lSCmd;
            SqlParameter lRoleID;
            SqlParameter lMsg;

            try
            {
                // (@pRoleID, @oMsg)
                lSCmd = new SqlCommand("deleteRole", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                // Define parameters
                lRoleID = lSCmd.Parameters.Add("@pRoleID", SqlDbType.Int);
                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 256);
                lMsg.Direction = ParameterDirection.Output;

                // Fill parameters
                lSCmd.Parameters["@pRoleID"].Value = Int32.Parse( dgvRoles.SelectedRows[0].Cells["rlsID"].Value.ToString() );
                
                // EXECUTE !! 
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Role deleted!");
                    this.refreshDgvRoles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
