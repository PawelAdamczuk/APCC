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
    public partial class BuildEditForm : Form
    {
        //
        // VAR
        //
        private bool cmbTypesFilled;
        public bool isTester;

        public int CreatorID;
        public int TesterID;
        
        // For permission distinction, tells 
        // if showed information about build
        // state is currently in data base.
        private bool isStateComitted; 

        private EditMode editMode;
        public enum EditMode {
            EDIT = 0,
            ADD = 1
        }

        //
        // INIT
        //

        public BuildEditForm( EditMode pMode )
        {
            editMode = pMode;

            cmbTypesFilled = false;
            isStateComitted = true;

            InitializeComponent();
        }

        // On load
        private void BuildEditForm_Load(object sender, EventArgs e)
        {
            // Permissions
            this.setPermissions();

            //
            // Summary tab
            //
            this.refreshDgvComponents();

            //
            // Components tab
            //
            this.loadCmbTypes();
            this.refreshDgvComponentsList();
        }

        //
        // FORM
        //

        private void setPermissions() {
            txbName.Enabled = false;
            cbxAccept.Enabled = false;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnClearAll.Enabled = false;
            btnPlus.Enabled = false;
            btnMinus.Enabled = false;

            btnSave.Visible = false;

            if (LoginData.havePermission("EDIT_BUILDS", LoginData.AccessControl.YES) ||
                (LoginData.havePermission("EDIT_BUILDS", LoginData.AccessControl.ONLY_OWN) && this.CreatorID == LoginData.GetUserID() ) ||
                editMode == EditMode.ADD)
            {
                txbName.Enabled = true;

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnClearAll.Enabled = true;
                btnPlus.Enabled = true;
                btnMinus.Enabled = true;

                btnSave.Visible = true;
            }

            if ( LoginData.havePermission("ACCEPT_BUILDS", LoginData.AccessControl.YES) ) 
            {
                btnSave.Visible = true;

                if (isStateComitted == false || isTester == false)
                {
                        cbxAccept.Enabled = true;
                }
            }

            if( LoginData.havePermission("UNACCEPT_BUILDS", LoginData.AccessControl.YES) ||
                ( LoginData.havePermission("UNACCEPT_BUILDS", LoginData.AccessControl.ONLY_OWN) &&
                this.TesterID == LoginData.GetUserID() )  
              )
            {
                btnSave.Visible = true;

                if( isTester == true)
                { 
                    cbxAccept.Enabled = true;
                }
            }

        }

        // Change accept state
        public void changeStatus(bool lAccept)
        {
            cbxAccept.Checked = lAccept;

            if (lAccept)
            {
                labStatus.Text = "Accepted";
                labStatus.ForeColor = Color.Lime;

                this.isTester = true;
                this.TesterID = LoginData.GetUserID();
                this.txbTesterName.Text = LoginData.GetUserName();
            }
            else
            {
                labStatus.Text = "Not accepted";
                labStatus.ForeColor = Color.Red;

                this.isTester = false;
                this.TesterID = 0;
                this.txbTesterName.Text = "";
            }

            this.setPermissions();
        }

        // Fill combobox with components types
        private void loadCmbTypes() {
            string lStmt;

            try
            {
                lStmt = @"
                            select
                                *
                            from
                                TYPES
                         ";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    cmbType.DataSource = lTable;
                    cmbType.DisplayMember = "typName";
                    cmbType.ValueMember = "typID";

                    this.cmbTypesFilled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Refresh dgvComponents
        private void refreshDgvComponents()
        {
            bool lNewBuild = false;

            // txbID is empty, probably new build
            if (txbID.Text == "")
                lNewBuild = true;

            // txbID is not a number
            int lBuildID = 0;
            if ( ( lNewBuild == false ) && ( Int32.TryParse(txbID.Text, out lBuildID) == false ) )
            {
                MessageBox.Show("Error: Cannot convert build ID to number.");
                return;
            }

            string lStmt;

            try
            {
                // ROW( comID, typName, comName, comCount )
                lStmt = @"
                            SELECT
                                comID,
                                typName,
                                comName,
                                comCount 
                            FROM 
                                getComponentsByBuildID(@pBuildID)
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pBuildID", SqlDbType.Int);
                if( lNewBuild )
                    lCommand.Parameters["@pBuildID"].Value = DBNull.Value;
                else
                    lCommand.Parameters["@pBuildID"].Value = lBuildID;

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvComponents.DataSource = lTable;

                    dgvComponents.Columns["comID"].Visible = false;

                    dgvComponents.Columns["typName"].Visible = true;
                    dgvComponents.Columns["typName"].HeaderText = "Type";
                    dgvComponents.Columns["typName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvComponents.Columns["comName"].Visible = true;
                    dgvComponents.Columns["comName"].HeaderText = "Name";
                    dgvComponents.Columns["comName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvComponents.Columns["comCount"].Visible = true;
                    dgvComponents.Columns["comCount"].HeaderText = "Count";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Refresh dgvComponentsList 
        private void refreshDgvComponentsList(){
            string lStmt;

            try
            {
                lStmt = @"
                            SELECT * FROM getComponentsByType(@pTypeID)
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pTypeID",SqlDbType.Int);
                lCommand.Parameters["@pTypeID"].Value = cmbType.SelectedValue;

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvComponentsList.DataSource = lTable;

                    dgvComponentsList.Columns["comID"].Visible = false;
                    dgvComponentsList.Columns["typName"].Visible = false;
                    dgvComponentsList.Columns["comTypeID"].Visible = false;
                    dgvComponentsList.Columns["typID"].Visible = false;

                    dgvComponentsList.Columns["comName"].HeaderText = "Component name";
                    dgvComponentsList.Columns["comName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Set parameters name
                    if (dgvComponentsList.Rows.Count > 0)
                    {
                        // Int
                        for (int i = 1; i <= 10; i++)
                        {
                            if (dgvComponentsList.Rows[0].Cells["comParamInt" + i + "Name"].Value.ToString() != "")
                            {
                                dgvComponentsList.Columns["comParamInt" + i].Visible = true;
                                dgvComponentsList.Columns["comParamInt" + i].HeaderText =
                                    dgvComponentsList.Rows[0].Cells["comParamInt" + i + "Name"].Value.ToString();

                            }
                            else
                            {
                                dgvComponentsList.Columns["comParamInt" + i].Visible = false;
                            }

                            dgvComponentsList.Columns["comParamInt" + i + "Name"].Visible = false;
                        }

                        // String
                        for (int i = 1; i <= 10; i++)
                        {
                            if (dgvComponentsList.Rows[0].Cells["comParamString" + i + "Name"].Value.ToString() != "")
                            {
                                dgvComponentsList.Columns["comParamString" + i].Visible = true;
                                dgvComponentsList.Columns["comParamString" + i].HeaderText =
                                    dgvComponentsList.Rows[0].Cells["comParamString" + i + "Name"].Value.ToString();

                            }
                            else
                            {
                                dgvComponentsList.Columns["comParamString" + i].Visible = false;
                            }

                            dgvComponentsList.Columns["comParamString" + i + "Name"].Visible = false;

                        }
                    }

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Refresh dgvComponentsList on type change 
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTypesFilled == true)
            {
                this.refreshDgvComponentsList();
            }
        }

        // Change description on row change in dgvComponents
        private void dgvComponents_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

            // Show decription of component
            if (dgvComponents.SelectedRows.Count > 0)
            {
                int tmpID = Int32.Parse(dgvComponents.SelectedRows[0].Cells["comID"].Value.ToString());
                rtxDescription.Text = Utilities.getComponentDescription(tmpID);
            }

       }

        // Hide info when there is no rows in dgvComponents
        private void dgvComponents_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvComponents.Rows.Count <= 0 ){
                rtxDescription.Text = "";
            }
        }

        // Change state info after checked changed
        private void cbxAccept_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult lResult;
            isStateComitted = false;

            string tmpString;

            if (cbxAccept.Checked) {
                tmpString = "Do you want accept this build as " + LoginData.GetUserName() + "?";
                lResult = MessageBox.Show( tmpString, "Notification", MessageBoxButtons.YesNo );

                if (lResult == DialogResult.Yes)
                {
                    this.changeStatus(true);
                }
                else {
                    cbxAccept.Checked = false;
                }
            }
            else {
                tmpString = "Do you want change status of build and remove current tester?";
                lResult = MessageBox.Show( tmpString, "Notification", MessageBoxButtons.YesNo );

                if (lResult == DialogResult.Yes)
                {
                    this.changeStatus(false);
                }
                else {
                    cbxAccept.Checked = true;
                }
            }
        }

        // On close
        private void BuildEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((BuildsManagerForm)this.Owner).refreshDataGrid();
        }

        //
        // BUTTONS
        //

        // Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoginData.havePermission("EDIT_BUILDS", LoginData.AccessControl.YES) ||
                (LoginData.havePermission("EDIT_BUILDS", LoginData.AccessControl.ONLY_OWN) &&
                 this.CreatorID == LoginData.GetUserID())
               )
            {
                this.saveBuild();
            }
            else {
                this.acceptBuild();
            }

            this.setPermissions();
        }

        // Accept build
        private void acceptBuild()
        {
            SqlCommand lSCmd;
            SqlParameter lMsg;

            try
            {
                // (@pBuildID, @pTesterID, @pState, @oMsg)
                lSCmd = new SqlCommand("changeBuildState", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                lSCmd.Parameters.Add("@pBuildID", SqlDbType.Int);
                lSCmd.Parameters.Add("@pTesterID", SqlDbType.Int);
                lSCmd.Parameters.Add("@pState", SqlDbType.Bit);

                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 100);
                lMsg.Direction = ParameterDirection.Output;

                // Param values
                lSCmd.Parameters["@pBuildID"].Value = Int32.Parse(this.txbID.Text);
                lSCmd.Parameters["@pTesterID"].Value = LoginData.GetUserID();
                lSCmd.Parameters["@pState"].Value = cbxAccept.Checked;

                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Build state changed!");

                    this.changeStatus(cbxAccept.Checked);
                    isStateComitted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save build
        private void saveBuild()
        {
            SqlCommand lSCmd;

            SqlParameter lID;
            SqlParameter lBuildName;
            SqlParameter lCreatorID;
            SqlParameter lTesterID;
            SqlParameter lAccepted;
            SqlParameter lComArray;
            SqlParameter lMsg;

            try
            {
                // saveBuild( @pBuildID, @pBuildName, @pCreatorID, @pTesterID, @pAccepted, @pComArray, @oMsg )
                lSCmd = new SqlCommand("saveBuild", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                //
                // Define parameters
                //

                lID = lSCmd.Parameters.Add("@pBuildID", SqlDbType.Int);
                lBuildName = lSCmd.Parameters.Add("@pBuildName", SqlDbType.VarChar, 256);
                lCreatorID = lSCmd.Parameters.Add("@pCreatorID", SqlDbType.Int);
                lTesterID = lSCmd.Parameters.Add("@pTesterID", SqlDbType.Int);
                lAccepted = lSCmd.Parameters.Add("@pAccepted", SqlDbType.Bit);
                lComArray = lSCmd.Parameters.Add("@pComArray", SqlDbType.Structured);
                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);

                lID.Direction = ParameterDirection.InputOutput;
                lMsg.Direction = ParameterDirection.Output;

                //
                // Fill parameters
                //

                if (txbID.Text == "")
                    lSCmd.Parameters["@pBuildID"].Value = DBNull.Value;
                else
                    lSCmd.Parameters["@pBuildID"].Value = int.Parse(txbID.Text);

                lSCmd.Parameters["@pBuildName"].Value = txbName.Text;

                lSCmd.Parameters["@pCreatorID"].Value = this.CreatorID;

                if (this.isTester)
                    lSCmd.Parameters["@pTesterID"].Value = this.TesterID;
                else
                    lSCmd.Parameters["@pTesterID"].Value = DBNull.Value;

                lSCmd.Parameters["@pAccepted"].Value = cbxAccept.Checked;

                DataTable comTable = new DataTable();
                comTable.Columns.Add("ID");
                comTable.Columns.Add("comID");
                comTable.Columns.Add("comCount");

                int i = 0;
                foreach (DataGridViewRow lRow in dgvComponents.Rows)
                {
                    comTable.Rows.Add(i++, lRow.Cells["comID"].Value, lRow.Cells["comCount"].Value);
                }

                lSCmd.Parameters["@pComArray"].Value = comTable;

                // Execute
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show("Database error: " + lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Build saved!");

                    txbID.Text = lID.Value.ToString();
                    isStateComitted = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // COMPONENTS LIST EDITION 

        // Add selcted component to ComponentsList
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // No selested item
            if (dgvComponentsList.SelectedRows.Count == 0)
            {
                labLog.Text = "No item selected.";
                return;
            }

            // Selected item already in build
            foreach (DataGridViewRow lRow in dgvComponents.Rows)
            {
                if ((int)(lRow.Cells["comID"].Value) == (int)(dgvComponentsList.SelectedRows[0].Cells["comID"].Value))
                {

                    lRow.Cells["comCount"].Value =
                        Int32.Parse(lRow.Cells["comCount"].Value.ToString()) + 1;

                    labLog.Text =
                        "Increase number of " +
                        dgvComponentsList.SelectedRows[0].Cells["comName"].Value.ToString() +
                        " (Count:" + lRow.Cells["comCount"].Value.ToString() + ")";
                    return;
                }
            }

            // New item
            // row_dgvComponents( comID, typName, comName, comCount )
            int lComID = (int)(dgvComponentsList.SelectedRows[0].Cells["comID"].Value);
            string lTypName = dgvComponentsList.SelectedRows[0].Cells["typName"].Value.ToString();
            string lComName = dgvComponentsList.SelectedRows[0].Cells["comName"].Value.ToString();

            ((DataTable)(dgvComponents.DataSource)).Rows.Add(lComID, lTypName, lComName, 1);

            labLog.Text = "Added " + dgvComponentsList.SelectedRows[0].Cells["comName"].Value.ToString() + " to build.";

        }

        // (Plus) Add one more selected component
        private void button1_Click(object sender, EventArgs e)
        {
            // No selection
            if (dgvComponents.SelectedRows.Count <= 0)
                return;

            int tmpCount =
                Int32.Parse(dgvComponents.SelectedRows[0].Cells["comCount"].Value.ToString());
            tmpCount++;

            dgvComponents.SelectedRows[0].Cells["comCount"].Value = tmpCount;
        }

        // (Minus) Delete one selected component
        private void btnMinus_Click(object sender, EventArgs e)
        {
            // No selection
            if (dgvComponents.SelectedRows.Count <= 0)
                return;

            int tmpCount =
                Int32.Parse(dgvComponents.SelectedRows[0].Cells["comCount"].Value.ToString());
            tmpCount--;

            if (tmpCount > 0)
            {
                dgvComponents.SelectedRows[0].Cells["comCount"].Value = tmpCount;
            }
            else
            {
                dgvComponents.Rows.RemoveAt(dgvComponents.SelectedRows[0].Index);
            }
        }

        // Delete all components from list
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string tmpString = "Are you sure to delete all components from list ?";
            if (MessageBox.Show(tmpString, "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                while (dgvComponents.Rows.Count > 0)
                {
                    dgvComponents.Rows.RemoveAt(0);
                }
            }
        }

        // Delete group of selected component
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvComponents.SelectedRows.Count != 1)
            {
                return;
            }

            int tmpIndex = dgvComponents.SelectedRows[0].Index;

            dgvComponents.Rows.RemoveAt(tmpIndex);

            // Select next row and check is there any rows
            tmpIndex--;
            if (dgvComponents.Rows.Count > 0)
            {
                if (tmpIndex >= 0)
                {
                    dgvComponents.Rows[tmpIndex].Selected = true;
                }
                else
                {
                    dgvComponents.Rows[0].Selected = true;
                }
            }

        }

        // Close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
