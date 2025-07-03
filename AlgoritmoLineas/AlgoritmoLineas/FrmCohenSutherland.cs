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
    public partial class FrmCohenSutherland : Form
    {
        private Polygon polygon;
        private static FrmCohenSutherland instancia;
        private List<PointF> linePoints = new List<PointF>();
        private List<PointF> canvasPoints = new List<PointF>();
        private PointF[] clippedPoints;
        private Graphics graphics;
        private Pen pen;

        public FrmCohenSutherland()
        {
            InitializeComponent();
            picCanvas.Paint += picCanvas_Paint;
            graphics = picCanvas.CreateGraphics();
            pen = new Pen(Color.Black, 1);
        }
        private PointF getCenter()
        {
            PointF center = new PointF(
                picCanvas.Width / 2,
                picCanvas.Height / 2
                );
            return center;

        }
        private void FrmCohenSutherland_load(object sender, EventArgs e)
        {
            polygon = new Polygon(4, 100, getCenter());
            polygon.SetRotation(polygon.GetRad() / 2);
            canvasPoints = new List<PointF>(polygon.GetOutline());
            picCanvas.Invalidate();
        }
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (polygon != null)
            {
                PointF[] points = polygon.GetOutline();

                using (Pen localPen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawPolygon(localPen, points);
                }
                // e.Graphics.DrawEllipse(new Pen(Color.Orange, 2), points[0].X, points[0].Y, 2, 2);
            }
            if (linePoints.Count % 2 == 0)
            {
                for (int i = 0; i < linePoints.Count; i += 2)
                {
                    e.Graphics.DrawLine(pen, linePoints[i], linePoints[i + 1]);
                }
            }

            if (clippedPoints != null && clippedPoints.Length % 2 == 0)
            {
                for (int i = 0; i < clippedPoints.Length; i += 2)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Blue, 2), clippedPoints[i].X, clippedPoints[i].Y, 2, 2);
                    e.Graphics.DrawEllipse(new Pen(Color.Orange, 2), clippedPoints[i + 1].X, clippedPoints[i + 1].Y, 2, 2);
                    e.Graphics.DrawLine(pen, clippedPoints[i], clippedPoints[i + 1]);
                }
            }
        }
        public static FrmCohenSutherland SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmCohenSutherland();
            }
            return instancia;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                linePoints.Add(new PointF(e.X, e.Y));
                picCanvas.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                clippedPoints = CohenSutherland.clippingAlgorithm(linePoints, canvasPoints.ToArray());
                linePoints.Clear();
                picCanvas.Invalidate();
            }
        }
    }
}
