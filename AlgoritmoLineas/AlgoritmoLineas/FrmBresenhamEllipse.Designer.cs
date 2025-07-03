namespace AlgoritmoLineas
{
    partial class FrmBresenhamEllipse
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
            this.listBoxPixels = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLine = new System.Windows.Forms.Button();
            this.txtRadiusY = new System.Windows.Forms.TextBox();
            this.lblX1 = new System.Windows.Forms.Label();
            this.txtRadiusX = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.txtCenterY = new System.Windows.Forms.TextBox();
            this.lblY1 = new System.Windows.Forms.Label();
            this.txtCenterX = new System.Windows.Forms.TextBox();
            this.lblY2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 24;
            this.label1.Text = "Pixeles Activos";
            // 
            // listBoxPixels
            // 
            this.listBoxPixels.FormattingEnabled = true;
            this.listBoxPixels.ItemHeight = 16;
            this.listBoxPixels.Location = new System.Drawing.Point(70, 192);
            this.listBoxPixels.Name = "listBoxPixels";
            this.listBoxPixels.Size = new System.Drawing.Size(313, 196);
            this.listBoxPixels.TabIndex = 22;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(187, 547);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.picCanvas);
            this.panel1.Location = new System.Drawing.Point(454, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 588);
            this.panel1.TabIndex = 21;
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Teal;
            this.groupBox2.Controls.Add(this.btnLine);
            this.groupBox2.Controls.Add(this.txtRadiusY);
            this.groupBox2.Controls.Add(this.lblX1);
            this.groupBox2.Controls.Add(this.txtRadiusX);
            this.groupBox2.Controls.Add(this.lblX2);
            this.groupBox2.Controls.Add(this.txtCenterY);
            this.groupBox2.Controls.Add(this.lblY1);
            this.groupBox2.Controls.Add(this.txtCenterX);
            this.groupBox2.Controls.Add(this.lblY2);
            this.groupBox2.Location = new System.Drawing.Point(28, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 109);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BRESENHAM ELLIPSE";
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(265, 51);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(109, 32);
            this.btnLine.TabIndex = 17;
            this.btnLine.Text = "Trazar Linea";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // txtRadiusY
            // 
            this.txtRadiusY.Location = new System.Drawing.Point(179, 56);
            this.txtRadiusY.Name = "txtRadiusY";
            this.txtRadiusY.Size = new System.Drawing.Size(44, 22);
            this.txtRadiusY.TabIndex = 16;
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(39, 37);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(25, 16);
            this.lblX1.TabIndex = 9;
            this.lblX1.Text = "X1:";
            // 
            // txtRadiusX
            // 
            this.txtRadiusX.Location = new System.Drawing.Point(129, 56);
            this.txtRadiusX.Name = "txtRadiusX";
            this.txtRadiusX.Size = new System.Drawing.Size(44, 22);
            this.txtRadiusX.TabIndex = 15;
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(139, 37);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(25, 16);
            this.lblX2.TabIndex = 10;
            this.lblX2.Text = "X2:";
            // 
            // txtCenterY
            // 
            this.txtCenterY.Location = new System.Drawing.Point(79, 56);
            this.txtCenterY.Name = "txtCenterY";
            this.txtCenterY.Size = new System.Drawing.Size(44, 22);
            this.txtCenterY.TabIndex = 14;
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(89, 37);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(26, 16);
            this.lblY1.TabIndex = 11;
            this.lblY1.Text = "Y2:";
            // 
            // txtCenterX
            // 
            this.txtCenterX.Location = new System.Drawing.Point(29, 56);
            this.txtCenterX.Name = "txtCenterX";
            this.txtCenterX.Size = new System.Drawing.Size(44, 22);
            this.txtCenterX.TabIndex = 13;
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(189, 37);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(26, 16);
            this.lblY2.TabIndex = 12;
            this.lblY2.Text = "Y2:";
            // 
            // FrmBresenhamEllipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1081, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPixels);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmBresenhamEllipse";
            this.Text = "FrmBresenhamEllipse";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPixels;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.TextBox txtRadiusY;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.TextBox txtRadiusX;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.TextBox txtCenterY;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtCenterX;
        private System.Windows.Forms.Label lblY2;
    }
}