using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoLineas
{
    internal class BresenhamCirculo
    {
        private int k = 1;
        private int x, y, p;
        private int xc, yc;  // Coordenadas del centro del círculo
        private List<string> pixels = new List<string>();
        private PictureBox p1;
        private Color color;
        private ListBox listBoxPixels;
        private Timer timer;

        public BresenhamCirculo(PictureBox pictureBox, Color color, ListBox listBox)
        {
            this.p1 = pictureBox;
            this.color = color;
            this.listBoxPixels = listBox;
            this.timer = new Timer();
            this.timer.Interval = 20;  // Tiempo entre píxeles (20ms)
            this.timer.Tick += Timer_Tick;
        }

        // Método principal para trazar el círculo
        public void circuloBresenham(int xc, int yc, int radio)
        {
            // Guardamos el centro del círculo como variables de instancia
            this.xc = xc;
            this.yc = yc;

            // Validación: El radio debe ser mayor que cero
            if (radio <= 0)
            {
                MessageBox.Show("El radio debe ser un número positivo mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación: El centro debe estar dentro del área visible del lienzo
            if (xc < 0 || xc >= p1.ClientSize.Width || yc < 0 || yc >= p1.ClientSize.Height)
            {
                MessageBox.Show("El centro del círculo debe estar dentro del área visible del lienzo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inicialización de las variables
            x = 0;
            y = radio;
            p = 3 - 2 * radio;

            k = 1;
            pixels.Clear();
            listBoxPixels.Items.Clear();

            // Añadir el primer píxel (en el punto superior)
            DibujarPuntos(xc, yc, x, y);

            // Iniciar el Timer para la animación progresiva
            timer.Start();
        }

        // Método para el Timer (animación de píxeles)
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (k <= y)
            {
                x++;  // Incrementamos x

                // Calculamos el nuevo valor de p y el ajuste de las coordenadas
                if (p <= 0)
                {
                    p = p + 4 * x + 6;
                }
                else
                {
                    y--;
                    p = p + 4 * (x - y) + 10;
                }

                // Dibujar los 8 puntos simétricos del círculo
                DibujarPuntos(xc, yc, x, y);
                k++;
            }
            else
            {
                timer.Stop();  // Detenemos el Timer cuando termina
            }
        }

        // Método para dibujar los 8 puntos simétricos del círculo
        private void DibujarPuntos(int xc, int yc, int x, int y)
        {
            // Usamos la fórmula para calcular los 8 puntos simétricos de la circunferencia
            List<string> points = new List<string>
            {
                // Ajustamos las coordenadas para el sistema gráfico de Windows Forms
                $"({xc + x}, {yc - y})", $"({xc - x}, {yc - y})",  // Arriba
                $"({xc + x}, {yc + y})", $"({xc - x}, {yc + y})",  // Abajo
                $"({xc + y}, {yc - x})", $"({xc - y}, {yc - x})",  // Izquierda
                $"({xc + y}, {yc + x})", $"({xc - y}, {yc + x})"   // Derecha
            };

            // Dibujamos cada punto y lo agregamos a la lista
            using (Graphics g = p1.CreateGraphics())
            {
                foreach (var point in points)
                {
                    int xDraw = int.Parse(point.Split(',')[0].Trim('(', ')'));
                    int yDraw = int.Parse(point.Split(',')[1].Trim('(', ')'));

                    // Dibujamos un píxel en las coordenadas calculadas
                    g.FillRectangle(new SolidBrush(color), xDraw, yDraw, 1, 1);

                    // Agregar el punto a la lista de píxeles para el ListBox
                    listBoxPixels.Items.Add(point);
                }
            }
        }

        // Método para limpiar los datos (campos de texto y el ListBox)
        public void InitializeData(TextBox txtXc, TextBox txtYc, TextBox txtRadio, PictureBox picCanvas, ListBox listBoxPixels)
        {
            txtXc.Text = "";
            txtYc.Text = "";
            txtRadio.Text = "";
            txtXc.Focus();
            picCanvas.Refresh();
            listBoxPixels.Items.Clear();
        }
    }
}
