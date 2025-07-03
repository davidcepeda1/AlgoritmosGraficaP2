namespace AlgoritmoLineas
{
    partial class FrmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bRESENHAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rELLENODEFIGURASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamParaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamParaCircunferenciasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamParaElipsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSutherlandToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvasDeBezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSplineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.bRESENHAMToolStripMenuItem,
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem,
            this.rELLENODEFIGURASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem1,
            this.bresenhamParaToolStripMenuItem,
            this.bresenhamParaCircunferenciasToolStripMenuItem1,
            this.bresenhamParaElipsesToolStripMenuItem});
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.dDAToolStripMenuItem.Text = "Rasterización de líneas y curvas";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bRESENHAMToolStripMenuItem
            // 
            this.bRESENHAMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floodFillToolStripMenuItem,
            this.scanlineToolStripMenuItem});
            this.bRESENHAMToolStripMenuItem.Name = "bRESENHAMToolStripMenuItem";
            this.bRESENHAMToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.bRESENHAMToolStripMenuItem.Text = "Relleno de regiones";
            this.bRESENHAMToolStripMenuItem.Click += new System.EventHandler(this.bRESENHAMToolStripMenuItem_Click);
            // 
            // bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem
            // 
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cohenSutherlandToolStripMenuItem1,
            this.sutherlandHodgmanToolStripMenuItem});
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem.Name = "bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem";
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem.Text = "Recorte geométrico";
            this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem.Click += new System.EventHandler(this.bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem_Click);
            // 
            // rELLENODEFIGURASToolStripMenuItem
            // 
            this.rELLENODEFIGURASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curvasDeBezierToolStripMenuItem,
            this.bSplineToolStripMenuItem1});
            this.rELLENODEFIGURASToolStripMenuItem.Name = "rELLENODEFIGURASToolStripMenuItem";
            this.rELLENODEFIGURASToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.rELLENODEFIGURASToolStripMenuItem.Text = "Curvas paramétricas";
            this.rELLENODEFIGURASToolStripMenuItem.Click += new System.EventHandler(this.rELLENODEFIGURASToolStripMenuItem_Click);
            // 
            // dDAToolStripMenuItem1
            // 
            this.dDAToolStripMenuItem1.Name = "dDAToolStripMenuItem1";
            this.dDAToolStripMenuItem1.Size = new System.Drawing.Size(301, 26);
            this.dDAToolStripMenuItem1.Text = "DDA";
            this.dDAToolStripMenuItem1.Click += new System.EventHandler(this.dDAToolStripMenuItem1_Click);
            // 
            // bresenhamParaToolStripMenuItem
            // 
            this.bresenhamParaToolStripMenuItem.Name = "bresenhamParaToolStripMenuItem";
            this.bresenhamParaToolStripMenuItem.Size = new System.Drawing.Size(301, 26);
            this.bresenhamParaToolStripMenuItem.Text = "Bresenham para lineas ";
            this.bresenhamParaToolStripMenuItem.Click += new System.EventHandler(this.bresenhamParaToolStripMenuItem_Click);
            // 
            // bresenhamParaCircunferenciasToolStripMenuItem1
            // 
            this.bresenhamParaCircunferenciasToolStripMenuItem1.Name = "bresenhamParaCircunferenciasToolStripMenuItem1";
            this.bresenhamParaCircunferenciasToolStripMenuItem1.Size = new System.Drawing.Size(301, 26);
            this.bresenhamParaCircunferenciasToolStripMenuItem1.Text = "Bresenham para circunferencias";
            this.bresenhamParaCircunferenciasToolStripMenuItem1.Click += new System.EventHandler(this.bresenhamParaCircunferenciasToolStripMenuItem1_Click);
            // 
            // bresenhamParaElipsesToolStripMenuItem
            // 
            this.bresenhamParaElipsesToolStripMenuItem.Name = "bresenhamParaElipsesToolStripMenuItem";
            this.bresenhamParaElipsesToolStripMenuItem.Size = new System.Drawing.Size(301, 26);
            this.bresenhamParaElipsesToolStripMenuItem.Text = "Bresenham para elipses";
            this.bresenhamParaElipsesToolStripMenuItem.Click += new System.EventHandler(this.bresenhamParaElipsesToolStripMenuItem_Click);
            // 
            // floodFillToolStripMenuItem
            // 
            this.floodFillToolStripMenuItem.Name = "floodFillToolStripMenuItem";
            this.floodFillToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.floodFillToolStripMenuItem.Text = "Flood Fill";
            this.floodFillToolStripMenuItem.Click += new System.EventHandler(this.floodFillToolStripMenuItem_Click);
            // 
            // scanlineToolStripMenuItem
            // 
            this.scanlineToolStripMenuItem.Name = "scanlineToolStripMenuItem";
            this.scanlineToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.scanlineToolStripMenuItem.Text = "Scanline";
            this.scanlineToolStripMenuItem.Click += new System.EventHandler(this.scanlineToolStripMenuItem_Click);
            // 
            // cohenSutherlandToolStripMenuItem1
            // 
            this.cohenSutherlandToolStripMenuItem1.Name = "cohenSutherlandToolStripMenuItem1";
            this.cohenSutherlandToolStripMenuItem1.Size = new System.Drawing.Size(234, 26);
            this.cohenSutherlandToolStripMenuItem1.Text = "Cohen Sutherland";
            this.cohenSutherlandToolStripMenuItem1.Click += new System.EventHandler(this.cohenSutherlandToolStripMenuItem1_Click);
            // 
            // sutherlandHodgmanToolStripMenuItem
            // 
            this.sutherlandHodgmanToolStripMenuItem.Name = "sutherlandHodgmanToolStripMenuItem";
            this.sutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.sutherlandHodgmanToolStripMenuItem.Text = "Sutherland Hodgman";
            this.sutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.sutherlandHodgmanToolStripMenuItem_Click);
            // 
            // curvasDeBezierToolStripMenuItem
            // 
            this.curvasDeBezierToolStripMenuItem.Name = "curvasDeBezierToolStripMenuItem";
            this.curvasDeBezierToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.curvasDeBezierToolStripMenuItem.Text = "Curvas de Bezier";
            this.curvasDeBezierToolStripMenuItem.Click += new System.EventHandler(this.curvasDeBezierToolStripMenuItem_Click);
            // 
            // bSplineToolStripMenuItem1
            // 
            this.bSplineToolStripMenuItem1.Name = "bSplineToolStripMenuItem1";
            this.bSplineToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.bSplineToolStripMenuItem1.Text = "B-Splines";
            this.bSplineToolStripMenuItem1.Click += new System.EventHandler(this.bSplineToolStripMenuItem1_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1482, 725);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHome";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bRESENHAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rELLENODEFIGURASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bresenhamParaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamParaCircunferenciasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bresenhamParaElipsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohenSutherlandToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvasDeBezierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bSplineToolStripMenuItem1;
    }
}