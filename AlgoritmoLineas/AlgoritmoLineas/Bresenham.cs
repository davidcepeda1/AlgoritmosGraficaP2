using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoLineas
{
    internal class Bresenham
    {
        // Variables originales (se mantienen)
        private int k = 1;
        private int dx, dy, x, y;
        private int sx, sy;     // Nuevas variables para dirección
        private int err;        // Reemplaza a 'p'
        private int targetX, targetY;  // Para punto final
        private List<string> pixels = new List<string>();
        private PictureBox p1;
        private Color color;
        private ListBox listBoxPixels;
        private Timer timer;

        public Bresenham(PictureBox pictureBox, Color color, ListBox listBox)
        {
            // Constructor original sin cambios
            this.p1 = pictureBox;
            this.color = color;
            this.listBoxPixels = listBox;
            this.timer = new Timer();
            this.timer.Interval = 20;
            this.timer.Tick += Timer_Tick;
        }

        public void lineaBresenham(int x1, int y1, int x2, int y2, PictureBox p1, Color color, ListBox listBoxPixels)
        {
            // Validaciones originales sin cambios
            if (x1 == x2 && y1 == y2)
            {
                MessageBox.Show("Los puntos de inicio y fin no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (x1 < 0 || x1 >= p1.ClientSize.Width || y1 < 0 || y1 >= p1.ClientSize.Height ||
                x2 < 0 || x2 >= p1.ClientSize.Width || y2 < 0 || y2 >= p1.ClientSize.Height)
            {
                MessageBox.Show("Las coordenadas deben estar dentro del área visible del lienzo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inicialización corregida (algoritmo generalizado)
            dx = Math.Abs(x2 - x1);
            dy = Math.Abs(y2 - y1);
            sx = (x1 < x2) ? 1 : -1;  // Dirección X
            sy = (y1 < y2) ? 1 : -1;  // Dirección Y
            err = dx - dy;             // Parámetro de error corregido

            x = x1;
            y = y1;
            targetX = x2;
            targetY = y2;

            // Configuración inicial igual
            k = 1;
            pixels.Clear();
            listBoxPixels.Items.Clear();
            pixels.Add($"({x}, {y})");
            listBoxPixels.Items.Add($"({x}, {y})");

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Detener cuando llegamos al punto final
            if (x == targetX && y == targetY)
            {
                timer.Stop();
                return;
            }

            // Dibujar usando bitmap temporal (mismo método original)
            Bitmap bmp = new Bitmap(p1.ClientSize.Width, p1.ClientSize.Height);

            // Calcular siguiente punto (algoritmo corregido)
            int e2 = 2 * err;
            if (e2 > -dy)
            {
                err -= dy;
                x += sx;
            }
            if (e2 < dx)
            {
                err += dx;
                y += sy;
            }

            // Dibujar nuevo punto
            bmp.SetPixel(x, y, color);
            pixels.Add($"({x}, {y})");
            listBoxPixels.Items.Add($"({x}, {y})");

            // Redibujar (mismo método original)
            Graphics g = p1.CreateGraphics();
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

            k++;
        }

        // Método InitializeData sin cambios
        public void InitializeData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas, ListBox listBoxPixels)
        {
            txtX1.Text = ""; txtY1.Text = ""; txtX2.Text = "";
            txtY2.Text = "";
            txtX1.Focus();
            picCanvas.Refresh();
            listBoxPixels.Refresh();
            listBoxPixels.Items.Clear();
        }
    }
}