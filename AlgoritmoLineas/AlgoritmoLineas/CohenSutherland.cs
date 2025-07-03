using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace AlgoritmoLineas
{
    internal class CohenSutherland
    {
        public CohenSutherland() { }
        public static PointF[] clippingAlgorithm(List<PointF> points, PointF[] pointsCanvas)
        {
            List<PointF> clipedPoints = new List<PointF>();
            if (points.Count % 2 != 0) { points.RemoveAt(points.Count - 1); }

            // get polygon limits
            float minX = pointsCanvas.Min(pt => pt.X);
            float maxX = pointsCanvas.Max(pt => pt.X);
            float minY = pointsCanvas.Min(pt => pt.Y);
            float maxY = pointsCanvas.Max(pt => pt.Y);

            int auxIndex = 0;
            for (int i = 0; i < points.Count / 2; i++)
            {
                auxIndex = (i == 0) ? i + 1 : (i * 2) + 1;

                bool topP1 = (points[auxIndex - 1].Y > maxY);
                bool bottomP1 = (points[auxIndex - 1].Y < minY);
                bool rightP1 = (points[auxIndex - 1].X > maxX);
                bool leftP1 = (points[auxIndex - 1].X < minX);

                bool topP2 = (points[auxIndex].Y > maxY);
                bool bottomP2 = (points[auxIndex].Y < minY);
                bool rightP2 = (points[auxIndex].X > maxX);
                bool leftP2 = (points[auxIndex].X < minX);

                bool Bloque1 = (topP1 || bottomP1 || rightP1 || leftP1);
                bool Bloque2 = (topP2 || bottomP2 || rightP2 || leftP2);

                if (!Bloque1 && !Bloque2)
                {
                    clipedPoints.Add(points[auxIndex]);
                    clipedPoints.Add(points[auxIndex - 1]);
                }
                else if ((Bloque1 && Bloque2) || (Bloque1 ^ Bloque2))
                {
                    if (Bloque1 && Bloque2)
                    {
                        bool[] endP1 = { topP1, bottomP1, rightP1, leftP1 };
                        bool[] endP2 = { topP2, bottomP2, rightP2, leftP2 };
                        string codeEndP1 = string.Concat(endP1.Select(b => b ? "1" : "0"));
                        string codeEndP2 = string.Concat(endP2.Select(b => b ? "1" : "0"));

                        PointF canvaInitPoint1 = PointF.Empty;
                        PointF canvaEndPoint1 = PointF.Empty;
                        PointF canvaInitPoint2 = PointF.Empty;
                        PointF canvaEndPoint2 = PointF.Empty;

                        switch (codeEndP1)
                        {
                            case "0000":
                                clipedPoints.Add(points[auxIndex - 1]);
                                break;
                            case "1001": // top & left
                            case "0001": // left
                            case "0101": // bottom & left
                                canvaInitPoint1 = new PointF(minX, minY);
                                canvaEndPoint1 = new PointF(minX, maxY);
                                break;
                            case "1010": // top & right
                            case "0010": // right
                            case "0110": // bottom & right
                                canvaInitPoint1 = new PointF(maxX, minY);
                                canvaEndPoint1 = new PointF(maxX, maxY);
                                break;
                            case "1000": // top
                                canvaInitPoint1 = new PointF(minX, maxY);
                                canvaEndPoint1 = new PointF(maxX, maxY);
                                break;
                            case "0100": // bottom
                                canvaInitPoint1 = new PointF(minX, minY);
                                canvaEndPoint1 = new PointF(maxX, minY);
                                break;
                            default:
                                break;
                        }

                        switch (codeEndP2)
                        {
                            case "0000":
                                clipedPoints.Add(points[auxIndex]);
                                break;
                            case "1001":
                            case "0001":
                            case "0101":
                                canvaInitPoint2 = new PointF(minX, minY);
                                canvaEndPoint2 = new PointF(minX, maxY);
                                break;
                            case "1010":
                            case "0010":
                            case "0110":
                                canvaInitPoint2 = new PointF(maxX, minY);
                                canvaEndPoint2 = new PointF(maxX, maxY);
                                break;
                            case "1000":
                                canvaInitPoint2 = new PointF(minX, maxY);
                                canvaEndPoint2 = new PointF(maxX, maxY);
                                break;
                            case "0100":
                                canvaInitPoint2 = new PointF(minX, minY);
                                canvaEndPoint2 = new PointF(maxX, minY);
                                break;
                            default:
                                break;
                        }

                        if (canvaInitPoint1 != PointF.Empty && canvaEndPoint1 != PointF.Empty)
                        {
                            PointF interseccion1 = Lines.InterseccionSimple(points[auxIndex - 1], points[auxIndex], canvaInitPoint1, canvaEndPoint1);
                            if (interseccion1 != PointF.Empty)
                                clipedPoints.Add(interseccion1);
                        }
                        if (canvaInitPoint2 != PointF.Empty && canvaEndPoint2 != PointF.Empty)
                        {
                            PointF interseccion2 = Lines.InterseccionSimple(points[auxIndex - 1], points[auxIndex], canvaInitPoint2, canvaEndPoint2);
                            if (interseccion2 != PointF.Empty)
                                clipedPoints.Add(interseccion2);
                        }
                    }

                    if (Bloque1 ^ Bloque2)
                    {
                        int insideIdx = !Bloque1 ? auxIndex - 1 : auxIndex;
                        int outsideIdx = Bloque1 ? auxIndex - 1 : auxIndex;

                        bool top = (points[outsideIdx].Y > maxY);
                        bool bottom = (points[outsideIdx].Y < minY);
                        bool right = (points[outsideIdx].X > maxX);
                        bool left = (points[outsideIdx].X < minX);

                        List<(PointF, PointF)> borders = new List<(PointF, PointF)>();
                        if (top)
                            borders.Add((new PointF(minX, maxY), new PointF(maxX, maxY)));
                        if (bottom)
                            borders.Add((new PointF(minX, minY), new PointF(maxX, minY)));
                        if (right)
                            borders.Add((new PointF(maxX, minY), new PointF(maxX, maxY)));
                        if (left)
                            borders.Add((new PointF(minX, minY), new PointF(minX, maxY)));

                        foreach (var border in borders)
                        {
                            PointF inter = Lines.InterseccionSimple(points[auxIndex - 1], points[auxIndex], border.Item1, border.Item2);
                            if (inter != PointF.Empty)
                            {
                                clipedPoints.Add(points[insideIdx]);
                                clipedPoints.Add(inter);
                                break;
                            }
                        }
                    }
                }
            }
            return clipedPoints.ToArray();
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




