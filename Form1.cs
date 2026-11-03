using System;
using System.Collections.Generic;
using System.Drawing; // Потрібно для кольорів тексту (Color.Green, Color.Red)
using System.Windows.Forms;
using GeometryLibrary;

// ТВІЙ РІДНИЙ ПРОСТІР ІМЕН
namespace formlab5
{
    public partial class Form1 : Form
    {
        private Tetragon tetragon;
        private Polygon polygon;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheckTetragon_Click(object sender, EventArgs e)
        {
            try
            {
                // ЯВНО вказуємо GeometryLibrary.Point, щоб не було конфлікту (CS1503)
                GeometryLibrary.Point p1 = new GeometryLibrary.Point(0, 0);
                GeometryLibrary.Point p2 = new GeometryLibrary.Point(4, 0);
                GeometryLibrary.Point p3 = new GeometryLibrary.Point(4, 4);
                GeometryLibrary.Point p4 = new GeometryLibrary.Point(0, 4);

                tetragon = new Tetragon(p1, p2, p3, p4);

                double px = Convert.ToDouble(txtPointX.Text);
                double py = Convert.ToDouble(txtPointY.Text);
                GeometryLibrary.Point testPoint = new GeometryLibrary.Point(px, py);

                bool isInside = tetragon.ContainsPoint(testPoint);

                if (isInside)
                {
                    lblTetragonResult.Text = "Результат: Точка НАЛЕЖИТЬ чотирикутнику";
                    lblTetragonResult.ForeColor = Color.Green;
                }
                else
                {
                    lblTetragonResult.Text = "Результат: Точка НЕ НАЛЕЖИТЬ чотирикутнику";
                    lblTetragonResult.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення даних: " + ex.Message);
            }
        }

        private void btnGeneratePolygon_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(txtPointCount.Text);
                if (n < 3) return;

                List<GeometryLibrary.Point> randomPoints = new List<GeometryLibrary.Point>();
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                {
                    // Використовуємо double для генерації координат
                    double rx = rnd.Next(-10, 10);
                    double ry = rnd.Next(-10, 10);
                    randomPoints.Add(new GeometryLibrary.Point(rx, ry));
                }

                polygon = Polygon.BuildNonIntersectingPolygon(randomPoints);

                double area = polygon.CalculateArea();
                bool isConvex = polygon.IsConvex();

                lblPolygonArea.Text = $"Площа багатокутника: {area:F2}";
                lblPolygonConvex.Text = isConvex ? "Статус: ОПУКЛИЙ" : "Статус: НЕОПУКЛИЙ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}