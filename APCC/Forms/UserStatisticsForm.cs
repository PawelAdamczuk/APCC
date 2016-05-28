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
    public partial class UserStatisticsForm : Form
    {
        //
        // INIT
        //
        public UserStatisticsForm()
        {
            InitializeComponent();
        }

        // On load
        private void UserStatisticsForm_Load(object sender, EventArgs e)
        {
            txbID.Text = LoginData.GetUserID().ToString();
            txbUser.Text = LoginData.GetUserName();

            this.refreshDgvStats();
        }

        //
        // FORM
        //

        private void refreshDgvStats() {
            string lStmt;

            try
            {
                lStmt = "SELECT * FROM vUserStats WHERE usrID = @pUserID";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pUserID", SqlDbType.Int);
                lCommand.Parameters["@pUserID"].Value = LoginData.GetUserID();

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {

                    DataTable lTable = new DataTable();
                    lTable.Load(lDataReader);

                    dgvStats.DataSource = lTable;

                    // Set columns
                    dgvStats.Columns["usrID"].Visible = false;
                    dgvStats.Columns["statName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStats.Columns["statValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
