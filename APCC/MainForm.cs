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
        //
        // VAR
        //

        //
        // INIT
        //
        public MainForm()
        {
            InitializeComponent();
        }

        // Otter module
        private void picOtter_Click(object sender, EventArgs e)
        {
            tipOtter.SetToolTip( this.picOtter, Otter.Click( this.ActiveMdiChild ) );
        }

        // On load
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.setPermissions();
            this.openLoginWindow();

            //TEST
            tipOtter.SetToolTip( this.picOtter, "Wyderka");
        }

        //
        // FORM
        //

        public void setPermissions()
        {
            // Hide all items
            bool lValue = false; // for debug

            foreach (ToolStripMenuItem Item in menuStrip.Items)
            {
                Item.Visible = lValue;

                foreach (ToolStripItem dropItem in Item.DropDownItems) {
                    dropItem.Visible = lValue;
                }
            }

            // Login button
            if (LoginData.Logged)
            {
                this.itemLogin.Visible = false;
                this.itemLogout.Visible = true;
            }
            else {
                this.itemLogin.Visible = true;
                this.itemLogout.Visible = false;
            }

            //
            // Set permissions
            //
            if (LoginData.havePermission("SHOW_ADMIN_PANEL", LoginData.AccessControl.YES))
                this.menuAdmin.Visible = true;
            if (LoginData.havePermission("SHOW_SHOW_PANEL", LoginData.AccessControl.YES))
                this.menuShow.Visible = true;
            if (LoginData.havePermission("SHOW_TOOLS_PANEL", LoginData.AccessControl.YES))
                this.menuTools.Visible = true;

            // menuShow
            if (LoginData.havePermission("SHOW_BUILDS", LoginData.AccessControl.YES))
                this.menuShow_Builds.Visible = true;
            if (LoginData.havePermission("SHOW_COMPONENTS", LoginData.AccessControl.YES))
                this.menuShow_Components.Visible = true;
            if (LoginData.havePermission("SHOW_STATISTICS", LoginData.AccessControl.ONLY_OWN) ||
                LoginData.havePermission("SHOW_STATISTICS", LoginData.AccessControl.YES) )
            {
                this.menuShow_Statistics.Visible = true;
                this.menuShow_Separator.Visible = true;
            }


            //menuAdmin
            if (LoginData.havePermission("SHOW_USERS", LoginData.AccessControl.YES))
                this.menuAdmin_Users.Visible = true;
            if (LoginData.havePermission("SHOW_COMPONENTS_TYPES", LoginData.AccessControl.YES))
                this.menuAdmin_Types.Visible = true;
            if (LoginData.havePermission("SHOW_ROLES", LoginData.AccessControl.YES))
                this.menuAdmin_Roles.Visible = true;
            if (LoginData.havePermission("SHOW_STATISTICS", LoginData.AccessControl.YES)){
                this.menuAdmin_Statistics.Visible = true;
                this.menuAdmin_Separator.Visible = true;
            }

            //menuTools
            if (LoginData.havePermission("SHOW_TOOLS_PANEL", LoginData.AccessControl.YES)){
                this.menuTools.Visible = true;
                this.menuTools_Options.Visible = true;
                this.menuTool_Profil.Visible = true;
            }

 
        }

        //
        // BUTTONS
        //

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Open login window
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

        // Open login button
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
                this.setPermissions();
                
                // Close all mdi windows 
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }

                this.statusStrip.Items[0].Text = "Logged out";
                this.openLoginWindow();
            }
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

        // Types manager
        private void componentTypeToolStripMenuItem_Click(object sender, EventArgs e)
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

        // Builds1
        private void buildsToolStripMenuItem_Click(object sender, EventArgs e)
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

        // Manage roles
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(Forms.RolesManagerForm), this);

            if (tmpForm == null)
            {
                Forms.RolesManagerForm loginForm = new Forms.RolesManagerForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        private void menuShow_Statistics_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(Forms.UserStatisticsForm), this);

            if (tmpForm == null)
            {
                Forms.UserStatisticsForm loginForm = new Forms.UserStatisticsForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        private void menuAdmin_Statistics_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(Forms.GlobalStatisticsForm), this);

            if (tmpForm == null)
            {
                Forms.GlobalStatisticsForm loginForm = new Forms.GlobalStatisticsForm();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        private void menuTools_Options_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(Forms.Options), this);

            if (tmpForm == null)
            {
                Forms.Options loginForm = new Forms.Options();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmpForm = Utilities.FindMdiFormByType(typeof(Forms.Options), this);
            
            if(tmpForm == null)
            {
                ProfilManage profilManageForm = new ProfilManage();
                profilManageForm.MdiParent = this;
                profilManageForm.Show();
            }
            else
            {
                tmpForm.Activate();
                tmpForm.WindowState = FormWindowState.Normal;
            }
        }
    }
}
