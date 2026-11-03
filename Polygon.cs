using System;
using System.Collections.Generic;

namespace GeometryLibrary
{
    [Serializable]
    public class Polygon
    {
        public List<Point> Vertices { get; private set; }

        public Polygon(List<Point> vertices)
        {
            Vertices = vertices;
        }

        // Побудова багатокутника без перетинів із випадкових точок шляхом сортування за полярним кутом
        public static Polygon BuildNonIntersectingPolygon(List<Point> randomPoints)
        {
            if (randomPoints == null || randomPoints.Count < 3)
                return new Polygon(randomPoints);

            // Знаходимо центр мас (цироїд)
            double cx = 0, cy = 0;
            foreach (var pt in randomPoints)
            {
                cx += pt.X;
                cy += pt.Y;
            }
            cx /= randomPoints.Count;
            cy /= randomPoints.Count;

            // Сортуємо точки за кутом відносно центра мас
            var sorted = new List<Point>(randomPoints);
            sorted.Sort((a, b) =>
            {
                double angleA = Math.Atan2(a.Y - cy, a.X - cx);
                double angleB = Math.Atan2(b.Y - cy, b.X - cx);
                return angleA.CompareTo(angleB);
            });

            return new Polygon(sorted);
        }

        // Обчислення площі багатокутника (формула шнурівки Гауса)
        public double CalculateArea()
        {
            double area = 0;
            int n = Vertices.Count;
            for (int i = 0; i < n; i++)
            {
                Point p1 = Vertices[i];
                Point p2 = Vertices[(i + 1) % n];
                area += (p1.X * p2.Y) - (p2.X * p1.Y);
            }
            return Math.Abs(area) / 2.0;
        }

        // Визначення, чи є багатокутник опуклим
        public bool IsConvex()
        {
            int n = Vertices.Count;
            if (n < 3) return false;
            bool hasPositive = false;
            bool hasNegative = false;

            for (int i = 0; i < n; i++)
            {
                Point p1 = Vertices[i];
                Point p2 = Vertices[(i + 1) % n];
                Point p3 = Vertices[(i + 2) % n];

                double crossProduct = (p2.X - p1.X) * (p3.Y - p2.Y) - (p2.Y - p1.Y) * (p3.X - p2.X);

                if (crossProduct > 0) hasPositive = true;
                if (crossProduct < 0) hasNegative = true;

                if (hasPositive && hasNegative) return false;
            }
            return true;
        }

        // Перевірка приналежності заданої точки багатокутнику
        public bool ContainsPoint(Point p)
        {
            bool inside = false;
            int n = Vertices.Count;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if (((Vertices[i].Y > p.Y) != (Vertices[j].Y > p.Y)) &&
                    (p.X < (Vertices[j].X - Vertices[i].X) * (p.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) + Vertices[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }
}