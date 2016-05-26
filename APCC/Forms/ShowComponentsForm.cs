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
    public partial class ShowComponentsForm : Form
    {
        //
        // VAR
        // 

        private bool cmbTypesFilled;
        private DataTable typesDataTable;

        //
        // INIT
        //

        public ShowComponentsForm()
        {
            InitializeComponent();
        }

        // On load
        private void ShowComponentsForm_Load(object sender, EventArgs e)
        {
            this.loadCmbTypes();
            this.refreshDgvComponentsList();

            this.setPermissions();
        }

        //
        // FORM
        //

        private void setPermissions() {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            if ( LoginData.havePermission("ADD_COMPONENTS", LoginData.AccessControl.YES) )
                btnAdd.Enabled = true;
            if (LoginData.havePermission("EDIT_COMPONENTS", LoginData.AccessControl.YES))
                btnEdit.Enabled = true;
            if (LoginData.havePermission("DELETE_COMPONENTS", LoginData.AccessControl.YES))
                btnDelete.Enabled = true;
        }

        // Refresh dgvComponentsList 
        public void refreshDgvComponentsList()
        {
            string lStmt;

            try
            {
                lStmt = "SELECT * FROM getComponentsByType(@pTypeID)";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                // Declare
                lCommand.Parameters.Add("@pTypeID", SqlDbType.Int);

                // Values
                lCommand.Parameters["@pTypeID"].Value = cmbType.SelectedValue;

                // Execute !
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
                // End reader
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Fill combobox with components types
        private void loadCmbTypes()
        {
            string lStmt;

            try
            {
                lStmt = @"
                            select
                                typID,
                                typName
                            from
                                TYPES
                         ";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {
                    this.typesDataTable = new DataTable();
                    typesDataTable.Load(lDataReader);

                    cmbType.DataSource = typesDataTable;

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

        // Refresh dgvComponentsList on type change 
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTypesFilled == true)
                this.refreshDgvComponentsList();
        }

        //
        // BUTTONS
        //

        // Add new
        private void button2_Click(object sender, EventArgs e)
        {
            EditForms.AddComponentForm childForm = new EditForms.AddComponentForm();

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvComponentsList.SelectedRows.Count != 1) { 
                return;
            }

            EditForms.AddComponentForm childForm = new EditForms.AddComponentForm();

            // Fill data
            childForm.txbID.Text = dgvComponentsList.SelectedRows[0].Cells["comID"].Value.ToString();
            childForm.txbName.Text = dgvComponentsList.SelectedRows[0].Cells["comName"].Value.ToString();

            childForm.cmbTypes.SelectedValue = dgvComponentsList.SelectedRows[0].Cells["comTypeID"].Value;
            childForm.cmbTypes.Enabled = false;

            for (int i = 0; i < 10; i++)
            {
                ((TextBox)childForm.textBoxes[i]).Text 
                    = dgvComponentsList.SelectedRows[0].Cells["comParamInt" + (i + 1).ToString()].Value.ToString();
            }

            for (int i = 0; i < 10; i++)
            {
                ((TextBox)childForm.textBoxes[i+10]).Text
                    = dgvComponentsList.SelectedRows[0].Cells["comParamString" + (i + 1).ToString()].Value.ToString();
            }


            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvComponentsList.SelectedRows.Count != 1)
            {
                return;
            }

            string msgString = "Are you sure to delete selected component?";
            if (MessageBox.Show( msgString, "Notification", MessageBoxButtons.YesNo) == DialogResult.No) {
                return;
            }

            SqlCommand lSCmd;
            SqlParameter lMsg;

            try
            {
                // deleteComponent(@pID, @oMsg)
                lSCmd = new SqlCommand("deleteComponent", SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                // Declare
                lSCmd.Parameters.Add("@pID", SqlDbType.Int);
                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 100);

                lMsg.Direction = ParameterDirection.Output;

                // Values
                lSCmd.Parameters["@pID"].Value = this.dgvComponentsList.SelectedRows[0].Cells["comID"].Value;

                // Execute !
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Component deleted!");
                    this.refreshDgvComponentsList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Close
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Show details
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvComponentsList.SelectedRows.Count != 1)
            {
                return;
            }

            int lComponentID = (int)dgvComponentsList.SelectedRows[0].Cells["comID"].Value;
            Description childForm = new Description(lComponentID);

            childForm.MdiParent = this.MdiParent;
            childForm.Show();
        }


    }
}
