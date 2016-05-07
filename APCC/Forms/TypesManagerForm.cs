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
        public TypesManagerForm()
        {
            InitializeComponent();
        }

        // Load dataGridView for ComponentTypes
        private void loadDataGrid()
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
                SqlDataReader lDataReader = lCommand.ExecuteReader();

                DataTable lTable = new DataTable();
                lTable.Load(lDataReader);

                dgvTypes.DataSource = lTable;

                dgvTypes.Columns[0].HeaderText = "ID";
                dgvTypes.Columns[1].HeaderText = "Name";

                dgvTypes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        // On Load
        private void TypesManagerForm_Load(object sender, EventArgs e)
        {
            this.loadDataGrid();
            dgvTypes.AutoResizeColumns();
        }

        // **************
        // *** BUTTONS
        // **************

        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForms.TypesEditForm childForm = new EditForms.TypesEditForm();

            // Fill type data
            childForm.txbID.Text = this.dgvTypes.SelectedRows[0].Cells["typID"].Value.ToString();
            childForm.txbID.Enabled = false;

            childForm.txbName.Text = this.dgvTypes.SelectedRows[0].Cells["typName"].Value.ToString(); ;

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditForms.TypesEditForm childForm = new EditForms.TypesEditForm();

            childForm.txbID.Enabled = false;

            childForm.Owner = this;
            childForm.ShowDialog();
        }

        // Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

    }
}
