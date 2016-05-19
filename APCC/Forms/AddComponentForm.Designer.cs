namespace APCC.Forms
{
    partial class AddComponentForm
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
            this.comboBox_ = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_
            // 
            this.comboBox_.FormattingEnabled = true;
            this.comboBox_.Location = new System.Drawing.Point(17, 16);
            this.comboBox_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_.Name = "comboBox_";
            this.comboBox_.Size = new System.Drawing.Size(423, 24);
            this.comboBox_.TabIndex = 0;
            // 
            // AddComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 601);
            this.Controls.Add(this.comboBox_);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddComponentForm";
            this.Text = "AddComponentForm";
            this.Load += new System.EventHandler(this.AddComponentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_;
    }
}