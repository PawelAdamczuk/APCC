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
        //
        // INIT
        //

        public RoleEditForm()
        {
            InitializeComponent();
        }

        // On load
        private void RoleEditForm_Load(object sender, EventArgs e)
        {
            txbID.Enabled = false;

            setPermissions();

            this.refreshDgvPermissions();
        }

        //
        // FORM
        //

        private void setPermissions()
        {
            btnSave.Visible = false;

            if (LoginData.havePermission("EDIT_ROLES", LoginData.AccessControl.YES))
                btnSave.Visible = true;
        }

        private void refreshDgvPermissions() {
            string lStmt;

            try
            {
                lStmt = @"SELECT * FROM getPermissionEditByRoleID(@pRoleID)";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                // Define
                lCommand.Parameters.Add("@pRoleID", SqlDbType.Int);

                // Values
                int lParse;
                if (Int32.TryParse(txbID.Text.ToString(), out lParse))
                {
                    lCommand.Parameters["@pRoleID"].Value = Int32.Parse(txbID.Text.ToString());
                }
                else {
                    lCommand.Parameters["@pRoleID"].Value = DBNull.Value;
                }

                // Execute !
                DataTable lTable = new DataTable();
                using (SqlDataReader lDataReader = lCommand.ExecuteReader()) {
                    
                    lTable.Load(lDataReader);
                }

                dgvPermissions.DataSource = lTable;

                dgvPermissions.Columns["perID"].Visible = false;
                dgvPermissions.Columns["perName"].Visible = false;

                dgvPermissions.Columns["perDesc"].HeaderText = "Permission";
                dgvPermissions.Columns["perDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvPermissions.Columns["rlpAccess"].Visible = false;
                dgvPermissions.Columns["perACL"].Visible = false;

                dgvPermissions.Columns["perDefault"].HeaderText = "Default";

                // 
                // Fill AccessControl ComboBoxes
                //
                DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();
                cmbColumn.Name = "cmbAccess";
                cmbColumn.HeaderText = "Access";
                dgvPermissions.Columns.Add(cmbColumn);
                
                for (int i = 0; i < dgvPermissions.Rows.Count; i++)
                {
                    // Create ComboBox with AC
                    string tmpStringAC = dgvPermissions.Rows[i].Cells["perACL"].Value.ToString();
                    DataGridViewComboBoxCell cmbCell = createComboBoxCell( tmpStringAC );

                    dgvPermissions.Rows[i].Cells["cmbAccess"] = cmbCell;

                    // Set current values in ComboBox
                    string correctValues = dgvPermissions.Rows[i].Cells["perACL"].Value.ToString();
                    correctValues += "D";
                    string currentValue = dgvPermissions.Rows[i].Cells["rlpAccess"].Value.ToString();

                    if (correctValues.Contains(currentValue[0]))
                    {
                        dgvPermissions.Rows[i].Cells["cmbAccess"].Value = currentValue[0];
                    }
                    else
                    {
                        dgvPermissions.Rows[i].Cells["cmbAccess"].Value = 'D';

                        string tmpEx = "Row " + i + ": (" + correctValues + "," + currentValue + ")"
                                       + " This permission can''t be specified by current AccesControl("
                                       + "Set to Default)";
                        MessageBox.Show(tmpEx);
                    }
                }

                // Disable sort
                foreach (DataGridViewColumn dgvColumn in dgvPermissions.Columns)
                {
                    dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Create combobox with AccesControls
        // Params:
        // @pACL - string with AccesControl chars
        private DataGridViewComboBoxCell createComboBoxCell(string pACL) {

            DataGridViewComboBoxCell lCmbCell = new DataGridViewComboBoxCell();

            DataTable lCmbTable = new DataTable();
            lCmbTable.Columns.Add("Access", typeof(string));
            lCmbTable.Columns.Add("Value", typeof(char));

            lCmbTable.Rows.Add("Default", 'D');

            for (int i = 0; i < pACL.Length; i++) {
                switch( pACL[i]){
                    case 'Y': lCmbTable.Rows.Add("Yes", 'Y'); break;
                    case 'N': lCmbTable.Rows.Add("No", 'N'); break;
                    case 'O': lCmbTable.Rows.Add("Own", 'O'); break;
                    default: break;
                }
            }

            lCmbCell.DataSource = lCmbTable;
            lCmbCell.DisplayMember = "Access";
            lCmbCell.ValueMember = "Value";

            return lCmbCell;
        }

        // Show detailed description on row changed
        private void dgvPermissions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPermissions.SelectedRows.Count == 1)
            {
                txbDetails.Text = dgvPermissions.SelectedRows[0].Cells["perDesc"].Value.ToString();
            }
        }

        //
        // BUTTONS
        //

        // Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand lSCmd;

            SqlParameter lRoleID;
            SqlParameter lPermArray;
            SqlParameter lMsg;

            try
            {
                // (@pRoleID, @pName, @pPermList @oMsg)
                lSCmd = new SqlCommand("saveRole", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                // Define 
                lRoleID = lSCmd.Parameters.Add("@pRoleID", SqlDbType.Int);
                lSCmd.Parameters.Add("@pName", SqlDbType.VarChar, 256);
                lPermArray = lSCmd.Parameters.Add("@pPermArray", SqlDbType.Structured);
                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 256);

                lRoleID.Direction = ParameterDirection.InputOutput;
                lMsg.Direction = ParameterDirection.Output;

                // Values
                if (txbID.Text == ""){
                    lSCmd.Parameters["@pRoleID"].Value = DBNull.Value;
                }else{
                    lSCmd.Parameters["@pRoleID"].Value = int.Parse(txbID.Text);
                }
                
                lSCmd.Parameters["@pName"].Value = txbName.Text;

                // lParams
                DataTable tablePerm = new DataTable();
                tablePerm.Columns.Add("id");
                tablePerm.Columns.Add("PermID");
                tablePerm.Columns.Add("PermAcc");

                for (int i = 0; i < dgvPermissions.Rows.Count; i++) {
                    int lPermID = (int)dgvPermissions.Rows[i].Cells["perID"].Value;
                    string lPermAcc = dgvPermissions.Rows[i].Cells["cmbAccess"].Value.ToString();

                    tablePerm.Rows.Add(i, lPermID, lPermAcc );
                }
                lSCmd.Parameters["@pPermArray"].Value = tablePerm;
                
                // Execute ! 
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Data saved!");
                    txbID.Text = lRoleID.Value.ToString();

                    ((RolesManagerForm)this.Owner).refreshDgvRoles();
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
