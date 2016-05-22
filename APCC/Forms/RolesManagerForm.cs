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
        public RolesManagerForm()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                            WHERE 
                                rlsID != 3 AND
                                rlsID != 0
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

        // On load
        private void RolesEditForm_Load(object sender, EventArgs e)
        {

            this.refreshDgvRoles();
        }

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
            if (MessageBox.Show("Do you want delete selected role ?", "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes) {

            }
        }
    }
}
