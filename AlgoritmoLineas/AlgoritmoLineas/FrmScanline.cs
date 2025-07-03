using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AlgoritmoLineas.Scanline;

namespace AlgoritmoLineas
{
    public partial class FrmScanline : Form
    {
        private static FrmScanline instancia;
        private ScanlineFill scanlineFill;
        private bool isDrawingPolygon = false;
        private bool showSteps = false;
        private bool isDragging = false;
        private int dragIndex = -1;
        private const int VERTEX_RADIUS = 6;
        private Timer animationTimer;
        private int currentStep = 0;
        private List<Point> fillPixels;

        public FrmScanline()
        {
            InitializeComponent();
            SetupForm();
            SetupAnimation();
        }
        private void SetupForm()
        {
            this.Text = "Algoritmo de Relleno Scanline +1";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            // Panel de controles
            Panel controlPanel = new Panel();
            controlPanel.Dock = DockStyle.Top;
            controlPanel.Height = 80;
            controlPanel.BackColor = Color.LightGray;

            // Botón para comenzar polígono
            Button btnStartPolygon = new Button();
            btnStartPolygon.Text = "Nuevo Polígono";
            btnStartPolygon.Location = new Point(10, 10);
            btnStartPolygon.Size = new Size(100, 30);
            btnStartPolygon.Click += BtnStartPolygon_Click;

            // Botón para cerrar polígono
            Button btnClosePolygon = new Button();
            btnClosePolygon.Text = "Cerrar Polígono";
            btnClosePolygon.Location = new Point(120, 10);
            btnClosePolygon.Size = new Size(100, 30);
            btnClosePolygon.Click += BtnClosePolygon_Click;

            // Botón para rellenar
            Button btnFill = new Button();
            btnFill.Text = "Rellenar";
            btnFill.Location = new Point(230, 10);
            btnFill.Size = new Size(80, 30);
            btnFill.Click += BtnFill_Click;

            // Botón para limpiar
            Button btnClear = new Button();
            btnClear.Text = "Limpiar";
            btnClear.Location = new Point(320, 10);
            btnClear.Size = new Size(80, 30);
            btnClear.Click += BtnClear_Click;

            // Checkbox para mostrar pasos
            CheckBox chkShowSteps = new CheckBox();
            chkShowSteps.Text = "Mostrar Pasos";
            chkShowSteps.Location = new Point(410, 15);
            chkShowSteps.Size = new Size(100, 20);
            chkShowSteps.CheckedChanged += ChkShowSteps_CheckedChanged;

            
            // Selector de color
            Button btnColor = new Button();
            btnColor.Text = "Color";
            btnColor.Location = new Point(10, 45);
            btnColor.Size = new Size(60, 25);
            btnColor.BackColor = Color.Blue;
            btnColor.Click += BtnColor_Click;

            // Etiqueta de información
            Label lblInfo = new Label();
            lblInfo.Name = "lblInfo";
            lblInfo.Text = "Haz clic en 'Nuevo Polígono' y luego dibuja los vértices. Arrastra para mover.";
            lblInfo.Location = new Point(80, 47);
            lblInfo.Size = new Size(500, 20);

            // Información de coordenadas
            Label lblCoords = new Label();
            lblCoords.Name = "lblCoords";
            lblCoords.Text = "Coordenadas: (0, 0)";
            lblCoords.Location = new Point(600, 47);
            lblCoords.Size = new Size(150, 20);

            controlPanel.Controls.Add(btnStartPolygon);
            controlPanel.Controls.Add(btnClosePolygon);
            controlPanel.Controls.Add(btnFill);
            controlPanel.Controls.Add(btnClear);
            controlPanel.Controls.Add(chkShowSteps);
            controlPanel.Controls.Add(btnColor);
            controlPanel.Controls.Add(lblInfo);
            controlPanel.Controls.Add(lblCoords);

            this.Controls.Add(controlPanel);

            // Inicializar scanline fill
            scanlineFill = new ScanlineFill(this.Width, this.Height - 80);

            // Eventos del formulario
            this.MouseClick += FrmScanline_MouseClick;
            this.MouseDown += FrmScanline_MouseDown;
            this.MouseMove += FrmScanline_MouseMove;
            this.MouseUp += FrmScanline_MouseUp;
            this.Paint += FrmScanline_Paint;
        }

        private void SetupAnimation()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 50; // 50ms entre pasos
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void BtnStartPolygon_Click(object sender, EventArgs e)
        {
            scanlineFill.ClearVertices();
            isDrawingPolygon = true;
            currentStep = 0;
            UpdateInfo("Haz clic para agregar vértices del polígono.");
            this.Invalidate();
        }

        private void BtnClosePolygon_Click(object sender, EventArgs e)
        {
            isDrawingPolygon = false;
            UpdateInfo($"Polígono cerrado con {scanlineFill.VertexCount} vértices.");
            this.Invalidate();
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            if (scanlineFill.VertexCount >= 3)
            {
                isDrawingPolygon = false;
                this.Invalidate();
                UpdateInfo("Polígono rellenado usando algoritmo scanline.");
            }
            else
            {
                UpdateInfo("Necesitas al menos 3 vértices para rellenar.");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            scanlineFill.ClearVertices();
            isDrawingPolygon = false;
            showSteps = false;
            animationTimer.Stop();
            currentStep = 0;
            fillPixels = null;
            UpdateInfo("Lienzo limpiado.");
            this.Invalidate();
        }

        private void ChkShowSteps_CheckedChanged(object sender, EventArgs e)
        {
            showSteps = ((CheckBox)sender).Checked;
            this.Invalidate();
        }

        private void BtnAnimate_Click(object sender, EventArgs e)
        {
            if (scanlineFill.VertexCount >= 3)
            {
                fillPixels = scanlineFill.GetFillPixels();
                currentStep = 0;
                animationTimer.Start();
                UpdateInfo("Animando relleno...");
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                scanlineFill.FillColor = colorDialog.Color;
                ((Button)sender).BackColor = colorDialog.Color;
                this.Invalidate();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (fillPixels != null && currentStep < fillPixels.Count)
            {
                currentStep += 10; // Animar 10 píxeles por paso
                this.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                UpdateInfo("Animación completada.");
            }
        }

        private void FrmScanline_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawingPolygon && e.Y > 80)
            {
                int vertexIndex = GetVertexAt(e.Location);
                if (vertexIndex == -1)
                {
                    scanlineFill.AddVertex(new PointF(e.X, e.Y));
                    UpdateInfo($"Vértice {scanlineFill.VertexCount} agregado en ({e.X}, {e.Y}).");
                    this.Invalidate();
                }
            }
        }

        private void FrmScanline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Y > 80)
            {
                dragIndex = GetVertexAt(e.Location);
                if (dragIndex != -1)
                {
                    isDragging = true;
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        private void FrmScanline_MouseMove(object sender, MouseEventArgs e)
        {
            // Actualizar coordenadas
            Label lblCoords = this.Controls.Find("lblCoords", true).FirstOrDefault() as Label;
            if (lblCoords != null)
            {
                lblCoords.Text = $"Coordenadas: ({e.X}, {e.Y})";
            }

            if (isDragging && dragIndex != -1)
            {
                List<PointF> vertices = scanlineFill.GetVertices();
                vertices[dragIndex] = new PointF(e.X, e.Y);

                scanlineFill.ClearVertices();
                foreach (PointF vertex in vertices)
                {
                    scanlineFill.AddVertex(vertex);
                }

                this.Invalidate();
            }
            else
            {
                int vertexIndex = GetVertexAt(e.Location);
                this.Cursor = (vertexIndex != -1 && e.Y > 80) ? Cursors.Hand : Cursors.Default;
            }
        }

        private void FrmScanline_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            dragIndex = -1;
            this.Cursor = Cursors.Default;
        }

        private int GetVertexAt(Point location)
        {
            List<PointF> vertices = scanlineFill.GetVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                float distance = (float)Math.Sqrt(
                    Math.Pow(vertices[i].X - location.X, 2) +
                    Math.Pow(vertices[i].Y - location.Y, 2));

                if (distance <= VERTEX_RADIUS + 5)
                    return i;
            }
            return -1;
        }

        private void FrmScanline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Desplazar para el panel de controles
            g.TranslateTransform(0, 80);

            List<PointF> vertices = scanlineFill.GetVertices();

            // Dibujar polígono relleno si no está en modo dibujo
            if (!isDrawingPolygon && vertices.Count >= 3)
            {
                if (animationTimer.Enabled && fillPixels != null)
                {
                    // Dibujar animación
                    using (SolidBrush brush = new SolidBrush(scanlineFill.FillColor))
                    {
                        for (int i = 0; i < Math.Min(currentStep, fillPixels.Count); i++)
                        {
                            Point pixel = fillPixels[i];
                            g.FillRectangle(brush, pixel.X, pixel.Y - 80, 1, 1);
                        }
                    }
                }
                else
                {
                    // Dibujar relleno completo
                    scanlineFill.FillPolygon(g);
                }
            }

            // Dibujar aristas del polígono
            if (vertices.Count > 1)
            {
                using (Pen edgePen = new Pen(Color.Black, 2))
                {
                    for (int i = 0; i < vertices.Count; i++)
                    {
                        int nextIndex = (i + 1) % vertices.Count;
                        if (!isDrawingPolygon || nextIndex != 0)
                        {
                            g.DrawLine(edgePen, vertices[i], vertices[nextIndex]);
                        }
                    }
                }
            }

            // Dibujar vértices
            for (int i = 0; i < vertices.Count; i++)
            {
                PointF vertex = vertices[i];

                // Círculo del vértice
                using (Brush vertexBrush = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(vertexBrush,
                        vertex.X - VERTEX_RADIUS, vertex.Y - VERTEX_RADIUS,
                        VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
                }

                // Borde del vértice
                using (Pen vertexPen = new Pen(Color.DarkRed, 2))
                {
                    g.DrawEllipse(vertexPen,
                        vertex.X - VERTEX_RADIUS, vertex.Y - VERTEX_RADIUS,
                        VERTEX_RADIUS * 2, VERTEX_RADIUS * 2);
                }

                // Número del vértice
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    using (Font font = new Font("Arial", 8, FontStyle.Bold))
                    {
                        string text = i.ToString();
                        SizeF textSize = g.MeasureString(text, font);
                        g.DrawString(text, font, textBrush,
                            vertex.X - textSize.Width / 2,
                            vertex.Y - textSize.Height / 2);
                    }
                }
            }

            // Mostrar información de pasos si está activado
            if (showSteps && !isDrawingPolygon && vertices.Count >= 3)
            {
                DrawStepInfo(g);
            }

            g.ResetTransform();
        }

        private void DrawStepInfo(Graphics g)
        {
            RectangleF bounds = scanlineFill.GetBoundingBox();
            int yMin = (int)Math.Floor(bounds.Top);
            int yMax = (int)Math.Ceiling(bounds.Bottom);

            using (Pen scanlinePen = new Pen(Color.Green, 1))
            {
                scanlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                for (int y = yMin; y <= yMax; y += 10) // Mostrar cada 10 líneas
                {
                    g.DrawLine(scanlinePen, 0, y, this.Width, y);
                }
            }

            using (Font font = new Font("Arial", 8))
            {
                using (Brush textBrush = new SolidBrush(Color.Green))
                {
                    g.DrawString($"Scanlines: {yMin} - {yMax}", font, textBrush, 10, 10);
                    g.DrawString($"Bounding Box: {bounds}", font, textBrush, 10, 25);
                }
            }
        }

        private void UpdateInfo(string message)
        {
            Label lblInfo = this.Controls.Find("lblInfo", true).FirstOrDefault() as Label;
            if (lblInfo != null)
            {
                lblInfo.Text = message;
            }
        }

        public static FrmScanline SingletonInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FrmScanline();
            }
            return instancia;
        }

    }
}
