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
    public partial class FrmSutherlandHodgman : Form
    {
        private Polygon polygon;
        private static FrmSutherlandHodgman instancia;
        private List<PointF> linePoints = new List<PointF>();
        private List<PointF> canvasPoints = new List<PointF>();
        private List<PointF> polygonPoints = new List<PointF>();
        private List<PointF> clippingWindowPoints = new List<PointF>();
        private PointF[] clippedPoints;
        private Graphics graphics;
        private Pen pen;
        private const float CloseDistance = 10.0f;

        public FrmSutherlandHodgman()
        {
            InitializeComponent();
            picCanvas.Paint += picCanvas_Paint;
            graphics = picCanvas.CreateGraphics();
            pen = new Pen(Color.Black, 1);
        }

        private void FrmSutherlandHodgman_Load(object sender, EventArgs e)
        {
            // Definir una ventana de recorte (por ejemplo, un rectángulo en el centro)
            clippingWindowPoints = new List<PointF>
            {
                new PointF(100, 100), // Esquina superior izquierda
                new PointF(400, 100), // Esquina superior derecha
                new PointF(400, 400), // Esquina inferior derecha
                new PointF(100, 400)  // Esquina inferior izquierda
            };
            picCanvas.Invalidate();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar la ventana de recorte
            if (clippingWindowPoints.Count > 1)
            {
                e.Graphics.DrawPolygon(new Pen(Color.Red, 2), clippingWindowPoints.ToArray());
            }

            // Dibujar el polígono original
            if (polygonPoints.Count > 2)
            {
                e.Graphics.DrawPolygon(new Pen(Color.Black, 2), polygonPoints.ToArray());
            }

            // Dibujar el polígono recortado CORRECTAMENTE
            if (clippedPoints != null && clippedPoints.Length > 2)
            {
                // Dibujar como polígono, no como líneas individuales
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(100, Color.Green)), clippedPoints);
                e.Graphics.DrawPolygon(new Pen(Color.Green, 3), clippedPoints);

                // Opcionalmente, marcar los vértices
                foreach (var point in clippedPoints)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Blue), point.X - 3, point.Y - 3, 6, 6);
                }
            }
        }

        public static FrmSutherlandHodgman SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmSutherlandHodgman();
            }
            return instancia;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Añadir puntos para el polígono al hacer clic izquierdo
                polygonPoints.Add(new PointF(e.X, e.Y));
                picCanvas.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Cuando se hace clic derecho, se realiza el recorte
                if (polygonPoints.Count > 2) // Asegurarnos de que el polígono tiene más de 2 puntos
                {
                    clippedPoints = SutherlandHodgman.PolygonClippingAlgorithm(polygonPoints, clippingWindowPoints.ToArray());
                    polygonPoints.Clear(); // Limpiar la lista de puntos del polígono
                    picCanvas.Invalidate(); // Redibujar la imagen con los puntos recortados
                }
                else
                {
                    MessageBox.Show("Por favor, dibuje un polígono con al menos 3 puntos.");
                }
            }
        }
    }
}
