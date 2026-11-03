using System;

namespace GeometryLibrary
{
    [Serializable]
    public class Tetragon
    {
        public Point[] Vertices { get; private set; }

        public Tetragon(Point p1, Point p2, Point p3, Point p4)
        {
            Vertices = new Point[] { p1, p2, p3, p4 };
        }

        // Метод для визначення приналежності заданої точки чотирикутнику (алгоритм трасування променя / Ray Casting)
        public bool ContainsPoint(Point p)
        {
            bool inside = false;
            int n = Vertices.Length;
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