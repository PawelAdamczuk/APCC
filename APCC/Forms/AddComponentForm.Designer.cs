﻿namespace APCC.Forms
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
            this.comboBox_.Location = new System.Drawing.Point(13, 13);
            this.comboBox_.Name = "comboBox_";
            this.comboBox_.Size = new System.Drawing.Size(318, 21);
            this.comboBox_.TabIndex = 0;
            // 
            // AddComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 488);
            this.Controls.Add(this.comboBox_);
            this.Name = "AddComponentForm";
            this.Text = "AddComponentForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_;
    }
}