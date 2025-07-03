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
    public partial class FrmBSpline : Form
    {
        private static FrmBSpline instancia;
        private BSpline bspline;
        private bool isDragging = false;
        private int dragIndex = -1;
        private const int POINT_RADIUS = 6;
        private const int CURVE_RESOLUTION = 200;

        public FrmBSpline()
        {
            InitializeComponent();
            bspline = new BSpline(3); // Grado 3 por defecto
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "B-Splines Interactivo";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            // Panel de controles
            Panel controlPanel = new Panel();
            controlPanel.Dock = DockStyle.Top;
            controlPanel.Height = 60;
            controlPanel.BackColor = Color.LightGray;

            // Controles de grado
            Label lblDegree = new Label();
            lblDegree.Text = "Grado:";
            lblDegree.Location = new Point(10, 20);
            lblDegree.Size = new Size(50, 20);

            NumericUpDown nudDegree = new NumericUpDown();
            nudDegree.Location = new Point(70, 18);
            nudDegree.Size = new Size(60, 20);
            nudDegree.Minimum = 1;
            nudDegree.Maximum = 10;
            nudDegree.Value = 3;
            nudDegree.ValueChanged += NudDegree_ValueChanged;

            // Botón limpiar
            Button btnClear = new Button();
            btnClear.Text = "Limpiar";
            btnClear.Location = new Point(150, 15);
            btnClear.Size = new Size(80, 30);
            btnClear.Click += BtnClear_Click;

            // Botón eliminar último punto
            Button btnRemoveLast = new Button();
            btnRemoveLast.Text = "Eliminar Último";
            btnRemoveLast.Location = new Point(240, 15);
            btnRemoveLast.Size = new Size(100, 30);
            btnRemoveLast.Click += BtnRemoveLast_Click;

            // Etiqueta de información
            Label lblInfo = new Label();
            lblInfo.Name = "lblInfo";
            lblInfo.Text = "Haz clic para agregar puntos de control. Arrastra para moverlos.";
            lblInfo.Location = new Point(360, 20);
            lblInfo.Size = new Size(400, 20);

            controlPanel.Controls.Add(lblDegree);
            controlPanel.Controls.Add(nudDegree);
            controlPanel.Controls.Add(btnClear);
            controlPanel.Controls.Add(btnRemoveLast);
            controlPanel.Controls.Add(lblInfo);

            this.Controls.Add(controlPanel);

            // Eventos del formulario
            this.MouseClick += FrmBSpline_MouseClick;
            this.MouseDown += FrmBSpline_MouseDown;
            this.MouseMove += FrmBSpline_MouseMove;
            this.MouseUp += FrmBSpline_MouseUp;
            this.Paint += FrmBSpline_Paint;
        }

        private void NudDegree_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            bspline.Degree = (int)nud.Value;
            UpdateInfo();
            this.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            bspline.ClearControlPoints();
            UpdateInfo();
            this.Invalidate();
        }

        private void BtnRemoveLast_Click(object sender, EventArgs e)
        {
            bspline.RemoveLastControlPoint();
            UpdateInfo();
            this.Invalidate();
        }

        private void FrmBSpline_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isDragging && e.Y > 60)
            {
                // Verificar si no se hizo clic en un punto existente
                int pointIndex = GetPointAt(e.Location);
                if (pointIndex == -1)
                {
                    bspline.AddControlPoint(new PointF(e.X, e.Y));
                    UpdateInfo();
                    this.Invalidate();
                }
            }
        }

        private void FrmBSpline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Y > 60)
            {
                dragIndex = GetPointAt(e.Location);
                if (dragIndex != -1)
                {
                    isDragging = true;
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        private void FrmBSpline_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && dragIndex != -1)
            {
                List<PointF> points = bspline.GetControlPoints();
                points[dragIndex] = new PointF(e.X, e.Y);

                // Reconstruir la B-spline con los puntos actualizados
                bspline.ClearControlPoints();
                foreach (PointF point in points)
                {
                    bspline.AddControlPoint(point);
                }

                this.Invalidate();
            }
            else
            {
                // Cambiar cursor si está sobre un punto
                int pointIndex = GetPointAt(e.Location);
                this.Cursor = (pointIndex != -1 && e.Y > 60) ? Cursors.Hand : Cursors.Default;
            }
        }

        private void FrmBSpline_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            dragIndex = -1;
            this.Cursor = Cursors.Default;
        }
        private int GetPointAt(Point location)
        {
            List<PointF> points = bspline.GetControlPoints();
            for (int i = 0; i < points.Count; i++)
            {
                float distance = (float)Math.Sqrt(
                    Math.Pow(points[i].X - location.X, 2) +
                    Math.Pow(points[i].Y - location.Y, 2));

                if (distance <= POINT_RADIUS + 5)
                    return i;
            }
            return -1;
        }

        private void FrmBSpline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dibujar la curva B-spline
            if (bspline.CanGenerateCurve)
            {
                List<PointF> curvePoints = bspline.GenerateCurvePoints(CURVE_RESOLUTION);
                if (curvePoints.Count > 1)
                {
                    using (Pen curvePen = new Pen(Color.Blue, 2))
                    {
                        for (int i = 0; i < curvePoints.Count - 1; i++)
                        {
                            g.DrawLine(curvePen, curvePoints[i], curvePoints[i + 1]);
                        }
                    }
                }
            }

            // Dibujar polígono de control
            List<PointF> controlPoints = bspline.GetControlPoints();
            if (controlPoints.Count > 1)
            {
                using (Pen controlPen = new Pen(Color.Gray, 1))
                {
                    controlPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    for (int i = 0; i < controlPoints.Count - 1; i++)
                    {
                        g.DrawLine(controlPen, controlPoints[i], controlPoints[i + 1]);
                    }
                }
            }

            // Dibujar puntos de control
            for (int i = 0; i < controlPoints.Count; i++)
            {
                PointF point = controlPoints[i];

                // Círculo del punto
                using (Brush pointBrush = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(pointBrush,
                        point.X - POINT_RADIUS, point.Y - POINT_RADIUS,
                        POINT_RADIUS * 2, POINT_RADIUS * 2);
                }

                // Borde del punto
                using (Pen pointPen = new Pen(Color.DarkRed, 2))
                {
                    g.DrawEllipse(pointPen,
                        point.X - POINT_RADIUS, point.Y - POINT_RADIUS,
                        POINT_RADIUS * 2, POINT_RADIUS * 2);
                }

                // Número del punto
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    using (Font font = new Font("Arial", 8, FontStyle.Bold))
                    {
                        string text = i.ToString();
                        SizeF textSize = g.MeasureString(text, font);
                        g.DrawString(text, font, textBrush,
                            point.X - textSize.Width / 2,
                            point.Y - textSize.Height / 2);
                    }
                }
            }
        }
        private void UpdateInfo()
        {
            Label lblInfo = this.Controls.Find("lblInfo", true).FirstOrDefault() as Label;
            if (lblInfo != null)
            {
                string info = $"Puntos: {bspline.ControlPointCount}, Grado: {bspline.Degree}";
                if (bspline.CanGenerateCurve)
                    info += " - Curva activa";
                else if (bspline.ControlPointCount > 0)
                    info += $" - Necesita {bspline.Degree + 1 - bspline.ControlPointCount} puntos más";
                else
                    info += " - Haz clic para agregar puntos";

                lblInfo.Text = info;
            }
        }
        public static FrmBSpline SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmBSpline();
            }
            return instancia;
        }
    }
}
