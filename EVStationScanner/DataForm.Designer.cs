﻿namespace EVStationScanner
{
    partial class RawDataForm
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
            this.rawDataTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rawDataTextBox
            // 
            this.rawDataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawDataTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawDataTextBox.Location = new System.Drawing.Point(12, 12);
            this.rawDataTextBox.Multiline = true;
            this.rawDataTextBox.Name = "rawDataTextBox";
            this.rawDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rawDataTextBox.Size = new System.Drawing.Size(810, 537);
            this.rawDataTextBox.TabIndex = 0;
            // 
            // RawDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.rawDataTextBox);
            this.Name = "RawDataForm";
            this.Text = "Raw data";
            this.Load += new System.EventHandler(this.RawDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rawDataTextBox;
    }
}