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
    public partial class FrmRellenoFiguras : Form
    {
        private RellenoFiguras floodFill;
        private static FrmRellenoFiguras instancia;

        public FrmRellenoFiguras()
        {
            InitializeComponent();
            floodFill = new RellenoFiguras(picCanvas, Color.Red, listBoxPixels);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.Refresh();

            // Validar que las entradas sean números válidos
            if (!int.TryParse(txtSide.Text, out int side) || !int.TryParse(txtXc.Text, out int xc) || !int.TryParse(txtYc.Text, out int yc) || !int.TryParse(txtRadio.Text, out int radio))
            {
                MessageBox.Show("Por favor, ingresa valores válidos para las coordenadas y el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener las coordenadas y radio de los cuadros de texto
            side = Convert.ToInt16(txtSide.Text);
            xc = Convert.ToInt16(txtXc.Text);
            yc = Convert.ToInt16(txtYc.Text);
            radio = Convert.ToInt16(txtRadio.Text);

            floodFill.DrawPolygon(xc, yc, radio, side);
            floodFill.StartFloodFill(xc, yc);

        }
        public static FrmRellenoFiguras SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmRellenoFiguras();
            }
            return instancia;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            floodFill.InitializeData(txtSide,txtXc, txtYc, txtRadio, picCanvas, listBoxPixels);
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
        }
    }
    }
