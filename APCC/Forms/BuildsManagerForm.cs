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
                    cmdBuildsString = "SELECT * FROM vBuilds WHERE bldUserID = @pID";
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

            dgvBuilds.Columns["bldAccepted"].Visible = true;
            dgvBuilds.Columns["bldAccepted"].HeaderText = "Acc.";

            //
            //  dgvComponents
            //
            for (int i = 0; i < dgvBuilds.Columns.Count; i++)
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
        private void refreshDataGrid() {
            this.loadDataGrid();
        }

        private void BuildsManagerForm_Load(object sender, EventArgs e)
        {
            this.refreshDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditForms.BuildEditForm childForm = new EditForms.BuildEditForm();

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Edit build
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForms.BuildEditForm childForm = new EditForms.BuildEditForm();

            // Fill data in BuildEditForm
            childForm.txbID.Text = dgvBuilds.SelectedRows[0].Cells["bldID"].Value.ToString();

            childForm.txbCreatorName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldCreatorName"].Value.ToString();

            childForm.txbTesterName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldTesterName"].Value.ToString();

            childForm.txbName.Text =
                dgvBuilds.SelectedRows[0].Cells["bldName"].Value.ToString();

            try {
                bool tmpBool =
                    Boolean.Parse(dgvBuilds.SelectedRows[0].Cells["bldAccepted"].Value.ToString());

                if(tmpBool == true) {
                    childForm.labStatus.Text = "Accepted";
                    childForm.labStatus.ForeColor = Color.Lime;

                    childForm.btnAccept.Enabled = false;
                }
                else
                {
                    childForm.labStatus.Text = "Not accepted";
                    childForm.labStatus.ForeColor = Color.Red;
                }

            }
            catch ( Exception ex ) {
                MessageBox.Show(ex.ToString());
            }

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        private void dgvBuilds_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected)
                return;

            // Show decription of component
            if (dgvBuilds.SelectedRows.Count > 0)
            {
                // labState
                try
                {
                    if (Boolean.Parse(dgvBuilds.SelectedRows[0].Cells["bldAccepted"].Value.ToString()) == true)
                    {

                        labState.Text = "Accepted";
                        labState.ForeColor = Color.Lime;
                    }
                    else
                    {

                        labState.Text = "Not accepted";
                        labState.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Cannot parse bool value (bldAccepted): " + ex.ToString() );
                }

                //txbCreator
                txbCreator.Text = dgvBuilds.SelectedRows[0].Cells["bldCreatorName"].Value.ToString();

                //txbTester
                txbTester.Text = dgvBuilds.SelectedRows[0].Cells["bldTesterName"].Value.ToString();

            }

        }
    }
}
