using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoLineas
{
    public partial class FrmBresenham : Form
    {
        private Bresenham bresenham;
        private static FrmBresenham instancia;
        int x1, y1, x2, y2;
        Color color = Color.Black;

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.Refresh();

            // Validar que las entradas sean números válidos
            if (!int.TryParse(txtX1.Text, out int x1) || !int.TryParse(txtY1.Text, out int y1) ||
                !int.TryParse(txtX2.Text, out int x2) || !int.TryParse(txtY2.Text, out int y2))
            {
                MessageBox.Show("Por favor, ingresa valores válidos para las coordenadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            x1 = Convert.ToInt16(txtX1.Text);
            y1 = Convert.ToInt16(txtY1.Text);
            x2 = Convert.ToInt16(txtX2.Text);
            y2 = Convert.ToInt16(txtY2.Text);
            bresenham.lineaBresenham(x1, y1, x2, y2, picCanvas, color, listBoxPixels);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bresenham.InitializeData(txtX1, txtY1, txtX2, txtY2, picCanvas, listBoxPixels);
        }

        public static FrmBresenham SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmBresenham();
            }
            return instancia;
        }

        public FrmBresenham()
        {
            InitializeComponent();
            bresenham = new Bresenham(picCanvas, color, listBoxPixels);
        }
    }
}
