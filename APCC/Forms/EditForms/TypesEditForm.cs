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
                SqlParameter lMsg;
            
                try
                {
                    // (@pID, @pName, @oMsg)
                    lStmt = "save_component_type";
                    lSCmd = new SqlCommand(lStmt, SqlConn.Connection);
                    lSCmd.CommandType = CommandType.StoredProcedure;

                    lID = lSCmd.Parameters.Add("@pID", SqlDbType.Int);
                    lID.Direction = ParameterDirection.InputOutput;

                    lName = lSCmd.Parameters.Add("@pName", SqlDbType.VarChar, 50);

                    lMsg = lSCmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);
                    lMsg.Direction = ParameterDirection.Output;                    

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

                    lSCmd.ExecuteNonQuery();

                    if (lMsg.Value.ToString() != "OK")
                    {
                        MessageBox.Show(lMsg.Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Dane zostały zapisane !");
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
    }
}
