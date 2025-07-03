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
    public partial class FrmBresenhamCircunferencias : Form
    {
        private BresenhamCirculo bresenhamCirculo;
        private static FrmBresenhamCircunferencias instancia;
        int xc, yc, radio;
        Color color = Color.Black;

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.Refresh();

            // Validar que las entradas sean números válidos
            if (!int.TryParse(txtXc.Text, out int xc) || !int.TryParse(txtYc.Text, out int yc) || !int.TryParse(txtRadio.Text, out int radio))
            {
                MessageBox.Show("Por favor, ingresa valores válidos para las coordenadas y el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener las coordenadas y radio de los cuadros de texto
            xc = Convert.ToInt16(txtXc.Text);
            yc = Convert.ToInt16(txtYc.Text);
            radio = Convert.ToInt16(txtRadio.Text);

            // Llamar al algoritmo Bresenham para trazar el círculo
            bresenhamCirculo.circuloBresenham(xc, yc, radio);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bresenhamCirculo.InitializeData(txtXc, txtYc, txtRadio, picCanvas, listBoxPixels);
        }

        public FrmBresenhamCircunferencias()
        {
            InitializeComponent();
            bresenhamCirculo = new BresenhamCirculo(picCanvas, color, listBoxPixels);
        }
        public static FrmBresenhamCircunferencias SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmBresenhamCircunferencias();
            }
            return instancia;
        }

    }
}
