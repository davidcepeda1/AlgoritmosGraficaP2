using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoLineas
{
    internal class Scanline
    {
        // Clase para representar una arista activa
        public class ActiveEdge
        {
            public float x;           // Coordenada x actual
            public float dx;          // Incremento en x por cada scanline
            public int yMax;          // Coordenada y máxima de la arista
            public int yMin;          // Coordenada y mínima de la arista

            public ActiveEdge(float x, float dx, int yMax, int yMin)
            {
                this.x = x;
                this.dx = dx;
                this.yMax = yMax;
                this.yMin = yMin;
            }

            // Actualiza la coordenada x para la siguiente scanline
            public void UpdateX()
            {
                x += dx;
            }
        }

        public class ScanlineFill
        {
            private List<PointF> vertices;
            private Color fillColor;
            private int imageWidth;
            private int imageHeight;

            public ScanlineFill(int width, int height)
            {
                vertices = new List<PointF>();
                fillColor = Color.Blue;
                imageWidth = width;
                imageHeight = height;
            }

            public void AddVertex(PointF vertex)
            {
                vertices.Add(vertex);
            }

            public void RemoveLastVertex()
            {
                if (vertices.Count > 0)
                    vertices.RemoveAt(vertices.Count - 1);
            }

            public void ClearVertices()
            {
                vertices.Clear();
            }

            public List<PointF> GetVertices()
            {
                return new List<PointF>(vertices);
            }

            public Color FillColor
            {
                get { return fillColor; }
                set { fillColor = value; }
            }

            public int VertexCount
            {
                get { return vertices.Count; }
            }

            // Algoritmo principal de relleno scanline +1
            public void FillPolygon(Graphics graphics)
            {
                if (vertices.Count < 3) return;

                // Paso 1: Crear tabla de aristas (Edge Table)
                Dictionary<int, List<ActiveEdge>> edgeTable = CreateEdgeTable();

                if (edgeTable.Count == 0) return;

                // Paso 2: Inicializar tabla de aristas activas
                List<ActiveEdge> activeEdgeTable = new List<ActiveEdge>();

                // Paso 3: Encontrar límites de Y
                int yMin = edgeTable.Keys.Min();
                int yMax = edgeTable.Keys.Max();

                // Paso 4: Procesar cada scanline
                for (int y = yMin; y <= yMax; y++)
                {
                    // Agregar nuevas aristas de la tabla de aristas
                    if (edgeTable.ContainsKey(y))
                    {
                        activeEdgeTable.AddRange(edgeTable[y]);
                    }

                    // Remover aristas que han terminado
                    activeEdgeTable.RemoveAll(edge => edge.yMax <= y);

                    // Ordenar aristas activas por coordenada x
                    activeEdgeTable.Sort((a, b) => a.x.CompareTo(b.x));

                    // Dibujar píxeles entre pares de intersecciones
                    DrawScanline(graphics, activeEdgeTable, y);

                    // Actualizar coordenadas x para la siguiente scanline
                    foreach (ActiveEdge edge in activeEdgeTable)
                    {
                        edge.UpdateX();
                    }
                }
            }

            // Crear tabla de aristas del polígono
            private Dictionary<int, List<ActiveEdge>> CreateEdgeTable()
            {
                Dictionary<int, List<ActiveEdge>> edgeTable = new Dictionary<int, List<ActiveEdge>>();

                for (int i = 0; i < vertices.Count; i++)
                {
                    PointF p1 = vertices[i];
                    PointF p2 = vertices[(i + 1) % vertices.Count];

                    // Ignorar aristas horizontales
                    if (Math.Abs(p1.Y - p2.Y) < 0.001f) continue;

                    // Asegurar que p1 esté por debajo de p2 (menor Y)
                    if (p1.Y > p2.Y)
                    {
                        PointF temp = p1;
                        p1 = p2;
                        p2 = temp;
                    }

                    int yMin = (int)Math.Round(p1.Y);
                    int yMax = (int)Math.Round(p2.Y);

                    // Calcular incremento en x
                    float dx = (p2.X - p1.X) / (p2.Y - p1.Y);
                    float x = p1.X;

                    // Crear arista activa
                    ActiveEdge edge = new ActiveEdge(x, dx, yMax, yMin);

                    // Agregar a la tabla de aristas
                    if (!edgeTable.ContainsKey(yMin))
                    {
                        edgeTable[yMin] = new List<ActiveEdge>();
                    }
                    edgeTable[yMin].Add(edge);
                }

                return edgeTable;
            }

            // Dibujar una scanline entre intersecciones
            private void DrawScanline(Graphics graphics, List<ActiveEdge> activeEdges, int y)
            {
                if (activeEdges.Count < 2) return;

                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    // Dibujar entre pares de intersecciones (regla de paridad)
                    for (int i = 0; i < activeEdges.Count - 1; i += 2)
                    {
                        if (i + 1 < activeEdges.Count)
                        {
                            int x1 = (int)Math.Round(activeEdges[i].x);
                            int x2 = (int)Math.Round(activeEdges[i + 1].x);

                            // Asegurar que x1 <= x2
                            if (x1 > x2)
                            {
                                int temp = x1;
                                x1 = x2;
                                x2 = temp;
                            }

                            // Clipping para evitar dibujar fuera de los límites
                            x1 = Math.Max(0, Math.Min(x1, imageWidth - 1));
                            x2 = Math.Max(0, Math.Min(x2, imageWidth - 1));

                            if (x2 > x1 && y >= 0 && y < imageHeight)
                            {
                                graphics.FillRectangle(brush, x1, y, x2 - x1 + 1, 1);
                            }
                        }
                    }
                }
            }

            // Método alternativo que retorna los píxeles como lista de puntos
            public List<Point> GetFillPixels()
            {
                List<Point> pixels = new List<Point>();

                if (vertices.Count < 3) return pixels;

                Dictionary<int, List<ActiveEdge>> edgeTable = CreateEdgeTable();
                if (edgeTable.Count == 0) return pixels;

                List<ActiveEdge> activeEdgeTable = new List<ActiveEdge>();
                int yMin = edgeTable.Keys.Min();
                int yMax = edgeTable.Keys.Max();

                for (int y = yMin; y <= yMax; y++)
                {
                    if (edgeTable.ContainsKey(y))
                    {
                        activeEdgeTable.AddRange(edgeTable[y]);
                    }

                    activeEdgeTable.RemoveAll(edge => edge.yMax <= y);
                    activeEdgeTable.Sort((a, b) => a.x.CompareTo(b.x));

                    // Obtener píxeles de la scanline
                    for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                    {
                        if (i + 1 < activeEdgeTable.Count)
                        {
                            int x1 = (int)Math.Round(activeEdgeTable[i].x);
                            int x2 = (int)Math.Round(activeEdgeTable[i + 1].x);

                            if (x1 > x2)
                            {
                                int temp = x1;
                                x1 = x2;
                                x2 = temp;
                            }

                            for (int x = x1; x <= x2; x++)
                            {
                                if (x >= 0 && x < imageWidth && y >= 0 && y < imageHeight)
                                {
                                    pixels.Add(new Point(x, y));
                                }
                            }
                        }
                    }

                    foreach (ActiveEdge edge in activeEdgeTable)
                    {
                        edge.UpdateX();
                    }
                }

                return pixels;
            }

            // Verificar si un punto está dentro del polígono
            public bool IsPointInside(PointF point)
            {
                if (vertices.Count < 3) return false;

                bool inside = false;
                int j = vertices.Count - 1;

                for (int i = 0; i < vertices.Count; i++)
                {
                    if (((vertices[i].Y > point.Y) != (vertices[j].Y > point.Y)) &&
                        (point.X < (vertices[j].X - vertices[i].X) * (point.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))
                    {
                        inside = !inside;
                    }
                    j = i;
                }

                return inside;
            }

            // Obtener información del polígono
            public RectangleF GetBoundingBox()
            {
                if (vertices.Count == 0) return RectangleF.Empty;

                float minX = vertices.Min(p => p.X);
                float maxX = vertices.Max(p => p.X);
                float minY = vertices.Min(p => p.Y);
                float maxY = vertices.Max(p => p.Y);

                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
        }
    }
}