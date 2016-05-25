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
    public partial class BuildsManagerForm : Form
    {
        public BuildsManagerForm()
        {
            InitializeComponent();
        }

        // Change accept state
        private void changeStatus(bool lAccept) {

            if (lAccept)
            {
                labState.Text = "Accepted";
                labState.ForeColor = Color.Lime;

                btnAccept.Enabled = false;
            }
            else
            {
                labState.Text = "Not accepted";
                labState.ForeColor = Color.Red;

                if( LoginData.GetUserRoleID() != (int)LoginData.Role.CONFIGURATOR )
                    btnAccept.Enabled = true;
            }
        }

        // Load data to 
        private void loadData() {
            try {
                // Create DataSet
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                // Add data
                string cmdBuildsString;
                string cmdComponentsString;

                SqlCommand cmdMaster;
                SqlCommand cmdDetails;

                if (LoginData.GetUserRoleID() == (int)LoginData.Role.TESTER ||
                    LoginData.GetUserRoleID() == (int)LoginData.Role.ADMINISTRATOR)
                {
                    cmdBuildsString = "SELECT * FROM vBuilds";
                    cmdComponentsString = "SELECT * FROM vBuildsComponents";

                    cmdMaster = new SqlCommand(cmdBuildsString, SqlConn.Connection);
                    cmdDetails = new SqlCommand(cmdComponentsString, SqlConn.Connection);
                }
                else {
                    cmdBuildsString = "SELECT * FROM vBuilds WHERE bldCreatorID = @pID";
                    cmdComponentsString = "SELECT * FROM vBuildsComponents WHERE bldUserID = @pID";

                    cmdMaster = new SqlCommand(cmdBuildsString, SqlConn.Connection);
                    cmdMaster.Parameters.Add("@pID", SqlDbType.Int);
                    cmdMaster.Parameters["@pID"].Value = LoginData.GetUserID();

                    cmdDetails = new SqlCommand(cmdComponentsString, SqlConn.Connection);
                    cmdDetails.Parameters.Add("@pID", SqlDbType.Int);
                    cmdDetails.Parameters["@pID"].Value = LoginData.GetUserID();
                }

                // Fill master - dgvBuilds
                SqlDataAdapter masterDataAdapter = new SqlDataAdapter();
                masterDataAdapter.SelectCommand = cmdMaster;
                masterDataAdapter.Fill(data,"v_builds");

                // Fill details - dgvComponents
                SqlDataAdapter detailsDataAdapter = new SqlDataAdapter();
                detailsDataAdapter.SelectCommand = cmdDetails;
                detailsDataAdapter.Fill(data, "v_components");

                // Establish a relationship between the two tables.
                DataRelation relation = new DataRelation("build_components",
                                        data.Tables["v_builds"].Columns["bldID"],
                                        data.Tables["v_components"].Columns["blcBuildID"]);
                data.Relations.Add(relation);

                // Bind the master data connector to the Customers table.
                bnsBuilds.DataSource = data;
                bnsBuilds.DataMember = "v_builds";

                // Bind the details data connector to the master data connector,
                // using the DataRelation name to filter the information in the 
                // details table based on the current row in the master table. 
                bnsComponents.DataSource = bnsBuilds;
                bnsComponents.DataMember = "build_components";
            }
            catch ( SqlException ex ) {
                MessageBox.Show( "Sql error: " + ex.ToString() );
            }

        }

        // Load data grids
        private void loadDataGrid()
        {
            // Bind the DataGridView controls to the BindingSource
            // components and load the data from the database.
            bnsBuilds = new BindingSource();
            bnsComponents = new BindingSource();
            dgvBuilds.DataSource = bnsBuilds;
            dgvComponents.DataSource = bnsComponents;

            this.loadData();

            // Set colums
            //
            //  dgvBuilds
            //
            for (int i = 0; i < dgvBuilds.Columns.Count; i++)
            {
                dgvBuilds.Columns[i].Visible = false;
                dgvBuilds.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvBuilds.Columns["bldID"].Visible = true;
            dgvBuilds.Columns["bldID"].HeaderText = "ID";
            dgvBuilds.Columns["bldID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvBuilds.Columns["bldName"].Visible = true;
            dgvBuilds.Columns["bldName"].HeaderText = "Build name";

            dgvBuilds.Columns["bldCreatorName"].Visible = true;
            dgvBuilds.Columns["bldCreatorName"].HeaderText = "Creator";

            dgvBuilds.Columns["bldCreatorID"].Visible = false;
            dgvBuilds.Columns["bldTesterID"].Visible = false;

            dgvBuilds.Columns["bldAccepted"].Visible = true;
            dgvBuilds.Columns["bldAccepted"].HeaderText = "Acc.";

            //
            //  dgvComponents
            //
            for (int i = 0; i < dgvComponents.Columns.Count; i++)
            {
                dgvComponents.Columns[i].Visible = false;
                dgvComponents.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvComponents.Columns["typName"].Visible = true;
            dgvComponents.Columns["typName"].HeaderText = "Type";
            dgvComponents.Columns["typName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvComponents.Columns["comName"].Visible = true;
            dgvComponents.Columns["comName"].HeaderText = "Name";

            dgvComponents.Columns["blcCount"].Visible = true;
            dgvComponents.Columns["blcCount"].HeaderText = "Cnt.";
            dgvComponents.Columns["blcCount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Resize the master DataGridView columns to fit the newly loaded data.
            dgvBuilds.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dgvComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        // Refresh data grids
        public void refreshDataGrid() {
            this.loadDataGrid();

            if (dgvBuilds.Rows.Count <= 0)
            {
                // Info
                labState.Text = "Unknown";
                labState.ForeColor = Color.Black;

                txbCreator.Text = "";

                txbTester.Text = "";

                // Buttons
                btnAccept.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false; 
            }
        }

        private void BuildsManagerForm_Load(object sender, EventArgs e)
        {
            // Privilage
            if (LoginData.GetUserRoleID() == (int)LoginData.Role.CONFIGURATOR)
            {
                btnAccept.Enabled = false;
            }

            if (LoginData.GetUserRoleID() == (int)LoginData.Role.TESTER)
            {
                btnDelete.Enabled = false;
                btnAddNew.Enabled = false;
            }

            this.refreshDataGrid();
       }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Add new build
        private void button1_Click(object sender, EventArgs e)
        {
            EditForms.BuildEditForm childForm = new EditForms.BuildEditForm();

            childForm.CreatorID = LoginData.GetUserID();
            childForm.txbCreatorName.Text = LoginData.GetUserName();
            childForm.changeStatus(false);

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Edit build
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForms.BuildEditForm childForm = new EditForms.BuildEditForm();

            // Fill data in BuildEditForm
            childForm.txbID.Text = 
                dgvBuilds.SelectedRows[0].Cells["bldID"].Value.ToString();

            childForm.txbCreatorName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldCreatorName"].Value.ToString();

            childForm.txbTesterName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldTesterName"].Value.ToString();

            childForm.txbName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldName"].Value.ToString();

            try {
                bool tmpBool =
                    Boolean.Parse(dgvBuilds.SelectedRows[0].Cells["bldAccepted"].Value.ToString());

                childForm.changeStatus(tmpBool);
            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.ToString());
            }

            int tmpTesterID;
            if (Int32.TryParse(dgvBuilds.SelectedRows[0].Cells["bldTesterID"].Value.ToString(), out tmpTesterID))
            {
                childForm.TesterID = tmpTesterID;
                childForm.isTester = true;
            }
            else {
                childForm.isTester = false; 
            }

            childForm.CreatorID = (int)(dgvBuilds.SelectedRows[0].Cells["bldCreatorID"].Value);
            
            // Show window
            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Show info about build
        private void showInfo() {
            // Show decription of component
            if (dgvBuilds.SelectedRows.Count > 0)
            {
                // Accepted / Not accepted
                try
                {
                    bool tmpBool =
                        Boolean.Parse(dgvBuilds.SelectedRows[0].Cells["bldAccepted"].Value.ToString());

                    this.changeStatus(tmpBool);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot parse bool value (bldAccepted): " + ex.ToString());
                }
                
                txbCreator.Text = dgvBuilds.SelectedRows[0].Cells["bldCreatorName"].Value.ToString();

                txbTester.Text = dgvBuilds.SelectedRows[0].Cells["bldTesterName"].Value.ToString();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else {
                labState.Text = "Unknown";
                labState.ForeColor = Color.Black;
                
                txbCreator.Text = "";
                txbTester.Text = "";

                btnEdit.Enabled = false;
                btnAccept.Enabled = false;
                btnDelete.Enabled = false;
            }

        }

        // Show info about build on row change
        private void dgvBuilds_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected)
                return;

            this.showInfo();

        }

        // Accept build
        private void btnAccept_Click(object sender, EventArgs e)
        {
            SqlCommand lSCmd;
            SqlParameter lMsg;

            string lMessageText = "Do you want accept this build as " + LoginData.GetUserName() + "?";
            if (MessageBox.Show(lMessageText, "Notification", MessageBoxButtons.YesNo) == DialogResult.No) {
                return; 
            }

            try
            {
                // acceptBuild(@pBuildID, @pTesterID, @oMsg)
                lSCmd = new SqlCommand("acceptBuild", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                lSCmd.Parameters.Add("@pBuildID", SqlDbType.Int);

                lSCmd.Parameters.Add("@pTesterID", SqlDbType.Int);

                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 100);
                lMsg.Direction = ParameterDirection.Output;

                // Param values
                lSCmd.Parameters["@pBuildID"].Value = this.dgvBuilds.SelectedRows[0].Cells["bldID"].Value;

                lSCmd.Parameters["@pTesterID"].Value = LoginData.GetUserID();

                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    dgvBuilds.SelectedRows[0].Cells["bldAccepted"].Value = true;
                    dgvBuilds.SelectedRows[0].Cells["bldTesterName"].Value = LoginData.GetUserName();

                    this.showInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Delete Build
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lStmt;

            SqlCommand lSCmd;
            SqlParameter lMsg;

            try
            {
                // (@pBuildID, @oMsg)
                lStmt = "deleteBuild";
                lSCmd = new SqlCommand(lStmt, SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                lSCmd.Parameters.Add("@pBuildID", SqlDbType.Int);

                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 100);
                lMsg.Direction = ParameterDirection.Output;

                // Param values
                lSCmd.Parameters["@pBuildID"].Value = this.dgvBuilds.SelectedRows[0].Cells["bldID"].Value;

                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Build deleted !");
                    int tmpIndex = dgvBuilds.SelectedRows[0].Index;

                    dgvBuilds.Rows.RemoveAt( tmpIndex );

                    // Select next row and check is there any rows
                    tmpIndex--;
                    if (dgvBuilds.Rows.Count > 0)
                    {
                        if (tmpIndex >= 0)
                        {
                            dgvBuilds.Rows[tmpIndex].Selected = true;
                        }
                        else
                        {
                            dgvBuilds.Rows[0].Selected = true;
                        }
                    }
                    else {
                        this.showInfo();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
