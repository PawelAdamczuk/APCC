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
    public partial class GlobalStatisticsForm : Form
    {
        //
        // VAR
        //
        bool cmbUsersFilled = false;

        //
        // INIT
        //
        public GlobalStatisticsForm()
        {
            InitializeComponent();
        }

        // On load
        private void GlobalStatisticsForm_Load(object sender, EventArgs e)
        {
            this.loadCmbUsers();
            this.refreshDgvStats();

            this.refreshDgvGlobalStats();
        }

        //
        // FORM
        //
        private void loadCmbUsers() {
            string lStmt;

            try
            {
                lStmt = @"SELECT 
                            usrID, 
                            convert(varchar,usrFName)+' '+convert(varchar,usrSName) usrFullName 
                          FROM 
                            USERS";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    cmbUsers.DataSource = lTable;
                    cmbUsers.ValueMember = "usrID";
                    cmbUsers.DisplayMember = "usrFullName";

                    if (cmbUsers.Items.Count > 0) {
                        cmbUsers.SelectedIndex = 0;
                    }
                }

                cmbUsersFilled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refreshDgvGlobalStats()
        {
            string lStmt;
            try
            {
                lStmt = "SELECT * FROM vGlobalStats";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                { 
                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvGlobalStats.DataSource = lTable;

                    // Set columns
                    dgvGlobalStats.Columns["statName"].HeaderText = "Statistic";
                    dgvGlobalStats.Columns["statValue"].HeaderText = "Count";

                    dgvGlobalStats.Columns["statName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvGlobalStats.Columns["statValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refreshDgvStats()
        {
            if (cmbUsers.Items.Count < 1) {
                return;
            }

            string lStmt;
            try
            {
                lStmt = "SELECT * FROM vUserStats WHERE usrID = @pUserID";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pUserID", SqlDbType.Int);
                lCommand.Parameters["@pUserID"].Value = cmbUsers.SelectedValue;

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvStats.DataSource = lTable;

                    // Set columns
                    dgvStats.Columns["statName"].HeaderText = "Statistic";
                    dgvStats.Columns["statValue"].HeaderText = "Count";

                    dgvStats.Columns["usrID"].Visible = false;
                    dgvStats.Columns["statName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStats.Columns["statValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // On users ComboBox changed
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsersFilled)
            {
                this.refreshDgvStats();
            }
        }

        //
        // BUTTONS
        //
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
