namespace APCC.Forms
{
    partial class ShowComponentsForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dgvComponentsList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentsList)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Component\'s type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(7, 35);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(213, 24);
            this.cmbType.TabIndex = 4;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // dgvComponentsList
            // 
            this.dgvComponentsList.AllowUserToAddRows = false;
            this.dgvComponentsList.AllowUserToDeleteRows = false;
            this.dgvComponentsList.AllowUserToOrderColumns = true;
            this.dgvComponentsList.AllowUserToResizeRows = false;
            this.dgvComponentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentsList.Location = new System.Drawing.Point(226, 4);
            this.dgvComponentsList.MultiSelect = false;
            this.dgvComponentsList.Name = "dgvComponentsList";
            this.dgvComponentsList.ReadOnly = true;
            this.dgvComponentsList.RowHeadersVisible = false;
            this.dgvComponentsList.RowTemplate.Height = 24;
            this.dgvComponentsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponentsList.Size = new System.Drawing.Size(901, 536);
            this.dgvComponentsList.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(7, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(213, 44);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(119, 385);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(101, 61);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 44);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 435);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 44);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(119, 452);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ShowComponentsForm
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1130, 545);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.dgvComponentsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShowComponentsForm";
            this.Text = "Coponents list";
            this.Load += new System.EventHandler(this.ShowComponentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DataGridView dgvComponentsList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}