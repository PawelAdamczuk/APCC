using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APCC.Forms;

namespace APCC
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        private PrivilegeMode privilegeMode = PrivilegeMode.CONFIGURATOR;
        enum PrivilegeMode : int
        {
            NULL = 0,
            CONFIGURATOR = 1,
            TESTER = 2,
            ADMINISTRATOR = 3
        }

        public void disableLogIn ()
        {
            menuStrip.Items["toolStripMenuItem_login"].Visible = false;
        }

        public void setPrivilegeMode(int _n)
        {
            if (_n < 0 || _n > 3)
                return;

            this.privilegeMode = (PrivilegeMode)_n;

            switch (this.privilegeMode)
            {
                case PrivilegeMode.NULL:
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = false;
                    }
                    this.disableLogIn();
                    break;
                case PrivilegeMode.CONFIGURATOR:
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = true;
                        foreach (var item2 in item.DropDownItems)
                        {
                            if (item2 is ToolStripDropDownItem)
                            {
                                ToolStripDropDownItem typed = (ToolStripDropDownItem)item2;
                                typed.Enabled = true;
                            }
                        }

                    }

                    menuStrip.Items["editMenu"].Enabled = false;
                    //menuStrip.Items["fileMenu"]. = false;
                    break;
                case PrivilegeMode.TESTER:
                    break;
                case PrivilegeMode.ADMINISTRATOR:
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = true;
                        foreach (var item2 in item.DropDownItems)
                        {
                            if(item2 is ToolStripDropDownItem)
                            {
                                ToolStripDropDownItem typed = (ToolStripDropDownItem)item2;
                                typed.Enabled = true;
                            }
                        }
                                
                    }
                    break;
                default:
                    break;
            }

        }

        public MainForm()
        {
            InitializeComponent();
            this.setPrivilegeMode(0);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem_login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.MdiParent = this;
            loginForm.Show();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersManageForm usersManageForm = new UsersManageForm();
            usersManageForm.MdiParent = this;
            usersManageForm.Show();
        }
    }
}
