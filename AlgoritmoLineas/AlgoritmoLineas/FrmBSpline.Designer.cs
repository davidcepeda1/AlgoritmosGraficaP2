﻿namespace AlgoritmoLineas
{
    partial class FrmBSpline
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
            this.SuspendLayout();
            // 
            // FrmBSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 672);
            this.Name = "FrmBSpline";
            this.Text = "FrmBSpline";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBSpline_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmBSpline_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBSpline_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmBSpline_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmBSpline_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}