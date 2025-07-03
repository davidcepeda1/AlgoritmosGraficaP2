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
    public partial class FrmDDA : Form
    {
        private DDA dda;
        private static FrmDDA instancia;
        int x1, y1, x2, y2;
        Color color = Color.Black;

        private void btnReset_Click(object sender, EventArgs e)
        {
            dda.InitializeData(txtX1, txtY1, txtX2, txtY2, picCanvas, listBoxPixels);
        }

        public static FrmDDA SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmDDA();
            }
            return instancia;
        }
        
        public FrmDDA()
        {
            InitializeComponent();
            dda = new DDA(picCanvas, color, listBoxPixels);
        }

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
            dda.lineaDDA(x1, y1, x2, y2);
        }
    }
}
