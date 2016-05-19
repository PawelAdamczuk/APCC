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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.buildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_login = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_LogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.componentTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builds2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.administrationToolStripMenuItem,
            this.toolsMenu,
            this.toolStripMenuItem_login,
            this.toolStripMenuItem_LogOut});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1236, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildsToolStripMenuItem,
            this.builds2ToolStripMenuItem,
            this.componentsToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(57, 24);
            this.fileMenu.Text = "&Show";
            this.fileMenu.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // buildsToolStripMenuItem
            // 
            this.buildsToolStripMenuItem.Name = "buildsToolStripMenuItem";
            this.buildsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.buildsToolStripMenuItem.Text = "Builds";
            this.buildsToolStripMenuItem.Click += new System.EventHandler(this.buildsToolStripMenuItem_Click);
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.componentsToolStripMenuItem.Text = "Components";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(57, 24);
            this.toolsMenu.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // toolStripMenuItem_login
            // 
            this.toolStripMenuItem_login.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripMenuItem_login.Name = "toolStripMenuItem_login";
            this.toolStripMenuItem_login.Size = new System.Drawing.Size(62, 24);
            this.toolStripMenuItem_login.Text = "Log in";
            this.toolStripMenuItem_login.Click += new System.EventHandler(this.toolStripMenuItem_login_Click);
            // 
            // toolStripMenuItem_LogOut
            // 
            this.toolStripMenuItem_LogOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem_LogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripMenuItem_LogOut.Name = "toolStripMenuItem_LogOut";
            this.toolStripMenuItem_LogOut.Size = new System.Drawing.Size(72, 24);
            this.toolStripMenuItem_LogOut.Text = "Log out";
            this.toolStripMenuItem_LogOut.Click += new System.EventHandler(this.toolStripMenuItem_LogOut_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 683);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
            this.statusStrip.Size = new System.Drawing.Size(1236, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem1,
            this.componentTypesToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(201, 26);
            this.usersToolStripMenuItem1.Text = "Users";
            this.usersToolStripMenuItem1.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // componentTypesToolStripMenuItem
            // 
            this.componentTypesToolStripMenuItem.Name = "componentTypesToolStripMenuItem";
            this.componentTypesToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.componentTypesToolStripMenuItem.Text = "Component types";
            this.componentTypesToolStripMenuItem.Click += new System.EventHandler(this.componentTypeToolStripMenuItem_Click);
            // 
            // builds2ToolStripMenuItem
            // 
            this.builds2ToolStripMenuItem.Name = "builds2ToolStripMenuItem";
            this.builds2ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.builds2ToolStripMenuItem.Text = "Builds2";
            this.builds2ToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 708);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APCC";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_login;
        private System.Windows.Forms.ToolStripMenuItem buildsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LogOut;
        private System.Windows.Forms.ToolStripMenuItem builds2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem componentTypesToolStripMenuItem;
    }
}



