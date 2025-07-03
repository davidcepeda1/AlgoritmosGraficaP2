using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AlgoritmoLineas
{
    internal class DDA
    {
        private int k = 1; // Variable para la animación
        private int pasos;
        private float x, y, x_inc, y_inc;
        private List<string> pixels = new List<string>();
        private PictureBox p1;
        private Color color;
        private ListBox listBoxPixels;
        private Timer timer;

        public DDA(PictureBox pictureBox, Color color, ListBox listBox)
        {
            this.p1 = pictureBox;
            this.color = color;
            this.listBoxPixels = listBox;
            this.timer = new Timer();
            this.timer.Interval = 20; // 20 ms de retraso entre cada píxel
            this.timer.Tick += Timer_Tick;
        }

        public void lineaDDA(int x1, int y1, int x2, int y2)
        {
            // Validación: Los puntos de inicio y fin no deben ser iguales
            if (x1 == x2 && y1 == y2)
            {
                MessageBox.Show("Los puntos de inicio y fin no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación: Las coordenadas deben estar dentro del área visible del lienzo
            if (x1 < 0 || x1 >= p1.ClientSize.Width || y1 < 0 || y1 >= p1.ClientSize.Height ||
                x2 < 0 || x2 >= p1.ClientSize.Width || y2 < 0 || y2 >= p1.ClientSize.Height)
            {
                MessageBox.Show("Las coordenadas deben estar dentro del área visible del lienzo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Iniciar las variables
            int dx = x2 - x1;
            int dy = y2 - y1;
            pasos = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            x_inc = (float)dx / pasos;
            y_inc = (float)dy / pasos;
            x = x1;
            y = y1;

            // Inicialización del Timer
            k = 1;
            pixels.Clear();
            listBoxPixels.Items.Clear();

            // Añadir el primer píxel
            pixels.Add($"({(int)x}, {(int)y})");
            listBoxPixels.Items.Add($"({(int)x}, {(int)y})");

            // Arrancar el Timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (k <= pasos)
            {
                // Actualizar coordenadas
                x += x_inc;
                y += y_inc;

                // Dibujar el píxel
                Bitmap bmp = new Bitmap(p1.ClientSize.Width, p1.ClientSize.Height);
                bmp.SetPixel((int)x, (int)y, color);

                // Mostrar el píxel en la lista
                pixels.Add($"({(int)x}, {(int)y})");
                listBoxPixels.Items.Add($"({(int)x}, {(int)y})");

                // Redibujar la imagen
                Graphics g = p1.CreateGraphics();
                g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

                k++;
            }
            else
            {
                // Detener el Timer cuando haya terminado la animación
                timer.Stop();
            }
        }

        public void InitializeData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas, ListBox listBoxPixels)
        {
            txtX1.Text = "";
            txtY1.Text = "";
            txtX2.Text = "";
            txtY2.Text = "";
            picCanvas.Refresh();
            listBoxPixels.Refresh();
            listBoxPixels.Items.Clear();
        }
    }
}
