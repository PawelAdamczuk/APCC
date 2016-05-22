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
    public partial class TypesEditForm : Form
    {
        public TypesEditForm()
        {
            InitializeComponent();
        }

        // Save
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string lStmt;

            SqlCommand lSCmd;

            SqlParameter lID;
            SqlParameter lName;
            SqlParameter lStringArray;
            SqlParameter lIntArray;
            SqlParameter lMsg;

            try
            {
                // (@pID, @pName, @pIntList, @pStringList, @oMsg)
                lStmt = "saveComponentType";
                lSCmd = new SqlCommand(lStmt, SqlConn.Connection);
                lSCmd.CommandType = CommandType.StoredProcedure;

                // Define parameters
                lID = lSCmd.Parameters.Add("@pID", SqlDbType.Int);
                lID.Direction = ParameterDirection.InputOutput;

                lName = lSCmd.Parameters.Add("@pName", SqlDbType.VarChar, 50);

                lIntArray = lSCmd.Parameters.Add("@pIntArray", SqlDbType.Structured);
                lStringArray = lSCmd.Parameters.Add("@pStringArray", SqlDbType.Structured);

                lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);
                lMsg.Direction = ParameterDirection.Output;                    

                // Fill parameters
                // lID
                if (txbID.Text == "")
                {
                    lSCmd.Parameters["@pID"].Value = DBNull.Value;
                }
                else
                {
                    lSCmd.Parameters["@pID"].Value = int.Parse(txbID.Text);
                }
                
                // lName
                lSCmd.Parameters["@pName"].Value = txbName.Text;

                // lParams
                DataTable intTable = new DataTable();
                intTable.Columns.Add("id");
                intTable.Columns.Add("ParamName");
                {
                    intTable.Rows.Add(1, txbIntParam1.Text);
                    intTable.Rows.Add(2, txbIntParam2.Text);
                    intTable.Rows.Add(3, txbIntParam3.Text);
                    intTable.Rows.Add(4, txbIntParam4.Text);
                    intTable.Rows.Add(5, txbIntParam5.Text);
                    intTable.Rows.Add(6, txbIntParam6.Text);
                    intTable.Rows.Add(7, txbIntParam7.Text);
                    intTable.Rows.Add(8, txbIntParam8.Text);
                    intTable.Rows.Add(9, txbIntParam9.Text);
                    intTable.Rows.Add(10, txbIntParam10.Text);
                }

                lSCmd.Parameters["@pIntArray"].Value = intTable;

                DataTable stringTable = new DataTable();
                stringTable.Columns.Add("id");
                stringTable.Columns.Add("ParamName");
                {
                    stringTable.Rows.Add(1, txbStringParam1.Text);
                    stringTable.Rows.Add(2, txbStringParam2.Text);
                    stringTable.Rows.Add(3, txbStringParam3.Text);
                    stringTable.Rows.Add(4, txbStringParam4.Text);
                    stringTable.Rows.Add(5, txbStringParam5.Text);
                    stringTable.Rows.Add(6, txbStringParam6.Text);
                    stringTable.Rows.Add(7, txbStringParam7.Text);
                    stringTable.Rows.Add(8, txbStringParam8.Text);
                    stringTable.Rows.Add(9, txbStringParam9.Text);
                    stringTable.Rows.Add(10, txbStringParam10.Text);
                }

                lSCmd.Parameters["@pStringArray"].Value = stringTable;

                // EXECUTE !! 
                lSCmd.ExecuteNonQuery();

                if (lMsg.Value.ToString() != "OK")
                {
                    MessageBox.Show(lMsg.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Data saved!");
                    txbID.Text = lID.Value.ToString();

                    ((TypesManagerForm)this.Owner).refreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypesEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
