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
        ArrayList labels;
        ArrayList textBoxes;
        DataTable tab = new DataTable();


        public AddComponentForm()
        {
            InitializeComponent();
        }

        private void AddComponentForm_Load(object sender, EventArgs e)
        {
            this.collectLabels();
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
                tab.Load(dr);
                comboBox_types.DataSource = tab;
                comboBox_types.DisplayMember = "typName";
                comboBox_types.ValueMember = "typID";
            }


        }

        //filling the labels with parameter names
        private void comboBox_types_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label typedLabel;
            for (int i = 0; i < 10; i++)
            {
                typedLabel = (Label)this.labels[i];
                typedLabel.Text = tab.Rows[this.comboBox_types.SelectedIndex]["int" + (i+1).ToString()].ToString();
            }

            for (int i = 0; i < 10; i++)
            {
                typedLabel = (Label)this.labels[i+10];
                typedLabel.Text = tab.Rows[this.comboBox_types.SelectedIndex]["string" + (i + 1 + 10).ToString()].ToString();
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

        private void button_add_Click(object sender, EventArgs e)
        {
            string cmdString;

            SqlCommand cmd;

            SqlParameter compID;
            SqlParameter typeID;
            SqlParameter componentName;
            SqlParameter stringArgsArray;
            SqlParameter intArgsArray;
            SqlParameter msg;

            try
            {
                cmdString = "saveComponent";
                cmd = new SqlCommand(cmdString, SqlConn.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                compID = cmd.Parameters.Add("@pID", SqlDbType.Int);
                compID.Direction = ParameterDirection.Output;

                typeID = cmd.Parameters.Add("@pTypeID", SqlDbType.Int);
                typeID.Direction = ParameterDirection.Input;

                componentName = cmd.Parameters.Add("@pName", SqlDbType.VarChar, 50);
                componentName.Direction = ParameterDirection.Input;

                stringArgsArray = cmd.Parameters.Add("@pStringArray", SqlDbType.Structured);
                intArgsArray = cmd.Parameters.Add("@pIntArray", SqlDbType.Structured);

                msg = cmd.Parameters.Add("@oMsg", SqlDbType.VarChar, 50);
                msg.Direction = ParameterDirection.Output;

                //cmd.Parameters["pTypeID"].Value = int.Parse(comboBox_types.SelectedValue.ToString());
                cmd.Parameters["@pTypeID"].Value = comboBox_types.SelectedValue;

                cmd.Parameters["@pName"].Value = this.textBox_componentName.Text;

                DataTable intTable = new DataTable();
                intTable.Columns.Add("id");
                intTable.Columns.Add("IntParam");
                TextBox typedTextBox;
                for (int i = 0; i < 10; i++)
                {
                    typedTextBox = (TextBox)this.textBoxes[i];
                    int temp = 0;
                    int.TryParse(typedTextBox.Text, out temp);
                    intTable.Rows.Add(i + 1, temp);
                }

                cmd.Parameters["@pIntArray"].Value = intTable;

                DataTable stringTable = new DataTable();
                stringTable.Columns.Add("id");
                stringTable.Columns.Add("ParamName");
                for (int i = 0; i < 10; i++)
                {
                    typedTextBox = (TextBox)this.textBoxes[i + 10];
                    stringTable.Rows.Add(i + 1, typedTextBox.Text);
                }

                cmd.Parameters["@pStringArray"].Value = stringTable;

                cmd.ExecuteNonQuery();

                if ( msg.Value.ToString() != "OK " )
                {
                    MessageBox.Show(msg.Value.ToString());
                }
                else{
                    MessageBox.Show("Data saved.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
