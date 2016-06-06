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
    public partial class TypesManagerForm : Form
    {
        //
        // INIT
        //

        public TypesManagerForm()
        {
            InitializeComponent();
        }

        public EditForms.TypesEditForm TypesEditForm
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        // On Load
        private void TypesManagerForm_Load(object sender, EventArgs e)
        {
            this.loadDataGrid();
            dgvTypes.AutoResizeColumns();

            setPermissions();
        }

        //
        // FORM
        //

        // Load dataGridView for ComponentTypes
        private void loadDataGrid()
        {
            string lStmt;

            try
            {
                lStmt = @"
                            select
                                typID,
                                typName,
                                int1,int2,int3,int4,int5,
                                int6,int7,int8,int9,int10,
                                string11,string12,string13,string14,string15,
                                string16,string17,string18,string19,string20
                            from
                                vTypesParamNames
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvTypes.DataSource = lTable;

                    dgvTypes.Columns[0].HeaderText = "ID";
                    dgvTypes.Columns[1].HeaderText = "Name";

                    dgvTypes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // Hide parameter's names
                    for (int i = 1; i <= 10; i++)
                        dgvTypes.Columns["int" + i.ToString()].Visible = false;
                    for (int i = 11; i <= 20; i++)
                        dgvTypes.Columns["string" + i.ToString()].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Refresh dataGrid
        public void refreshGrid()
        {
            this.loadDataGrid();
            dgvTypes.AutoResizeColumns();
        }

        // Permissions
        private void setPermissions() {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            if (LoginData.havePermission("ADD_COMPONENTS_TYPES", LoginData.AccessControl.YES))
                btnAdd.Enabled = true;
            if (LoginData.havePermission("EDIT_COMPONENTS_TYPES", LoginData.AccessControl.YES))
                btnEdit.Enabled = true;
            if (LoginData.havePermission("DELETE_COMPONENTS_TYPES", LoginData.AccessControl.YES))
                btnDelete.Enabled = true;
        }

        //
        // BUTTONS
        // 

        // Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditForms.TypesEditForm childForm = new EditForms.TypesEditForm();

            // Fill data
            childForm.txbID.Enabled = false;

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForms.TypesEditForm childForm = new EditForms.TypesEditForm();

            // Fill data
            childForm.txbID.Text = this.dgvTypes.SelectedRows[0].Cells["typID"].Value.ToString();
            childForm.txbID.Enabled = false;

            childForm.txbName.Text = this.dgvTypes.SelectedRows[0].Cells["typName"].Value.ToString(); ;

            // Fill parameter's names
            {
                childForm.txbIntParam1.Text = this.dgvTypes.SelectedRows[0].Cells["int1"].Value.ToString();
                childForm.txbIntParam2.Text = this.dgvTypes.SelectedRows[0].Cells["int2"].Value.ToString();
                childForm.txbIntParam3.Text = this.dgvTypes.SelectedRows[0].Cells["int3"].Value.ToString();
                childForm.txbIntParam4.Text = this.dgvTypes.SelectedRows[0].Cells["int4"].Value.ToString();
                childForm.txbIntParam5.Text = this.dgvTypes.SelectedRows[0].Cells["int5"].Value.ToString();

                childForm.txbIntParam6.Text = this.dgvTypes.SelectedRows[0].Cells["int6"].Value.ToString();
                childForm.txbIntParam7.Text = this.dgvTypes.SelectedRows[0].Cells["int7"].Value.ToString();
                childForm.txbIntParam8.Text = this.dgvTypes.SelectedRows[0].Cells["int8"].Value.ToString();
                childForm.txbIntParam9.Text = this.dgvTypes.SelectedRows[0].Cells["int9"].Value.ToString();
                childForm.txbIntParam10.Text = this.dgvTypes.SelectedRows[0].Cells["int10"].Value.ToString();

                childForm.txbStringParam1.Text = this.dgvTypes.SelectedRows[0].Cells["string11"].Value.ToString();
                childForm.txbStringParam2.Text = this.dgvTypes.SelectedRows[0].Cells["string12"].Value.ToString();
                childForm.txbStringParam3.Text = this.dgvTypes.SelectedRows[0].Cells["string13"].Value.ToString();
                childForm.txbStringParam4.Text = this.dgvTypes.SelectedRows[0].Cells["string14"].Value.ToString();
                childForm.txbStringParam5.Text = this.dgvTypes.SelectedRows[0].Cells["string15"].Value.ToString();

                childForm.txbStringParam6.Text = this.dgvTypes.SelectedRows[0].Cells["string16"].Value.ToString();
                childForm.txbStringParam7.Text = this.dgvTypes.SelectedRows[0].Cells["string17"].Value.ToString();
                childForm.txbStringParam8.Text = this.dgvTypes.SelectedRows[0].Cells["string18"].Value.ToString();
                childForm.txbStringParam9.Text = this.dgvTypes.SelectedRows[0].Cells["string19"].Value.ToString();
                childForm.txbStringParam10.Text = this.dgvTypes.SelectedRows[0].Cells["string20"].Value.ToString();
            }

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTypes.SelectedRows.Count == 0)
            {
                return;
            }

            string msgString = "Are you sure you want to delete this type and all associated data?";
            if (MessageBox.Show( msgString, "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            SqlCommand lSCmd;
            SqlParameter lID;
            SqlParameter lMsg;

            try
            {
                // deleteComponentType(@pID, @oMsg)
                lSCmd = new SqlCommand("deleteComponentType", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                // Define
                lID = lSCmd.Parameters.Add("@pID", SqlDbType.Int);
                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);

                lMsg.Direction = ParameterDirection.Output;

                // Values
                lSCmd.Parameters["@pID"].Value = this.dgvTypes.SelectedRows[0].Cells["typID"].Value;

                // Execute !
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Type deleted");
                    this.refreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
