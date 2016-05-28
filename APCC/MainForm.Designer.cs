namespace APCC
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShow_Builds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShow_Components = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShow_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.menuShow_Statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin_Users = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin_Roles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin_Types = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.menuAdmin_Statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.picOtter = new System.Windows.Forms.PictureBox();
            this.tipOtter = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOtter)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShow,
            this.menuAdmin,
            this.menuTools,
            this.itemLogin,
            this.itemLogout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(927, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // menuShow
            // 
            this.menuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShow_Builds,
            this.menuShow_Components,
            this.menuShow_Separator,
            this.menuShow_Statistics});
            this.menuShow.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size(48, 20);
            this.menuShow.Text = "&Show";
            this.menuShow.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // menuShow_Builds
            // 
            this.menuShow_Builds.Name = "menuShow_Builds";
            this.menuShow_Builds.Size = new System.Drawing.Size(143, 22);
            this.menuShow_Builds.Text = "Builds";
            this.menuShow_Builds.Click += new System.EventHandler(this.buildsToolStripMenuItem_Click);
            // 
            // menuShow_Components
            // 
            this.menuShow_Components.Name = "menuShow_Components";
            this.menuShow_Components.Size = new System.Drawing.Size(143, 22);
            this.menuShow_Components.Text = "Components";
            this.menuShow_Components.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // menuShow_Separator
            // 
            this.menuShow_Separator.Name = "menuShow_Separator";
            this.menuShow_Separator.Size = new System.Drawing.Size(140, 6);
            // 
            // menuShow_Statistics
            // 
            this.menuShow_Statistics.Name = "menuShow_Statistics";
            this.menuShow_Statistics.Size = new System.Drawing.Size(143, 22);
            this.menuShow_Statistics.Text = "Statistics";
            this.menuShow_Statistics.Click += new System.EventHandler(this.menuShow_Statistics_Click);
            // 
            // menuAdmin
            // 
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdmin_Users,
            this.menuAdmin_Roles,
            this.menuAdmin_Types,
            this.menuAdmin_Separator,
            this.menuAdmin_Statistics});
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(98, 20);
            this.menuAdmin.Text = "Administration";
            // 
            // menuAdmin_Users
            // 
            this.menuAdmin_Users.Name = "menuAdmin_Users";
            this.menuAdmin_Users.Size = new System.Drawing.Size(191, 22);
            this.menuAdmin_Users.Text = "Users";
            this.menuAdmin_Users.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // menuAdmin_Roles
            // 
            this.menuAdmin_Roles.Name = "menuAdmin_Roles";
            this.menuAdmin_Roles.Size = new System.Drawing.Size(191, 22);
            this.menuAdmin_Roles.Text = "Roles and permissions";
            this.menuAdmin_Roles.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // menuAdmin_Types
            // 
            this.menuAdmin_Types.Name = "menuAdmin_Types";
            this.menuAdmin_Types.Size = new System.Drawing.Size(191, 22);
            this.menuAdmin_Types.Text = "Component types";
            this.menuAdmin_Types.Click += new System.EventHandler(this.componentTypeToolStripMenuItem_Click);
            // 
            // menuAdmin_Separator
            // 
            this.menuAdmin_Separator.Name = "menuAdmin_Separator";
            this.menuAdmin_Separator.Size = new System.Drawing.Size(188, 6);
            // 
            // menuAdmin_Statistics
            // 
            this.menuAdmin_Statistics.Name = "menuAdmin_Statistics";
            this.menuAdmin_Statistics.Size = new System.Drawing.Size(191, 22);
            this.menuAdmin_Statistics.Text = "Global statistics";
            this.menuAdmin_Statistics.Click += new System.EventHandler(this.menuAdmin_Statistics_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTools_Options,
            this.profilToolStripMenuItem});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuTools_Options
            // 
            this.menuTools_Options.Name = "menuTools_Options";
            this.menuTools_Options.Size = new System.Drawing.Size(152, 22);
            this.menuTools_Options.Text = "&Options";
            this.menuTools_Options.Click += new System.EventHandler(this.menuTools_Options_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Click += new System.EventHandler(this.profilToolStripMenuItem_Click);
            // 
            // itemLogin
            // 
            this.itemLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itemLogin.Name = "itemLogin";
            this.itemLogin.Size = new System.Drawing.Size(52, 20);
            this.itemLogin.Text = "Log in";
            this.itemLogin.Click += new System.EventHandler(this.toolStripMenuItem_login_Click);
            // 
            // itemLogout
            // 
            this.itemLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itemLogout.Name = "itemLogout";
            this.itemLogout.Size = new System.Drawing.Size(60, 20);
            this.itemLogout.Text = "Log out";
            this.itemLogout.Click += new System.EventHandler(this.toolStripMenuItem_LogOut_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 553);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(927, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // picOtter
            // 
            this.picOtter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picOtter.BackColor = System.Drawing.Color.Transparent;
            this.picOtter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picOtter.BackgroundImage")));
            this.picOtter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOtter.Location = new System.Drawing.Point(0, 440);
            this.picOtter.Margin = new System.Windows.Forms.Padding(2);
            this.picOtter.Name = "picOtter";
            this.picOtter.Size = new System.Drawing.Size(112, 113);
            this.picOtter.TabIndex = 6;
            this.picOtter.TabStop = false;
            this.picOtter.Visible = false;
            this.picOtter.Click += new System.EventHandler(this.picOtter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(927, 575);
            this.Controls.Add(this.picOtter);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APCC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOtter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuTools_Options;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem itemLogin;
        private System.Windows.Forms.ToolStripMenuItem menuShow_Builds;
        private System.Windows.Forms.ToolStripMenuItem menuShow_Components;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem itemLogout;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin_Users;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin_Types;
        private System.Windows.Forms.ToolStripSeparator menuAdmin_Separator;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin_Roles;
        private System.Windows.Forms.ToolStripSeparator menuShow_Separator;
        private System.Windows.Forms.ToolStripMenuItem menuShow_Statistics;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin_Statistics;
        public System.Windows.Forms.PictureBox picOtter;
        private System.Windows.Forms.ToolTip tipOtter;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
    }
}



