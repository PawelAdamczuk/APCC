namespace APCC.Forms.EditForms
{
    partial class BuildEditForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxAccept = new System.Windows.Forms.CheckBox();
            this.txbTesterName = new System.Windows.Forms.TextBox();
            this.txbID = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbCreatorName = new System.Windows.Forms.TextBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.rtxDescription = new System.Windows.Forms.RichTextBox();
            this.dgvComponents = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.labLog = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dgvComponentsList = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentsList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1144, 603);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnMinus);
            this.tabPage1.Controls.Add(this.btnPlus);
            this.tabPage1.Controls.Add(this.btnClearAll);
            this.tabPage1.Controls.Add(this.rtxDescription);
            this.tabPage1.Controls.Add(this.dgvComponents);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1136, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Summary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxAccept);
            this.groupBox1.Controls.Add(this.txbTesterName);
            this.groupBox1.Controls.Add(this.txbID);
            this.groupBox1.Controls.Add(this.txbName);
            this.groupBox1.Controls.Add(this.txbCreatorName);
            this.groupBox1.Controls.Add(this.labStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(583, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 211);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // cbxAccept
            // 
            this.cbxAccept.AutoSize = true;
            this.cbxAccept.Location = new System.Drawing.Point(368, 172);
            this.cbxAccept.Name = "cbxAccept";
            this.cbxAccept.Size = new System.Drawing.Size(18, 17);
            this.cbxAccept.TabIndex = 2;
            this.cbxAccept.UseVisualStyleBackColor = true;
            this.cbxAccept.Click += new System.EventHandler(this.cbxAccept_CheckedChanged);
            // 
            // txbTesterName
            // 
            this.txbTesterName.Enabled = false;
            this.txbTesterName.Location = new System.Drawing.Point(93, 124);
            this.txbTesterName.Name = "txbTesterName";
            this.txbTesterName.Size = new System.Drawing.Size(289, 22);
            this.txbTesterName.TabIndex = 1;
            // 
            // txbID
            // 
            this.txbID.Enabled = false;
            this.txbID.Location = new System.Drawing.Point(93, 21);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(289, 22);
            this.txbID.TabIndex = 1;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(93, 68);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(289, 22);
            this.txbName.TabIndex = 1;
            // 
            // txbCreatorName
            // 
            this.txbCreatorName.Enabled = false;
            this.txbCreatorName.Location = new System.Drawing.Point(93, 96);
            this.txbCreatorName.Name = "txbCreatorName";
            this.txbCreatorName.Size = new System.Drawing.Size(289, 22);
            this.txbCreatorName.TabIndex = 1;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labStatus.Location = new System.Drawing.Point(90, 172);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(73, 17);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tester";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Creator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(988, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(988, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(469, 539);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 27);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(8, 539);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(30, 27);
            this.btnMinus.TabIndex = 5;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(43, 539);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(30, 27);
            this.btnPlus.TabIndex = 5;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(355, 539);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(108, 27);
            this.btnClearAll.TabIndex = 5;
            this.btnClearAll.Text = "Clear all";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // rtxDescription
            // 
            this.rtxDescription.Location = new System.Drawing.Point(583, 220);
            this.rtxDescription.Name = "rtxDescription";
            this.rtxDescription.ReadOnly = true;
            this.rtxDescription.Size = new System.Drawing.Size(547, 346);
            this.rtxDescription.TabIndex = 4;
            this.rtxDescription.Text = "";
            // 
            // dgvComponents
            // 
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.AllowUserToOrderColumns = true;
            this.dgvComponents.AllowUserToResizeRows = false;
            this.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Location = new System.Drawing.Point(8, 6);
            this.dgvComponents.MultiSelect = false;
            this.dgvComponents.Name = "dgvComponents";
            this.dgvComponents.ReadOnly = true;
            this.dgvComponents.RowHeadersVisible = false;
            this.dgvComponents.RowTemplate.Height = 24;
            this.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponents.Size = new System.Drawing.Size(569, 527);
            this.dgvComponents.TabIndex = 3;
            this.dgvComponents.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvComponents_RowsRemoved);
            this.dgvComponents.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvComponents_RowStateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.labLog);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmbType);
            this.tabPage2.Controls.Add(this.dgvComponentsList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1136, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Components";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(224, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Log:";
            // 
            // labLog
            // 
            this.labLog.AutoSize = true;
            this.labLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labLog.Location = new System.Drawing.Point(270, 549);
            this.labLog.Name = "labLog";
            this.labLog.Size = new System.Drawing.Size(0, 17);
            this.labLog.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 514);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(212, 52);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Component\'s type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(8, 37);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(210, 24);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // dgvComponentsList
            // 
            this.dgvComponentsList.AllowUserToAddRows = false;
            this.dgvComponentsList.AllowUserToDeleteRows = false;
            this.dgvComponentsList.AllowUserToOrderColumns = true;
            this.dgvComponentsList.AllowUserToResizeRows = false;
            this.dgvComponentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentsList.Location = new System.Drawing.Point(224, 6);
            this.dgvComponentsList.MultiSelect = false;
            this.dgvComponentsList.Name = "dgvComponentsList";
            this.dgvComponentsList.ReadOnly = true;
            this.dgvComponentsList.RowHeadersVisible = false;
            this.dgvComponentsList.RowTemplate.Height = 24;
            this.dgvComponentsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponentsList.Size = new System.Drawing.Size(904, 536);
            this.dgvComponentsList.TabIndex = 0;
            // 
            // BuildEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1144, 603);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BuildEditForm";
            this.Text = "Build edition";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuildEditForm_FormClosed);
            this.Load += new System.EventHandler(this.BuildEditForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.RichTextBox rtxDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.DataGridView dgvComponentsList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txbID;
        public System.Windows.Forms.TextBox txbTesterName;
        public System.Windows.Forms.TextBox txbName;
        public System.Windows.Forms.TextBox txbCreatorName;
        public System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labLog;
        public System.Windows.Forms.CheckBox cbxAccept;
    }
}