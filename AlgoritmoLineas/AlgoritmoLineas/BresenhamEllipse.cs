using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoLineas
{
    internal class BresenhamEllipse
    {
        private int _centerX, _centerY;
        private int _radiusX, _radiusY;

        public BresenhamEllipse(int centerX, int centerY, int radiusX, int radiusY)
        {
            _centerX = centerX;
            _centerY = centerY;
            _radiusX = radiusX;
            _radiusY = radiusY;
        }

        // Método para dibujar la elipse
        public List<Point> GetEllipsePoints()
        {
            List<Point> points = new List<Point>();
            int x = 0;
            int y = _radiusY;
            int rx2 = _radiusX * _radiusX;
            int ry2 = _radiusY * _radiusY;
            int twoRx2 = 2 * rx2;
            int twoRy2 = 2 * ry2;
            int p;

            // Región 1 (por encima del centro)
            p = (int)(ry2 - (_radiusY * rx2) + (0.25 * rx2));
            while (twoRy2 * x <= twoRx2 * y)
            {
                points.Add(new Point(_centerX + x, _centerY + y));
                points.Add(new Point(_centerX - x, _centerY + y));
                points.Add(new Point(_centerX + x, _centerY - y));
                points.Add(new Point(_centerX - x, _centerY - y));

                if (p < 0)
                {
                    x++;
                    p += twoRy2 * x + ry2;
                }
                else
                {
                    x++;
                    y--;
                    p += twoRy2 * x - twoRx2 * y + ry2;
                }
            }

            // Región 2 (por debajo del centro)
            p = (int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
            while (y >= 0)
            {
                points.Add(new Point(_centerX + x, _centerY + y));
                points.Add(new Point(_centerX - x, _centerY + y));
                points.Add(new Point(_centerX + x, _centerY - y));
                points.Add(new Point(_centerX - x, _centerY - y));

                if (p > 0)
                {
                    y--;
                    p -= twoRx2 * y + rx2;
                }
                else
                {
                    x++;
                    y--;
                    p += twoRy2 * x - twoRx2 * y + rx2;
                }
            }

            return points;
        }
        public void InitializeData(TextBox txtCenterX, TextBox txtCenterY, TextBox txtRadiusY, TextBox txtRadiusX, PictureBox picCanvas)
        {
            txtCenterX.Text = "";
            txtCenterY.Text = "";
            txtRadiusX.Text = "";
            txtRadiusY.Text = "";
            picCanvas.Refresh();
        }
    }
}
