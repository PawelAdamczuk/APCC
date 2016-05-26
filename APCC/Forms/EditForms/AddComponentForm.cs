using System;
using System.Collections;
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
    public partial class AddComponentForm : Form
    {
        //
        // VAR
        //

        public ArrayList labels;
        public ArrayList textBoxes;
        DataTable tabTypes = new DataTable();

        //
        // INIT
        //

        public AddComponentForm()
        {
            InitializeComponent();

            this.collectLabels();
            this.loadTypes();
        }

        // On load
        private void AddComponentForm_Load(object sender, EventArgs e)
        {
            txbID.Enabled = false;
        }

        //
        // FORM
        //

        // Load types to combobox
        private void loadTypes() {
            string queryStr = @"
                            select
                                typID,
                                typName,
                                int1,int2,int3,int4,int5,
                                int6,int7,int8,int9,int10,
                                string11,string12,string13,string14,string15,
                                string16,string17,string18,string19,string20
                            from
                                vTypesParamNames
                         ";
            SqlCommand com = new SqlCommand(queryStr, SqlConn.Connection);
            using (SqlDataReader dr = com.ExecuteReader())
            {
                tabTypes.Load(dr);

                cmbTypes.DataSource = tabTypes;
                cmbTypes.DisplayMember = "typName";
                cmbTypes.ValueMember = "typID";
            }
        }

        // Filling the labels with parameter names
        private void comboBox_types_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label typedLabel;
            for (int i = 0; i < 10; i++)
            {
                typedLabel = (Label)this.labels[i];
                typedLabel.Text = tabTypes.Rows[this.cmbTypes.SelectedIndex]["int" + (i+1).ToString()].ToString();
            }

            for (int i = 0; i < 10; i++)
            {
                typedLabel = (Label)this.labels[i+10];
                typedLabel.Text = tabTypes.Rows[this.cmbTypes.SelectedIndex]["string" + (i + 1 + 10).ToString()].ToString();
            }
            //label1.Text = tab.Rows[this.comboBox_types.SelectedIndex]["int1"].ToString();

            TextBox typedTextBox;
            for (int i = 0; i < 20; i++)
            {
                typedLabel = (Label)this.labels[i];
                typedTextBox = (TextBox)textBoxes[i];

                if (typedLabel.Text.Equals(""))
                    typedTextBox.Visible = false;
                else
                    typedTextBox.Visible = true;
            }
        }

        private void collectLabels()
        {
            this.labels = new ArrayList();
            this.labels.Add(this.label1);
            this.labels.Add(this.label2);
            this.labels.Add(this.label3);
            this.labels.Add(this.label4);
            this.labels.Add(this.label5);
            this.labels.Add(this.label6);
            this.labels.Add(this.label7);
            this.labels.Add(this.label8);
            this.labels.Add(this.label9);
            this.labels.Add(this.label10);
            this.labels.Add(this.label11);
            this.labels.Add(this.label12);
            this.labels.Add(this.label13);
            this.labels.Add(this.label14);
            this.labels.Add(this.label15);
            this.labels.Add(this.label16);
            this.labels.Add(this.label17);
            this.labels.Add(this.label18);
            this.labels.Add(this.label19);
            this.labels.Add(this.label20);

            this.textBoxes = new ArrayList();
            this.textBoxes.Add(this.textBox1);
            this.textBoxes.Add(this.textBox2);
            this.textBoxes.Add(this.textBox3);
            this.textBoxes.Add(this.textBox4);
            this.textBoxes.Add(this.textBox5);
            this.textBoxes.Add(this.textBox6);
            this.textBoxes.Add(this.textBox7);
            this.textBoxes.Add(this.textBox8);
            this.textBoxes.Add(this.textBox9);
            this.textBoxes.Add(this.textBox10);
            this.textBoxes.Add(this.textBox11);
            this.textBoxes.Add(this.textBox12);
            this.textBoxes.Add(this.textBox13);
            this.textBoxes.Add(this.textBox14);
            this.textBoxes.Add(this.textBox15);
            this.textBoxes.Add(this.textBox16);
            this.textBoxes.Add(this.textBox17);
            this.textBoxes.Add(this.textBox18);
            this.textBoxes.Add(this.textBox19);
            this.textBoxes.Add(this.textBox20);

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //
        // BUTTONS
        //

        // Add
        private void button_add_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;

            SqlParameter compID;
            SqlParameter stringArgsArray;
            SqlParameter intArgsArray;
            SqlParameter msg;

            try
            {
                cmd = new SqlCommand("saveComponent", SqlConn.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Declare
                compID = cmd.Parameters.Add("@pID", SqlDbType.Int);
                cmd.Parameters.Add("@pTypeID", SqlDbType.Int);
                cmd.Parameters.Add("@pName", SqlDbType.VarChar, 50);
                stringArgsArray = cmd.Parameters.Add("@pStringArray", SqlDbType.Structured);
                intArgsArray = cmd.Parameters.Add("@pIntArray", SqlDbType.Structured);
                msg = cmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);

                compID.Direction = ParameterDirection.InputOutput;
                msg.Direction = ParameterDirection.Output;

                // Values
                int tmpParseID;
                if (Int32.TryParse(txbID.Text, out tmpParseID))
                {
                    cmd.Parameters["@pID"].Value = tmpParseID;
                }
                else {
                    cmd.Parameters["@pID"].Value = DBNull.Value;
                }

                cmd.Parameters["@pTypeID"].Value = cmbTypes.SelectedValue;
                cmd.Parameters["@pName"].Value = this.txbName.Text;
                
                DataTable intTable = new DataTable();
                intTable.Columns.Add("id");
                intTable.Columns.Add("IntParam");
                TextBox typedTextBox;
                for (int i = 0; i < 10; i++)
                {
                    typedTextBox = (TextBox)this.textBoxes[i];
                    int temp = 0;
                    if (int.TryParse(typedTextBox.Text, out temp) && typedTextBox.Text != "")
                    {
                        intTable.Rows.Add(i + 1, temp);
                    }
                    else {
                        intTable.Rows.Add(i + 1, DBNull.Value);
                    }
                }
                cmd.Parameters["@pIntArray"].Value = intTable;

                DataTable stringTable = new DataTable();
                stringTable.Columns.Add("id");
                stringTable.Columns.Add("ParamName");
                for (int i = 0; i < 10; i++)
                {
                    typedTextBox = (TextBox)this.textBoxes[i + 10];
                    if (typedTextBox.Text != "")
                    {
                        stringTable.Rows.Add(i + 1, typedTextBox.Text);
                    }
                    else {
                        stringTable.Rows.Add(i + 1, DBNull.Value);
                    }
                }
                cmd.Parameters["@pStringArray"].Value = stringTable;

                // Execute !
                cmd.ExecuteNonQuery();

                if ( msg.Value.ToString() != "OK" )
                {
                    MessageBox.Show(msg.Value.ToString());
                }
                else{
                    MessageBox.Show("Data saved.");
                    ((ShowComponentsForm)this.Owner).refreshDgvComponentsList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        // Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
