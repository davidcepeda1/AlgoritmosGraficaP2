namespace AlgoritmoLineas
{
    partial class FrmRellenoFiguras
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxPixels = new System.Windows.Forms.ListBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.btnLine = new System.Windows.Forms.Button();
            this.lblX1 = new System.Windows.Forms.Label();
            this.txtXc = new System.Windows.Forms.TextBox();
            this.txtYc = new System.Windows.Forms.TextBox();
            this.lblY1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.picCanvas);
            this.panel1.Location = new System.Drawing.Point(459, 12);
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
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.BlueViolet;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtSide);
            this.groupBox4.Controls.Add(this.txtRadio);
            this.groupBox4.Controls.Add(this.lblX2);
            this.groupBox4.Controls.Add(this.btnLine);
            this.groupBox4.Controls.Add(this.lblX1);
            this.groupBox4.Controls.Add(this.txtXc);
            this.groupBox4.Controls.Add(this.txtYc);
            this.groupBox4.Controls.Add(this.lblY1);
            this.groupBox4.Location = new System.Drawing.Point(35, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 147);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RELLENO DE FIGURAS";
            // 
            // listBoxPixels
            // 
            this.listBoxPixels.FormattingEnabled = true;
            this.listBoxPixels.ItemHeight = 16;
            this.listBoxPixels.Location = new System.Drawing.Point(64, 173);
            this.listBoxPixels.Name = "listBoxPixels";
            this.listBoxPixels.Size = new System.Drawing.Size(313, 196);
            this.listBoxPixels.TabIndex = 9;
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(249, 46);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(44, 22);
            this.txtRadio.TabIndex = 28;
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(246, 27);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(47, 16);
            this.lblX2.TabIndex = 27;
            this.lblX2.Text = "Radio:";
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(81, 85);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(228, 35);
            this.btnLine.TabIndex = 26;
            this.btnLine.Text = "Generar y rellenar Poligono";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(158, 27);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(18, 16);
            this.lblX1.TabIndex = 22;
            this.lblX1.Text = "X:";
            // 
            // txtXc
            // 
            this.txtXc.Location = new System.Drawing.Point(149, 46);
            this.txtXc.Name = "txtXc";
            this.txtXc.Size = new System.Drawing.Size(44, 22);
            this.txtXc.TabIndex = 24;
            // 
            // txtYc
            // 
            this.txtYc.Location = new System.Drawing.Point(199, 46);
            this.txtYc.Name = "txtYc";
            this.txtYc.Size = new System.Drawing.Size(44, 22);
            this.txtYc.TabIndex = 25;
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(211, 27);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(19, 16);
            this.lblY1.TabIndex = 23;
            this.lblY1.Text = "Y:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(199, 565);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Lados:";
            // 
            // txtSide
            // 
            this.txtSide.Location = new System.Drawing.Point(99, 46);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(44, 22);
            this.txtSide.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 32);
            this.label2.TabIndex = 30;
            this.label2.Text = "Pixeles Activos";
            // 
            // FrmRellenoFiguras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1081, 640);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.listBoxPixels);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Name = "FrmRellenoFiguras";
            this.Text = "FrmRellenoFiguras";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBoxPixels;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.TextBox txtXc;
        private System.Windows.Forms.TextBox txtYc;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
    }
}