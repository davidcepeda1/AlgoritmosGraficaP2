using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoLineas
{
    internal class BSpline
    {
        private List<PointF> controlPoints;
        private int degree;
        private List<float> knotVector;

        public BSpline(int degree = 3)
        {
            this.degree = degree;
            this.controlPoints = new List<PointF>();
            this.knotVector = new List<float>();
        }

        public void AddControlPoint(PointF point)
        {
            controlPoints.Add(point);
            UpdateKnotVector();
        }

        public void RemoveLastControlPoint()
        {
            if (controlPoints.Count > 0)
            {
                controlPoints.RemoveAt(controlPoints.Count - 1);
                UpdateKnotVector();
            }
        }

        public void ClearControlPoints()
        {
            controlPoints.Clear();
            knotVector.Clear();
        }

        public List<PointF> GetControlPoints()
        {
            return new List<PointF>(controlPoints);
        }

        private void UpdateKnotVector()
        {
            int n = controlPoints.Count;
            if (n == 0) return;

            int m = n + degree + 1;
            knotVector.Clear();

            // Vector de nudos uniforme abierto
            for (int i = 0; i < m; i++)
            {
                if (i <= degree)
                    knotVector.Add(0.0f);
                else if (i >= n)
                    knotVector.Add(1.0f);
                else
                    knotVector.Add((float)(i - degree) / (n - degree));
            }
        }

        // Función base B-spline usando algoritmo de Cox-de Boor
        private float BasisFunction(int i, int p, float t)
        {
            if (p == 0)
            {
                return (t >= knotVector[i] && t < knotVector[i + 1]) ? 1.0f : 0.0f;
            }

            float left = 0.0f, right = 0.0f;

            if (knotVector[i + p] - knotVector[i] != 0)
                left = (t - knotVector[i]) / (knotVector[i + p] - knotVector[i]) * BasisFunction(i, p - 1, t);

            if (knotVector[i + p + 1] - knotVector[i + 1] != 0)
                right = (knotVector[i + p + 1] - t) / (knotVector[i + p + 1] - knotVector[i + 1]) * BasisFunction(i + 1, p - 1, t);

            return left + right;
        }

        // Evalúa la curva B-spline en el parámetro t
        public PointF EvaluateAt(float t)
        {
            if (controlPoints.Count <= degree) return new PointF(0, 0);

            // Asegurar que t esté en el rango válido
            t = Math.Max(0.0f, Math.Min(1.0f, t));

            float x = 0.0f, y = 0.0f;
            int n = controlPoints.Count;

            for (int i = 0; i < n; i++)
            {
                float basis = BasisFunction(i, degree, t);
                x += basis * controlPoints[i].X;
                y += basis * controlPoints[i].Y;
            }

            return new PointF(x, y);
        }

        // Genera puntos de la curva para dibujo
        public List<PointF> GenerateCurvePoints(int numPoints = 100)
        {
            List<PointF> curvePoints = new List<PointF>();

            if (controlPoints.Count <= degree) return curvePoints;

            for (int i = 0; i <= numPoints; i++)
            {
                float t = (float)i / numPoints;
                curvePoints.Add(EvaluateAt(t));
            }

            return curvePoints;
        }

        // Propiedades
        public int Degree
        {
            get { return degree; }
            set
            {
                degree = Math.Max(1, value);
                UpdateKnotVector();
            }
        }

        public int ControlPointCount
        {
            get { return controlPoints.Count; }
        }

        public bool CanGenerateCurve
        {
            get { return controlPoints.Count > degree; }
        }

        public List<float> KnotVector
        {
            get { return new List<float>(knotVector); }
        }
    }
}