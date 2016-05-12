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
        // Var
        //
        private bool cmbTypesFilled;

        public BuildEditForm()
        {
            cmbTypesFilled = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                SqlDataReader lDataReader = lCommand.ExecuteReader();

                DataTable lTable = new DataTable();
                lTable.Load(lDataReader);

                cmbType.DataSource = lTable;
                cmbType.DisplayMember = "typName";
                cmbType.ValueMember = "typID";

                this.cmbTypesFilled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Load dgvComponents
        private void refreshDgvComponents()
        {            
            // txbID is empty, probably new build
            if (txbID.Text == "")
                return;

            // txbID is not a number
            int lBuildID = 0;
            if (Int32.TryParse(txbID.Text, out lBuildID) == false)
            {
                MessageBox.Show("Error: Cannot convert build ID to number.");
                return;
            }

            string lStmt;

            try
            {
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
                lCommand.Parameters["@pBuildID"].Value = lBuildID;

                SqlDataReader lDataReader = lCommand.ExecuteReader();

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

                lDataReader.Close();
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

                SqlDataReader lDataReader = lCommand.ExecuteReader();

                DataTable lTable = new DataTable();
                lTable.Load(lDataReader);

                dgvComponentsList.DataSource = lTable;

                // Set autosize
                //for( int i = 0; i < dgvComponentsList.ColumnCount; i++ )
                //dgvComponentsList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvComponentsList.Columns["comID"].Visible = false;
                dgvComponentsList.Columns["comTypeID"].Visible = false;

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

                        } else {
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

                lDataReader.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // On load
        private void BuildEditForm_Load(object sender, EventArgs e)
        {
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

        // Change 
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( this.cmbTypesFilled == true )
                this.refreshDgvComponentsList();

        }

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
    }
}
