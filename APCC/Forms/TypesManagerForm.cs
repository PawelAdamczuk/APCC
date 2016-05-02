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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
