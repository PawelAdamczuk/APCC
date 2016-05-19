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
            this.button1 = new System.Windows.Forms.Button();
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
            this.cmbType.Size = new System.Drawing.Size(210, 24);
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
            this.dgvComponentsList.Location = new System.Drawing.Point(223, 4);
            this.dgvComponentsList.MultiSelect = false;
            this.dgvComponentsList.Name = "dgvComponentsList";
            this.dgvComponentsList.ReadOnly = true;
            this.dgvComponentsList.RowHeadersVisible = false;
            this.dgvComponentsList.RowTemplate.Height = 24;
            this.dgvComponentsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponentsList.Size = new System.Drawing.Size(904, 536);
            this.dgvComponentsList.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowComponentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.dgvComponentsList);
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
        private System.Windows.Forms.Button button1;
    }
}