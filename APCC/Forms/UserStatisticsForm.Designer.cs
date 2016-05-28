namespace APCC.Forms
{
    partial class UserStatisticsForm
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
            this.txbID = new System.Windows.Forms.TextBox();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.SuspendLayout();
            // 
            // txbID
            // 
            this.txbID.Enabled = false;
            this.txbID.Location = new System.Drawing.Point(39, 15);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(39, 22);
            this.txbID.TabIndex = 0;
            // 
            // txbUser
            // 
            this.txbUser.Enabled = false;
            this.txbUser.Location = new System.Drawing.Point(128, 15);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(200, 22);
            this.txbUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStats);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 267);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.AllowUserToResizeColumns = false;
            this.dgvStats.AllowUserToResizeRows = false;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.ColumnHeadersVisible = false;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Location = new System.Drawing.Point(3, 18);
            this.dgvStats.MultiSelect = false;
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.RowTemplate.Height = 24;
            this.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStats.Size = new System.Drawing.Size(693, 246);
            this.dgvStats.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(585, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(723, 322);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.txbID);
            this.Name = "UserStatisticsForm";
            this.Text = "User statistics";
            this.Load += new System.EventHandler(this.UserStatisticsForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.Button btnClose;
    }
}