using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AlgoritmoLineas
{
    public partial class FrmHome : Form
    {


        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public FrmHome()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void bRESENHAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bRESENHAMPARACIRCUNFERENCIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rELLENODEFIGURASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bRESENHAMELLIPSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cOHENSUTHERLANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cURVASBEZIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bSPLINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dDAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDDA dda = FrmDDA.SingletonInstancia();
            dda.MdiParent = this;
            dda.Show();
        }

        private void bresenhamParaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBresenham bresenham = FrmBresenham.SingletonInstancia();
            bresenham.MdiParent = this;
            bresenham.Show();
        }

        private void bresenhamParaCircunferenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBresenhamCircunferencias bresenhamCirculo = FrmBresenhamCircunferencias.SingletonInstancia();
            bresenhamCirculo.MdiParent = this;
            bresenhamCirculo.Show();
        }

        private void bresenhamParaElipsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBresenhamEllipse bresenhamEllipse = FrmBresenhamEllipse.SingletonInstancia();
            bresenhamEllipse.MdiParent = this;
            bresenhamEllipse.Show();
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRellenoFiguras floodFill = FrmRellenoFiguras.SingletonInstancia();
            floodFill.MdiParent = this;
            floodFill.Show();
        }

        private void scanlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScanline scanline = FrmScanline.SingletonInstancia();
            scanline.MdiParent = this;
            scanline.Show();
        }

        private void cohenSutherlandToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCohenSutherland frmCohenSutherland = FrmCohenSutherland.SingletonInstancia();
            frmCohenSutherland.MdiParent = this;
            frmCohenSutherland.Show();
        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSutherlandHodgman frmSutherlandHodgman = FrmSutherlandHodgman.SingletonInstancia();
            frmSutherlandHodgman.MdiParent = this;
            frmSutherlandHodgman.Show();
        }

        private void curvasDeBezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCurvasBezier frmCurvasBezier = FrmCurvasBezier.SingletonInstancia();
            frmCurvasBezier.MdiParent = this;
            frmCurvasBezier.Show();
        }

        private void bSplineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBSpline frmBSpline = FrmBSpline.SingletonInstancia();
            frmBSpline.MdiParent = this;
            frmBSpline.Show();
        }
    }
}
