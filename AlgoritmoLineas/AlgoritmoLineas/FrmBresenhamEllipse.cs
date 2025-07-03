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
    public partial class FrmBresenhamEllipse : Form
    {
        private BresenhamEllipse bresenhamEllipse;
        private static FrmBresenhamEllipse instancia;
        int centerX, centerY, radiusX, radiusY;
        Color color = Color.Black;
        public FrmBresenhamEllipse()
        {
            InitializeComponent();
            bresenhamEllipse = new BresenhamEllipse(centerX, centerY, radiusX, radiusY);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.Refresh();

            // Validar que las entradas sean números válidos
            if (!int.TryParse(txtCenterX.Text, out int centerX) || !int.TryParse(txtCenterY.Text, out int centerY) ||
                !int.TryParse(txtRadiusX.Text, out int radiusX) || !int.TryParse(txtRadiusY.Text, out int radiusY))
            {
                MessageBox.Show("Por favor, ingresa valores válidos para las coordenadas y radios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear instancia del algoritmo Bresenham para la elipse
            bresenhamEllipse = new BresenhamEllipse(centerX, centerY, radiusX, radiusY);

            // Obtener los puntos de la elipse
            var points = bresenhamEllipse.GetEllipsePoints();

            // Llamamos al método para dibujar la elipse en el formulario
            DrawEllipse(points);
        }

        // Método para dibujar la elipse dentro del PictureBox
        private void DrawEllipse(List<Point> points)
        {
            using (Graphics g = picCanvas.CreateGraphics())
            {
                g.Clear(Color.White); // Limpiar el canvas antes de dibujar la nueva elipse
                foreach (var point in points)
                {
                    g.FillRectangle(Brushes.Black, point.X, point.Y, 1, 1); // Dibuja cada punto de la elipse
                }
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            bresenhamEllipse.InitializeData(txtCenterX, txtCenterY, txtRadiusX, txtRadiusY, picCanvas);
        }
        public static FrmBresenhamEllipse SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmBresenhamEllipse();
            }
            return instancia;
        }
    }
}
