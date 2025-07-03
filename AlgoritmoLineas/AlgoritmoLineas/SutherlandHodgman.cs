using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoLineas
{
    internal class SutherlandHodgman
    {
        private const float Tolerance = 1e-6f;
        private const float Infinity = 1e6f;

        public static PointF[] PolygonClippingAlgorithm(List<PointF> polygonPoints, PointF[] clippingWindow)
        {
            // Validación de entradas
            if (polygonPoints == null || clippingWindow == null || polygonPoints.Count < 3)
            {
                Console.WriteLine("Entrada no válida: el polígono debe tener al menos 3 puntos.");
                return new PointF[0];
            }

            // Calcular límites exactos de la ventana
            float minX = float.MaxValue, maxX = float.MinValue;
            float minY = float.MaxValue, maxY = float.MinValue;

            foreach (var point in clippingWindow)
            {
                minX = Math.Min(minX, point.X);
                maxX = Math.Max(maxX, point.X);
                minY = Math.Min(minY, point.Y);
                maxY = Math.Max(maxY, point.Y);
            }

            List<PointF> clippedPoints = new List<PointF>(polygonPoints);

            // Definir bordes en orden: izquierdo, derecho, inferior, superior
            for (int edge = 0; edge < 4; edge++)
            {
                if (clippedPoints.Count == 0) break;

                var inputList = new List<PointF>(clippedPoints);
                clippedPoints.Clear();

                // Manejar lista vacía
                if (inputList.Count == 0) continue;

                // CORRECCIÓN: No duplicar el primer punto al final
                for (int i = 0; i < inputList.Count; i++)
                {
                    PointF S = inputList[i == 0 ? inputList.Count - 1 : i - 1]; // Punto anterior
                    PointF E = inputList[i]; // Punto actual

                    bool insideS = IsInsideEdge(S, edge, minX, maxX, minY, maxY);
                    bool insideE = IsInsideEdge(E, edge, minX, maxX, minY, maxY);

                    if (insideE)
                    {
                        if (!insideS)
                        {
                            // Entrando: agregar intersección
                            PointF intersection = ComputeIntersection(S, E, edge, minX, maxX, minY, maxY);
                            if (IsValidPoint(intersection))
                                clippedPoints.Add(intersection);
                        }
                        // Agregar el punto actual
                        clippedPoints.Add(E);
                    }
                    else if (insideS)
                    {
                        // Saliendo: solo agregar intersección
                        PointF intersection = ComputeIntersection(S, E, edge, minX, maxX, minY, maxY);
                        if (IsValidPoint(intersection))
                            clippedPoints.Add(intersection);
                    }
                }
            }

            // CORRECCIÓN: No simplificar demasiado el polígono
            return RemoveDuplicatePoints(clippedPoints).ToArray();
        }

        // Método auxiliar para remover puntos duplicados consecutivos
        private static List<PointF> RemoveDuplicatePoints(List<PointF> points)
        {
            if (points.Count < 2) return points;

            var result = new List<PointF>();

            for (int i = 0; i < points.Count; i++)
            {
                PointF current = points[i];
                PointF next = points[(i + 1) % points.Count];

                // Solo agregar si no es duplicado del siguiente
                if (Math.Abs(current.X - next.X) > Tolerance || Math.Abs(current.Y - next.Y) > Tolerance)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        private static bool IsPolygonCompletelyInside(List<PointF> points, float minX, float maxX, float minY, float maxY)
        {
            foreach (var point in points)
            {
                if (point.X < minX - Tolerance || point.X > maxX + Tolerance ||
                    point.Y < minY - Tolerance || point.Y > maxY + Tolerance)
                    return false;
            }
            return true;
        }

        private static bool IsValidPoint(PointF point)
        {
            return !float.IsNaN(point.X) && !float.IsInfinity(point.X) &&
                   !float.IsNaN(point.Y) && !float.IsInfinity(point.Y);
        }

        private static bool IsInsideEdge(PointF point, int edge, float minX, float maxX, float minY, float maxY)
        {
            switch (edge)
            {
                case 0: return point.X >= minX - Tolerance;  // Borde izquierdo
                case 1: return point.X <= maxX + Tolerance;  // Borde derecho
                case 2: return point.Y <= maxY + Tolerance;  // Borde inferior
                case 3: return point.Y >= minY - Tolerance;  // Borde superior
                default: return false;
            }
        }

        private static PointF ComputeIntersection(PointF a, PointF b, int edge, float minX, float maxX, float minY, float maxY)
        {
            switch (edge)
            {
                case 0: return IntersectWithVertical(a, b, minX); // Izquierda
                case 1: return IntersectWithVertical(a, b, maxX); // Derecha
                case 2: return IntersectWithHorizontal(a, b, maxY); // Inferior
                case 3: return IntersectWithHorizontal(a, b, minY); // Superior
                default: return new PointF(float.NaN, float.NaN);
            }
        }

        private static PointF IntersectWithVertical(PointF a, PointF b, float x)
        {
            if (Math.Abs(a.X - b.X) < Tolerance)
                return new PointF(x, a.Y); // Línea vertical, usar Y de cualquier punto

            float t = (x - a.X) / (b.X - a.X);
            float y = a.Y + t * (b.Y - a.Y);
            return new PointF(x, y);
        }

        private static PointF IntersectWithHorizontal(PointF a, PointF b, float y)
        {
            if (Math.Abs(a.Y - b.Y) < Tolerance)
                return new PointF(a.X, y); // Línea horizontal, usar X de cualquier punto

            float t = (y - a.Y) / (b.Y - a.Y);
            float x = a.X + t * (b.X - a.X);
            return new PointF(x, y);
        }

        private static List<PointF> SimplifyPolygon(List<PointF> points)
        {
            if (points.Count < 4) return points;

            var cleaned = new List<PointF>();
            PointF prev = points[points.Count - 2];
            PointF current = points[points.Count - 1];

            for (int i = 0; i < points.Count; i++)
            {
                PointF next = points[i];

                // Mantener puntos críticos (cambios de dirección)
                if (!IsCollinear(prev, current, next) ||
                    IsCornerPoint(current, points))
                {
                    cleaned.Add(current);
                }

                prev = current;
                current = next;
            }

            // Mantener geometría cerrada
            if (cleaned.Count > 1 && cleaned[0] != cleaned[cleaned.Count - 1])
                cleaned.Add(cleaned[0]);

            return cleaned.Count < 3 ? points : cleaned;
        }

        private static bool IsCornerPoint(PointF point, List<PointF> polygon)
        {
            int index = polygon.IndexOf(point);
            if (index < 0) return false;

            int prev = (index - 1 + polygon.Count) % polygon.Count;
            int next = (index + 1) % polygon.Count;

            Vector2 v1 = new Vector2(
                polygon[prev].X - point.X,
                polygon[prev].Y - point.Y);

            Vector2 v2 = new Vector2(
                polygon[next].X - point.X,
                polygon[next].Y - point.Y);

            float angle = Vector2.AngleBetween(v1, v2);
            return Math.Abs(angle) > Tolerance && Math.Abs(angle - 180) > Tolerance;
        }

        private static bool IsCollinear(PointF a, PointF b, PointF c)
        {
            float area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            return Math.Abs(area) < Tolerance;
        }

        // Clase auxiliar para cálculos vectoriales
        private class Vector2
        {
            public float X { get; }
            public float Y { get; }

            public Vector2(float x, float y)
            {
                X = x;
                Y = y;
            }

            public static float AngleBetween(Vector2 v1, Vector2 v2)
            {
                float dot = v1.X * v2.X + v1.Y * v2.Y;
                float det = v1.X * v2.Y - v1.Y * v2.X;
                return (float)(Math.Atan2(det, dot) * (180 / Math.PI));
            }
        }
    }

    internal class Lines
    {

        public static PointF InterseccionSimple(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            PointF interseccion;

            bool vertical1 = (p2.X - p1.X == 0);
            bool vertical2 = (p4.X - p3.X == 0);

            if (vertical1 && vertical2)
            {
                return new PointF();
            }
            else if (vertical1)
            {
                float x = p1.X;
                float m2 = (p4.Y - p3.Y) / (p4.X - p3.X);
                float b2 = p3.Y - m2 * p3.X;
                float y = m2 * x + b2;
                return new PointF(x, y);
            }
            else if (vertical2)
            {
                float x = p3.X;
                float m1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                float b1 = p1.Y - m1 * p1.X;
                float y = m1 * x + b1;
                return new PointF(x, y);
            }
            else
            {
                float m1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                float b1 = p1.Y - m1 * p1.X;

                float m2 = (p4.Y - p3.Y) / (p4.X - p3.X);
                float b2 = p3.Y - m2 * p3.X;

                if (Math.Abs(m1 - m2) < 1e-6)
                {
                    return new PointF();
                }

                float x = (b2 - b1) / (m1 - m2);
                float y = m1 * x + b1;

                interseccion = new PointF(x, y);
                return interseccion;
            }
        }

    }

    internal class Polygon
    {
        private readonly int NumLados;
        private float Magnitud;
        private double RadRotate;
        private PointF Center;

        public Polygon(int numLados, float magnitud, PointF center = new PointF(), double radRotate = 0)
        {
            NumLados = numLados;
            Magnitud = magnitud;
            Center = center;
            RadRotate = radRotate;
        }

        public float GetMagnitud()
        {
            return Magnitud;
        }

        public void SetMagnitud(float newMag)
        {
            this.Magnitud = newMag;
        }

        public double GetRotation()
        {
            return RadRotate;
        }

        public void SetRotation(double newRadRotate)
        {
            RadRotate = newRadRotate;
        }

        public void Rotate(double newRadRotate)
        {
            RadRotate += newRadRotate;
        }

        public double GetRadius()
        {
            return Magnitud / (2 * Math.Sin(GetRad() / 2));
        }

        public double GetRad()
        {
            return Math.PI * 2 / NumLados;
        }

        public double GetApothema()
        {
            return Magnitud / (2 * Math.Tan(GetRad() / 2));
        }

        public int GetNumLados()
        {
            return NumLados;
        }

        public void TraslateX(float x)
        {
            this.Center.X += x;
        }

        public void TraslateY(float y)
        {
            this.Center.Y += y;
        }

        public PointF GetCenter()
        {
            return this.Center;
        }

        public void SetCenter(float x, float y)
        {
            this.Center.X = x;
            this.Center.Y = y;
        }

        public void SetCenter(PointF newCenter)
        {
            this.Center.X = newCenter.X;
            this.Center.Y = newCenter.Y;
        }

        public void ScalePercentage(float x)
        {
            this.Magnitud *= x;
        }

        public void ScaleInteger(float x)
        {
            this.Magnitud += x;
        }

        public PointF[] GetOutline()
        {
            List<PointF> points = new List<PointF>();
            double rad = GetRad();

            for (int i = 0; i < NumLados; i++)
            {
                PointF p = new PointF
                {
                    X = Center.X + (float)(Math.Cos((rad * i) + RadRotate) * Magnitud),
                    Y = Center.Y + (float)(Math.Sin((rad * i) + RadRotate) * Magnitud)
                };

                points.Add(p);
            }

            return points.ToArray();
        }

        public PointF[] GetSkeleton()
        {
            List<PointF> pointsSkeleton = new List<PointF>();
            PointF[] pointsPoly = GetOutline();

            for (int i = 0; i < NumLados; i++)
            {
                pointsSkeleton.Add(Center);

                pointsSkeleton.Add(pointsPoly[i]);

                pointsSkeleton.Add(Center);
            }

            return pointsSkeleton.ToArray();
        }
    }

}

