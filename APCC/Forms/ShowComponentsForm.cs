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
        // Var 
        // 
        private bool cmbTypesFilled;

        public ShowComponentsForm()
        {
            InitializeComponent();
        }

        // On load
        private void ShowComponentsForm_Load(object sender, EventArgs e)
        {
            this.loadCmbTypes();
            this.refreshDgvComponentsList();

        }

        // Refresh dgvComponentsList 
        private void refreshDgvComponentsList()
        {
            string lStmt;

            try
            {
                lStmt = @"
                            SELECT * FROM getComponentsByType(@pTypeID)
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pTypeID", SqlDbType.Int);
                lCommand.Parameters["@pTypeID"].Value = cmbType.SelectedValue;

                SqlDataReader lDataReader = lCommand.ExecuteReader();

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

                lDataReader.Close();
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

        // Refresh dgvComponentsList on type change 
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTypesFilled == true)
                this.refreshDgvComponentsList();

        }

        // Close
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
