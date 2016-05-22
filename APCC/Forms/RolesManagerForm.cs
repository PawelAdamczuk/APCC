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
    public partial class RolesManagerForm : Form
    {
        public RolesManagerForm()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshDgvRoles()
        {
            string lStmt;

            try
            {
                lStmt = @"
                            SELECT
                                rlsID,
                                rlsName 
                            FROM 
                                ROLES
                            WHERE 
                                rlsID != 3 AND
                                rlsID != 0
                         ";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvRoles.DataSource = lTable;

                    dgvRoles.Columns["rlsID"].Visible = false;

                    dgvRoles.Columns["rlsName"].Visible = true;
                    dgvRoles.Columns["rlsName"].HeaderText = "Name";
                    dgvRoles.Columns["rlsName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // On load
        private void RolesEditForm_Load(object sender, EventArgs e)
        {

            this.refreshDgvRoles();
        }

        // Add role
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        // Edit role
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        // Delete role
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
