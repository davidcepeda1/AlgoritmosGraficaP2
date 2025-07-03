using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoLineas
{
    public class RellenoFiguras
    {
        public List<Point> polygonPoints = new List<Point>();  // Vértices del polígono
        private List<string> pixels = new List<string>(); // Píxeles activos
        private PictureBox p1;
        private Color fillColor;
        private ListBox listBoxPixels;
        private Timer timer;
        private int fillX, fillY;
        private bool[,] filledPixels;  // Para llevar un registro de los píxeles rellenados
        private Queue<Point> pixelsToFill = new Queue<Point>();  // Cola para los píxeles a rellenar
        private int currentPixel = 0;


        public RellenoFiguras(PictureBox pictureBox, Color fillColor, ListBox listBox)
        {
            this.p1 = pictureBox;
            this.fillColor = fillColor;
            this.listBoxPixels = listBox;
            this.timer = new Timer();
            this.timer.Interval = 1;  // Intervalo de tiempo entre píxeles para la animación
            this.timer.Tick += Timer_Tick;
        }

        // Método para dibujar el polígono regular
        public void DrawPolygon(int centerX, int centerY, int radius, int sides)
        {
            polygonPoints.Clear();  // Limpiar puntos previos
            double angle = 2 * Math.PI / sides;

            // Calcular los puntos del polígono regular
            for (int i = 0; i < sides; i++)
            {
                int x = (int)(centerX + radius * Math.Cos(i * angle));
                int y = (int)(centerY + radius * Math.Sin(i * angle));
                polygonPoints.Add(new Point(x, y));
            }

            // Dibujar el polígono en el PictureBox
            using (Graphics g = p1.CreateGraphics())
            {
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    int nextIndex = (i + 1) % polygonPoints.Count;
                    g.DrawLine(Pens.Black, polygonPoints[i], polygonPoints[nextIndex]);
                }
            }
        }

        // Método para iniciar el relleno
        public void StartFloodFill(int x, int y)
        {
            // Limpiar los datos y el estado previo
            filledPixels = new bool[p1.ClientSize.Width, p1.ClientSize.Height];
            pixels.Clear();
            listBoxPixels.Items.Clear();
            pixelsToFill.Clear();
            currentPixel = 0;

            // Asignar las coordenadas de inicio del relleno
            fillX = x;
            fillY = y;

            // Asegurarnos de que el punto inicial esté dentro del polígono
            if (!IsInsidePolygon(fillX, fillY))
            {
                MessageBox.Show("El punto de inicio no está dentro del polígono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Añadir el punto inicial a la cola para el relleno
            pixelsToFill.Enqueue(new Point(fillX, fillY));

            // Iniciar el Timer para la animación
            timer.Start();
        }

        // Rellenar por inundación
        private void FloodFillAlgorithm()
        {
            if (pixelsToFill.Count == 0)
                return;

            // Obtener el siguiente píxel a rellenar
            Point current = pixelsToFill.Dequeue();
            int x = current.X;
            int y = current.Y;

            // Verificar si el píxel está dentro del área del polígono y no se ha rellenado
            if (x < 0 || y < 0 || x >= p1.ClientSize.Width || y >= p1.ClientSize.Height || filledPixels[x, y] || !IsInsidePolygon(x, y))
                return;

            // Marcar el píxel como rellenado
            filledPixels[x, y] = true;

            // Dibujar el píxel
            using (Graphics g = p1.CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(fillColor), x, y, 1, 1);
                pixels.Add($"({x}, {y})");
                listBoxPixels.Items.Add($"({x}, {y})");
            }

            // Añadir los píxeles adyacentes a la cola
            pixelsToFill.Enqueue(new Point(x + 1, y));  // Derecha
            pixelsToFill.Enqueue(new Point(x - 1, y));  // Izquierda
            pixelsToFill.Enqueue(new Point(x, y + 1));  // Abajo
            pixelsToFill.Enqueue(new Point(x, y - 1));  // Arriba
        }

        // Método para verificar si un píxel está dentro del polígono (Método de ray-casting)
        public bool IsInsidePolygon(int x, int y)
        {
            bool inside = false;
            for (int i = 0, j = polygonPoints.Count - 1; i < polygonPoints.Count; j = i++)
            {
                Point pi = polygonPoints[i];
                Point pj = polygonPoints[j];

                // Revisamos si el punto (x, y) está dentro del polígono
                if ((y > Math.Min(pi.Y, pj.Y)) && (y <= Math.Max(pi.Y, pj.Y)) && (x <= Math.Max(pi.X, pj.X)))
                {
                    if (pi.Y != pj.Y)
                    {
                        // Calculamos el punto de intersección
                        double xinters = (y - pi.Y) * (pj.X - pi.X) / (pj.Y - pi.Y) + pi.X;
                        if (pi.X == pj.X || x <= xinters)
                        {
                            inside = !inside;
                        }
                    }
                }
            }
            return inside;
        }


        // Método que se llama cada vez que el Timer hace "Tick" (para la animación)
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Realizamos el relleno por inundación en el siguiente píxel
            FloodFillAlgorithm();

            // Detener el Timer cuando el relleno esté completo
            if (pixelsToFill.Count == 0)
            {
                timer.Stop();
            }
        }

        // Método para limpiar los datos del formulario (campos de texto, lienzo y ListBox)
        public void InitializeData(TextBox txtSide, TextBox txtXc, TextBox txtYc, TextBox txtRadio, PictureBox picCanvas, ListBox listBoxPixels)
        {
            txtSide.Text = "";
            txtXc.Text = "";
            txtYc.Text = "";
            txtRadio.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
            listBoxPixels.Items.Clear();
        }
    }
}