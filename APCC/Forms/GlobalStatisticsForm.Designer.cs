namespace APCC.Forms
{
    partial class GlobalStatisticsForm
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
            this.tabGlobal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvGlobalStats = new System.Windows.Forms.DataGridView();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabGlobal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobalStats)).BeginInit();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGlobal
            // 
            this.tabGlobal.Controls.Add(this.tabPage1);
            this.tabGlobal.Controls.Add(this.tabUsers);
            this.tabGlobal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGlobal.Location = new System.Drawing.Point(0, 0);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.SelectedIndex = 0;
            this.tabGlobal.Size = new System.Drawing.Size(723, 363);
            this.tabGlobal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvGlobalStats);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(715, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Global";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvGlobalStats
            // 
            this.dgvGlobalStats.AllowUserToAddRows = false;
            this.dgvGlobalStats.AllowUserToDeleteRows = false;
            this.dgvGlobalStats.AllowUserToResizeColumns = false;
            this.dgvGlobalStats.AllowUserToResizeRows = false;
            this.dgvGlobalStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlobalStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGlobalStats.Location = new System.Drawing.Point(3, 3);
            this.dgvGlobalStats.MultiSelect = false;
            this.dgvGlobalStats.Name = "dgvGlobalStats";
            this.dgvGlobalStats.ReadOnly = true;
            this.dgvGlobalStats.RowHeadersVisible = false;
            this.dgvGlobalStats.RowTemplate.Height = 24;
            this.dgvGlobalStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGlobalStats.Size = new System.Drawing.Size(709, 328);
            this.dgvGlobalStats.TabIndex = 1;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.cmbUsers);
            this.tabUsers.Controls.Add(this.dgvStats);
            this.tabUsers.Controls.Add(this.label1);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(715, 334);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(52, 6);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(243, 24);
            this.cmbUsers.TabIndex = 8;
            this.cmbUsers.SelectionChangeCommitted += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.AllowUserToResizeColumns = false;
            this.dgvStats.AllowUserToResizeRows = false;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Location = new System.Drawing.Point(3, 36);
            this.dgvStats.MultiSelect = false;
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.dgvStats.RowTemplate.Height = 24;
            this.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStats.Size = new System.Drawing.Size(706, 295);
            this.dgvStats.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "User";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(593, 365);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 29);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GlobalStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 396);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabGlobal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GlobalStatisticsForm";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.GlobalStatisticsForm_Load);
            this.tabGlobal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobalStats)).EndInit();
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGlobal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGlobalStats;
        private System.Windows.Forms.ComboBox cmbUsers;
    }
}