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

        public void setPrivilegeMode()
        {
            int _n = LoginData.GetUserRoleID();
            if (_n < 0 || _n > 3)
                return;

            this.privilegeMode = (PrivilegeMode)_n;

            switch (this.privilegeMode)
            {


                case PrivilegeMode.NULL:
                    // Unlogged user
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = false;
                    }

                    // Disable logout button
                    this.toolStripMenuItem_LogOut.Visible = false;

                    // Enable login button
                    toolStripMenuItem_login.Visible = true;
                    toolStripMenuItem_login.Enabled = true;
                    break;


                case PrivilegeMode.CONFIGURATOR:
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = false;
                        foreach (var item2 in item.DropDownItems)
                        {
                            if (item2 is ToolStripDropDownItem)
                            {
                                ToolStripDropDownItem typed = (ToolStripDropDownItem)item2;
                                typed.Enabled = false;
                            }
                        }

                    }

                    menuStrip.Items["editMenu"].Enabled = true;
                    ToolStripMenuItem typedItem1 = (ToolStripMenuItem)menuStrip.Items["editMenu"];
                    typedItem1.DropDownItems["buildToolStripMenuItem"].Enabled = true;

                    menuStrip.Items["fileMenu"].Enabled = true;
                    ToolStripMenuItem typedItem2 = (ToolStripMenuItem)menuStrip.Items["fileMenu"];
                    typedItem2.DropDownItems["componentsToolStripMenuItem"].Enabled = true;
                    break;


                case PrivilegeMode.TESTER:
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        item.Enabled = false;
                        foreach (var item2 in item.DropDownItems)
                        {
                            if (item2 is ToolStripDropDownItem)
                            {
                                ToolStripDropDownItem typed = (ToolStripDropDownItem)item2;
                                typed.Enabled = false;
                            }
                        }
                    }

                    menuStrip.Items["fileMenu"].Enabled = true;
                    ToolStripMenuItem typedItem4 = (ToolStripMenuItem)menuStrip.Items["fileMenu"];
                    typedItem4.DropDownItems["buildsToolStripMenuItem"].Enabled = true;
                    typedItem4.DropDownItems["componentsToolStripMenuItem"].Enabled = true;

                    menuStrip.Items["editMenu"].Enabled = true;
                    typedItem4 = (ToolStripMenuItem)menuStrip.Items["editMenu"];
                    typedItem4.DropDownItems["buildToolStripMenuItem"].Enabled = true;
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

            // Enable logout button
            if (this.privilegeMode != PrivilegeMode.NULL){
                this.toolStripMenuItem_LogOut.Visible = true;
                this.toolStripMenuItem_LogOut.Enabled = true;
            }

        }

        // Constructor 
        public MainForm()
        {
            InitializeComponent();

            this.setPrivilegeMode();

            this.openLoginWindow();
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

        //Open login window function
        private void openLoginWindow() {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(LoginForm), this);

            if (tmpForm == null)
            {
                LoginForm loginForm = new LoginForm(this);
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        //Open component types window function
        private void openComponentTypesWindow()
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(TypesManagerForm), this);

            if (tmpForm == null)
            {
                TypesManagerForm loginForm = new TypesManagerForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        // Open login window
        private void toolStripMenuItem_login_Click(object sender, EventArgs e)
        {
            this.openLoginWindow();
        }

        // Logout
        private void toolStripMenuItem_LogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoginData.LogOut();
                this.setPrivilegeMode();
            }

            // Close all mdi windows 
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }

            this.statusStrip.Items[0].Text = "Logged out";
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

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addingNewUserForm addingNewUserForm = new addingNewUserForm();
            addingNewUserForm.MdiParent = this;
            addingNewUserForm.Show();
        }

        // Open TypesManagerForm
        private void componentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openComponentTypesWindow();
        }

        private void buildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildsManagerForm showBuildsForm = new BuildsManagerForm();
            showBuildsForm.MdiParent = this;
            showBuildsForm.Show();

 
        }

        // Builds manager
        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(BuildsManagerForm), this);

            if (tmpForm == null)
            {
                BuildsManagerForm loginForm = new BuildsManagerForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        // Show components
        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(ShowComponentsForm), this);

            if (tmpForm == null)
            {
                ShowComponentsForm loginForm = new ShowComponentsForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

    }
}
