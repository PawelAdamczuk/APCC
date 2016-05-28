namespace APCC.Forms.EditForms
{
    partial class RoleEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbDetails = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(664, 79);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(157, 22);
            this.txbName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Permissions";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(664, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 45);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(664, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(661, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID";
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(664, 34);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(157, 22);
            this.txbID.TabIndex = 2;
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToDeleteRows = false;
            this.dgvPermissions.AllowUserToResizeRows = false;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.Location = new System.Drawing.Point(12, 34);
            this.dgvPermissions.MultiSelect = false;
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.RowHeadersVisible = false;
            this.dgvPermissions.RowTemplate.Height = 24;
            this.dgvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissions.Size = new System.Drawing.Size(643, 317);
            this.dgvPermissions.TabIndex = 4;
            this.dgvPermissions.SelectionChanged += new System.EventHandler(this.dgvPermissions_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbDetails);
            this.groupBox1.Location = new System.Drawing.Point(12, 357);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 92);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // txbDetails
            // 
            this.txbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbDetails.Enabled = false;
            this.txbDetails.Location = new System.Drawing.Point(3, 18);
            this.txbDetails.Name = "txbDetails";
            this.txbDetails.ReadOnly = true;
            this.txbDetails.Size = new System.Drawing.Size(637, 71);
            this.txbDetails.TabIndex = 0;
            this.txbDetails.Text = "";
            // 
            // RoleEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(828, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPermissions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txbID);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RoleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit role";
            this.Load += new System.EventHandler(this.RoleEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPermissions;
        public System.Windows.Forms.TextBox txbName;
        public System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txbDetails;
    }
}