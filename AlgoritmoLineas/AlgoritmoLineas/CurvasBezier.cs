using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoLineas
{
    internal class CurvasBezier
    {
        private const float Tolerance = 1e-6f;

        public static PointF[] CalculateBezierCurve(List<PointF> controlPoints, int resolution = 100)
        {
            if (controlPoints == null || controlPoints.Count < 2)
                return new PointF[0];

            List<PointF> curvePoints = new List<PointF>();

            // Generar puntos de la curva usando parámetro t de 0 a 1
            for (int i = 0; i <= resolution; i++)
            {
                float t = (float)i / resolution;
                PointF point = DeCasteljauAlgorithm(controlPoints, t);
                curvePoints.Add(point);
            }

            return curvePoints.ToArray();
        }

        public static PointF DeCasteljauAlgorithm(List<PointF> controlPoints, float t)
        {
            List<PointF> points = new List<PointF>(controlPoints);

            // Algoritmo recursivo de De Casteljau
            while (points.Count > 1)
            {
                List<PointF> newPoints = new List<PointF>();

                for (int i = 0; i < points.Count - 1; i++)
                {
                    float x = (1 - t) * points[i].X + t * points[i + 1].X;
                    float y = (1 - t) * points[i].Y + t * points[i + 1].Y;
                    newPoints.Add(new PointF(x, y));
                }

                points = newPoints;
            }

            return points[0];
        }

        public static PointF[] QuadraticBezier(PointF p0, PointF p1, PointF p2, int resolution = 100)
        {
            List<PointF> controlPoints = new List<PointF> { p0, p1, p2 };
            return CalculateBezierCurve(controlPoints, resolution);
        }

        public static PointF[] CubicBezier(PointF p0, PointF p1, PointF p2, PointF p3, int resolution = 100)
        {
            List<PointF> controlPoints = new List<PointF> { p0, p1, p2, p3 };
            return CalculateBezierCurve(controlPoints, resolution);
        }

        public static List<PointF[]> GetConstructionLines(List<PointF> controlPoints, float t)
        {
            List<PointF[]> constructionLines = new List<PointF[]>();
            List<PointF> currentPoints = new List<PointF>(controlPoints);

            while (currentPoints.Count > 1)
            {
                List<PointF> nextPoints = new List<PointF>();

                for (int i = 0; i < currentPoints.Count - 1; i++)
                {
                    // Calcular punto intermedio
                    float x = (1 - t) * currentPoints[i].X + t * currentPoints[i + 1].X;
                    float y = (1 - t) * currentPoints[i].Y + t * currentPoints[i + 1].Y;
                    PointF intermediatePoint = new PointF(x, y);

                    nextPoints.Add(intermediatePoint);

                    // Agregar línea de construcción
                    constructionLines.Add(new PointF[] { currentPoints[i], currentPoints[i + 1] });
                }

                currentPoints = nextPoints;
            }

            return constructionLines;
        }

        public static List<PointF> GetIntermediatePoints(List<PointF> controlPoints, float t)
        {
            List<PointF> allIntermediatePoints = new List<PointF>();
            List<PointF> currentPoints = new List<PointF>(controlPoints);

            while (currentPoints.Count > 1)
            {
                List<PointF> nextPoints = new List<PointF>();

                for (int i = 0; i < currentPoints.Count - 1; i++)
                {
                    float x = (1 - t) * currentPoints[i].X + t * currentPoints[i + 1].X;
                    float y = (1 - t) * currentPoints[i].Y + t * currentPoints[i + 1].Y;
                    PointF intermediatePoint = new PointF(x, y);

                    nextPoints.Add(intermediatePoint);
                    allIntermediatePoints.Add(intermediatePoint);
                }

                currentPoints = nextPoints;
            }

            return allIntermediatePoints;
        }

        public static PointF GetTangentVector(List<PointF> controlPoints, float t)
        {
            if (controlPoints.Count < 2)
                return new PointF(0, 0);

            // Crear puntos de control para la derivada
            List<PointF> derivativePoints = new List<PointF>();
            int n = controlPoints.Count - 1;

            for (int i = 0; i < n; i++)
            {
                float x = n * (controlPoints[i + 1].X - controlPoints[i].X);
                float y = n * (controlPoints[i + 1].Y - controlPoints[i].Y);
                derivativePoints.Add(new PointF(x, y));
            }

            return DeCasteljauAlgorithm(derivativePoints, t);
        }

        public static PointF FindClosestPoint(List<PointF> controlPoints, PointF targetPoint, int resolution = 1000)
        {
            PointF closestPoint = new PointF();
            float minDistance = float.MaxValue;

            for (int i = 0; i <= resolution; i++)
            {
                float t = (float)i / resolution;
                PointF curvePoint = DeCasteljauAlgorithm(controlPoints, t);

                float distance = GetDistance(curvePoint, targetPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = curvePoint;
                }
            }

            return closestPoint;
        }

        private static float GetDistance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private static bool IsValidPoint(PointF point)
        {
            return !float.IsNaN(point.X) && !float.IsInfinity(point.X) &&
                   !float.IsNaN(point.Y) && !float.IsInfinity(point.Y);
        }

        public static List<PointF> ElevateDegreeBezier(List<PointF> controlPoints)
        {
            if (controlPoints.Count < 2)
                return controlPoints;

            List<PointF> elevatedPoints = new List<PointF>();
            int n = controlPoints.Count - 1;

            // Primer punto permanece igual
            elevatedPoints.Add(controlPoints[0]);

            // Puntos intermedios
            for (int i = 1; i <= n; i++)
            {
                float alpha = (float)i / (n + 1);
                float x = alpha * controlPoints[i - 1].X + (1 - alpha) * controlPoints[i].X;
                float y = alpha * controlPoints[i - 1].Y + (1 - alpha) * controlPoints[i].Y;
                elevatedPoints.Add(new PointF(x, y));
            }

            // Último punto permanece igual
            elevatedPoints.Add(controlPoints[controlPoints.Count - 1]);

            return elevatedPoints;
        }
    }
}