using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC.Forms
{
    public partial class Options : Form
    {
        //
        // INIT
        //

        public Options()
        {
            InitializeComponent();
        }

        internal Properties.Resources Resources
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        // On load
        private void Options_Load(object sender, EventArgs e)
        {
            cbxOtterOption.Checked = ((MainForm)this.MdiParent).picOtter.Visible;
        }

        //
        // BUTTONS
        //

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxOtterOption_CheckedChanged(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).picOtter.Visible = cbxOtterOption.Checked;
        }
    }
}
