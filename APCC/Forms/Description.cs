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
    public partial class Description : Form
    {
        //
        // VAR
        //

        private int idComponents;

        //
        // INIT
        //

        public Description(int components)
        {
            idComponents = components;
            InitializeComponent();
        }

        private void Description_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Utilities.getComponentDescription(idComponents);
        }

        //
        // FORM
        //

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    
    }
}
