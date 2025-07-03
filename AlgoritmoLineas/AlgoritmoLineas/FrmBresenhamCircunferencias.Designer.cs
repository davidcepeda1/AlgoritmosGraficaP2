namespace AlgoritmoLineas
{
    partial class FrmBresenhamCircunferencias
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.btnLine = new System.Windows.Forms.Button();
            this.lblX1 = new System.Windows.Forms.Label();
            this.txtXc = new System.Windows.Forms.TextBox();
            this.txtYc = new System.Windows.Forms.TextBox();
            this.lblY1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.listBoxPixels = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.picCanvas);
            this.panel1.Location = new System.Drawing.Point(450, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 588);
            this.panel1.TabIndex = 6;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picCanvas.Location = new System.Drawing.Point(15, 19);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(570, 554);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Teal;
            this.groupBox3.Controls.Add(this.txtRadio);
            this.groupBox3.Controls.Add(this.lblX2);
            this.groupBox3.Controls.Add(this.btnLine);
            this.groupBox3.Controls.Add(this.lblX1);
            this.groupBox3.Controls.Add(this.txtXc);
            this.groupBox3.Controls.Add(this.txtYc);
            this.groupBox3.Controls.Add(this.lblY1);
            this.groupBox3.Location = new System.Drawing.Point(27, 385);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 144);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BRESENHAM PARA CIRCUNFERENCIAS";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(223, 49);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(44, 22);
            this.txtRadio.TabIndex = 21;
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(220, 30);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(47, 16);
            this.lblX2.TabIndex = 20;
            this.lblX2.Text = "Radio:";
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(135, 90);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(122, 32);
            this.btnLine.TabIndex = 19;
            this.btnLine.Text = "Trazar Linea";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(132, 30);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(18, 16);
            this.lblX1.TabIndex = 15;
            this.lblX1.Text = "X:";
            // 
            // txtXc
            // 
            this.txtXc.Location = new System.Drawing.Point(123, 49);
            this.txtXc.Name = "txtXc";
            this.txtXc.Size = new System.Drawing.Size(44, 22);
            this.txtXc.TabIndex = 17;
            // 
            // txtYc
            // 
            this.txtYc.Location = new System.Drawing.Point(173, 49);
            this.txtYc.Name = "txtYc";
            this.txtYc.Size = new System.Drawing.Size(44, 22);
            this.txtYc.TabIndex = 18;
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(185, 30);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(19, 16);
            this.lblY1.TabIndex = 16;
            this.lblY1.Text = "Y:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(182, 550);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // listBoxPixels
            // 
            this.listBoxPixels.FormattingEnabled = true;
            this.listBoxPixels.ItemHeight = 16;
            this.listBoxPixels.Location = new System.Drawing.Point(63, 153);
            this.listBoxPixels.Name = "listBoxPixels";
            this.listBoxPixels.Size = new System.Drawing.Size(313, 196);
            this.listBoxPixels.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pixeles Activos";
            // 
            // FrmBresenhamCircunferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1081, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPixels);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmBresenhamCircunferencias";
            this.Text = "FrmBresenhamCircunferencias";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.TextBox txtXc;
        private System.Windows.Forms.TextBox txtYc;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.ListBox listBoxPixels;
        private System.Windows.Forms.Label label1;
    }
}