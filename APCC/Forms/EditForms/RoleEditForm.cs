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

namespace APCC.Forms.EditForms
{
    public partial class RoleEditForm : Form
    {
        public RoleEditForm()
        {
            InitializeComponent();
        }

        private void refreshDgvPermissions() {
            string lStmt;

            try
            {
                lStmt = @"SELECT * FROM getPermissionByRoleID(@pRoleID)";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add( "@pRoleID", SqlDbType.Int );
                lCommand.Parameters["@pRoleID"].Value = Int32.Parse(txbID.Text.ToString());

                SqlDataReader lDataReader = lCommand.ExecuteReader();

                DataTable lTable = new DataTable();
                lTable.Load(lDataReader);

                dgvPermissions.DataSource = lTable;

                dgvPermissions.Columns["perID"].Visible = false;
                dgvPermissions.Columns["perName"].Visible = true;

                dgvPermissions.Columns["perDesc"].HeaderText = "Permission";
                dgvPermissions.Columns["perDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvPermissions.Columns["rlpAccess"].HeaderText = "Access";
                dgvPermissions.Columns["perDefault"].HeaderText = "Default";


                DataGridViewComboBoxColumn lAccessColumn = new DataGridViewComboBoxColumn();
                var list = new List<string>() { "Yes", "No", "Only own" };
                lAccessColumn.DataSource = list;
                lAccessColumn.HeaderText = "Access";
                lAccessColumn.DataPropertyName = "Access";
                
                int tmpInt = dgvPermissions.Columns.Add(lAccessColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RoleEditForm_Load(object sender, EventArgs e)
        {
            txbID.Enabled = false;

            this.refreshDgvPermissions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Save
        private void btnSave_Click(object sender, EventArgs e)
        {



            ((RolesManagerForm)this.Owner).refreshDgvRoles();
        }
    }
}
