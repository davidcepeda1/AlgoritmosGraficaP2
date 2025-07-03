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
    public partial class FrmCurvasBezier : Form
    {
        private static FrmCurvasBezier instancia;
        private List<PointF> controlPoints = new List<PointF>();
        private PointF[] curvePoints;
        private List<PointF[]> constructionLines = new List<PointF[]>();
        private List<PointF> intermediatePoints = new List<PointF>();

        // Configuración visual
        private bool showControlPolygon = true;
        private bool showConstructionLines = false;
        private bool showControlPoints = true;
        private bool animateConstruction = false;
        private int curveResolution = 100;
        private float animationT = 0.0f;

        // Para drag and drop de puntos de control
        private int draggedPointIndex = -1;
        private const float PointRadius = 8.0f;

        // Timer para animación
        private Timer animationTimer;
        public FrmCurvasBezier()
        {
            InitializeComponent();
            SetupForm();
            SetupTimer();
        }

        private void SetupForm()
        {
            this.Text = "Curvas de Bézier - Algoritmo de De Casteljau";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configurar PictureBox
            if (picCanvas == null)
            {
                picCanvas = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };
                this.Controls.Add(picCanvas);
            }

            picCanvas.Paint += picCanvas_Paint;
            picCanvas.MouseClick += picCanvas_MouseClick;
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;

            // Configurar eventos de teclado
            this.KeyPreview = true;
            this.KeyDown += FrmCurvasBezier_KeyDown;
        }

        private void SetupTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 50; // 20 FPS
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            if (controlPoints.Count == 0)
            {
                DrawInstructions(e.Graphics);
                return;
            }

            // Dibujar polígono de control
            if (showControlPolygon && controlPoints.Count > 1)
            {
                DrawControlPolygon(e.Graphics);
            }

            // Dibujar líneas de construcción
            if (showConstructionLines && constructionLines.Count > 0)
            {
                DrawConstructionLines(e.Graphics);
            }

            // Dibujar puntos intermedios (animación)
            if (animateConstruction && intermediatePoints.Count > 0)
            {
                DrawIntermediatePoints(e.Graphics);
            }

            // Dibujar la curva de Bézier
            if (controlPoints.Count >= 2)
            {
                DrawBezierCurve(e.Graphics);
            }

            // Dibujar puntos de control
            if (showControlPoints)
            {
                DrawControlPoints(e.Graphics);
            }

            // Dibujar información
            DrawInfo(e.Graphics);
        }

        private void DrawInstructions(Graphics g)
        {
            string instructions = "INSTRUCCIONES:\n\n" +
                                "• Clic izquierdo: Agregar punto de control\n" +
                                "• Arrastar: Mover punto de control\n" +
                                "• Clic derecho: Eliminar punto cercano\n" +
                                "• C: Limpiar todos los puntos\n" +
                                "• P: Mostrar/ocultar polígono de control\n" +
                                "• L: Mostrar/ocultar líneas de construcción\n" +
                                "• A: Activar/desactivar animación\n" +
                                "• +/-: Aumentar/disminuir resolución\n" +
                                "• Espacio: Generar curva predefinida";

            Font font = new Font("Arial", 12);
            SizeF textSize = g.MeasureString(instructions, font);
            float x = (picCanvas.Width - textSize.Width) / 2;
            float y = (picCanvas.Height - textSize.Height) / 2;

            g.DrawString(instructions, font, Brushes.Black, x, y);
        }
        private void DrawControlPolygon(Graphics g)
        {
            if (controlPoints.Count < 2) return;

            using (Pen pen = new Pen(Color.Gray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int i = 0; i < controlPoints.Count - 1; i++)
                {
                    g.DrawLine(pen, controlPoints[i], controlPoints[i + 1]);
                }
            }
        }

        private void DrawConstructionLines(Graphics g)
        {
            if (constructionLines.Count == 0) return;

            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            for (int level = 0; level < constructionLines.Count; level++)
            {
                Color color = colors[level % colors.Length];
                using (Pen pen = new Pen(color, 2))
                {
                    if (constructionLines[level].Length >= 2)
                    {
                        g.DrawLine(pen, constructionLines[level][0], constructionLines[level][1]);
                    }
                }
            }
        }

        private void DrawIntermediatePoints(Graphics g)
        {
            if (intermediatePoints.Count == 0) return;

            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

            for (int i = 0; i < intermediatePoints.Count; i++)
            {
                Color color = colors[i % colors.Length];
                using (SolidBrush brush = new SolidBrush(color))
                {
                    float x = intermediatePoints[i].X - 4;
                    float y = intermediatePoints[i].Y - 4;
                    g.FillEllipse(brush, x, y, 8, 8);
                }
            }

            // Dibujar el punto final de la curva para t actual
            if (controlPoints.Count >= 2)
            {
                PointF currentPoint = CurvasBezier.DeCasteljauAlgorithm(controlPoints, animationT);
                using (SolidBrush brush = new SolidBrush(Color.Magenta))
                {
                    float x = currentPoint.X - 6;
                    float y = currentPoint.Y - 6;
                    g.FillEllipse(brush, x, y, 12, 12);
                }
            }
        }

        private void DrawBezierCurve(Graphics g)
        {
            if (curvePoints == null || curvePoints.Length < 2)
            {
                curvePoints = CurvasBezier.CalculateBezierCurve(controlPoints, curveResolution);
            }

            if (curvePoints.Length >= 2)
            {
                using (Pen pen = new Pen(Color.DarkBlue, 3))
                {
                    for (int i = 0; i < curvePoints.Length - 1; i++)
                    {
                        g.DrawLine(pen, curvePoints[i], curvePoints[i + 1]);
                    }
                }
            }
        }

        private void DrawControlPoints(Graphics g)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                // Círculo del punto de control
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    float x = controlPoints[i].X - PointRadius;
                    float y = controlPoints[i].Y - PointRadius;
                    g.FillEllipse(brush, x, y, PointRadius * 2, PointRadius * 2);
                }

                // Borde
                using (Pen pen = new Pen(Color.DarkRed, 2))
                {
                    float x = controlPoints[i].X - PointRadius;
                    float y = controlPoints[i].Y - PointRadius;
                    g.DrawEllipse(pen, x, y, PointRadius * 2, PointRadius * 2);
                }

                // Etiqueta del punto
                string label = $"P{i}";
                using (Font font = new Font("Arial", 9, FontStyle.Bold))
                {
                    g.DrawString(label, font, Brushes.White,
                               controlPoints[i].X - 8, controlPoints[i].Y - 5);
                }
            }
        }

        private void DrawInfo(Graphics g)
        {
            string info = $"Puntos de control: {controlPoints.Count}\n" +
                         $"Grado de la curva: {Math.Max(0, controlPoints.Count - 1)}\n" +
                         $"Resolución: {curveResolution}\n" +
                         $"Polígono de control: {(showControlPolygon ? "Visible" : "Oculto")}\n" +
                         $"Líneas de construcción: {(showConstructionLines ? "Visible" : "Oculto")}\n" +
                         $"Animación: {(animateConstruction ? $"Activa (t={animationT:F2})" : "Inactiva")}";

            using (Font font = new Font("Arial", 10))
            {
                g.DrawString(info, font, Brushes.Black, new PointF(10, 10));
            }
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && draggedPointIndex == -1)
            {
                // Agregar nuevo punto de control
                controlPoints.Add(new PointF(e.X, e.Y));
                curvePoints = null; // Forzar recálculo
                picCanvas.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Eliminar punto cercano
                int pointIndex = FindNearestControlPoint(new PointF(e.X, e.Y));
                if (pointIndex != -1)
                {
                    controlPoints.RemoveAt(pointIndex);
                    curvePoints = null; // Forzar recálculo
                    picCanvas.Invalidate();
                }
            }
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggedPointIndex = FindNearestControlPoint(new PointF(e.X, e.Y));
                if (draggedPointIndex != -1)
                {
                    picCanvas.Cursor = Cursors.Hand;
                }
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedPointIndex != -1 && e.Button == MouseButtons.Left)
            {
                // Arrastrar punto de control
                controlPoints[draggedPointIndex] = new PointF(e.X, e.Y);
                curvePoints = null; // Forzar recálculo
                picCanvas.Invalidate();
            }
            else
            {
                // Cambiar cursor si está sobre un punto
                int nearestPoint = FindNearestControlPoint(new PointF(e.X, e.Y));
                picCanvas.Cursor = nearestPoint != -1 ? Cursors.Hand : Cursors.Default;
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            draggedPointIndex = -1;
            picCanvas.Cursor = Cursors.Default;
        }
        private int FindNearestControlPoint(PointF point)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                float distance = GetDistance(point, controlPoints[i]);
                if (distance <= PointRadius * 1.5f)
                {
                    return i;
                }
            }
            return -1;
        }

        private float GetDistance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private void FrmCurvasBezier_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    controlPoints.Clear();
                    curvePoints = null;
                    constructionLines.Clear();
                    intermediatePoints.Clear();
                    picCanvas.Invalidate();
                    break;

                case Keys.P:
                    showControlPolygon = !showControlPolygon;
                    picCanvas.Invalidate();
                    break;

                case Keys.L:
                    showConstructionLines = !showConstructionLines;
                    if (showConstructionLines && controlPoints.Count >= 2)
                    {
                        constructionLines = CurvasBezier.GetConstructionLines(controlPoints, 0.5f);
                    }
                    picCanvas.Invalidate();
                    break;

                case Keys.A:
                    animateConstruction = !animateConstruction;
                    if (animateConstruction)
                    {
                        showConstructionLines = true;
                        animationTimer.Start();
                    }
                    else
                    {
                        animationTimer.Stop();
                    }
                    break;

                case Keys.Oemplus:
                case Keys.Add:
                    curveResolution = Math.Min(500, curveResolution + 25);
                    curvePoints = null;
                    picCanvas.Invalidate();
                    break;

                case Keys.OemMinus:
                case Keys.Subtract:
                    curveResolution = Math.Max(25, curveResolution - 25);
                    curvePoints = null;
                    picCanvas.Invalidate();
                    break;

                case Keys.Space:
                    GeneratePresetCurve();
                    break;
            }
        }
        private void GeneratePresetCurve()
        {
            controlPoints.Clear();

            // Generar una curva cúbica interesante
            int centerX = picCanvas.Width / 2;
            int centerY = picCanvas.Height / 2;

            controlPoints.Add(new PointF(centerX - 200, centerY + 100));
            controlPoints.Add(new PointF(centerX - 100, centerY - 150));
            controlPoints.Add(new PointF(centerX + 100, centerY - 150));
            controlPoints.Add(new PointF(centerX + 200, centerY + 100));

            curvePoints = null;
            picCanvas.Invalidate();
        }

        public static FrmCurvasBezier SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmCurvasBezier();
            }
            return instancia;
        }

        private void FrmCurvasBezier_Load(object sender, EventArgs e)
        {
            GeneratePresetCurve();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            animationTimer?.Stop();
            animationTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
