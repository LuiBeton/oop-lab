using System;

namespace Lab1_Correct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int i = 23; // Номер варіанта

            // ====================================================
            // ЗАВДАННЯ 1: Сторона та площа квадрата
            // ====================================================
            Console.WriteLine("=== Завдання 1 ===");
            Console.Write("Введіть діагональ d: ");
            double d = Convert.ToDouble(Console.ReadLine());

            double side = d / Math.Sqrt(2);
            double area = Math.Pow(d, 2) / 2.0;

            Console.WriteLine($"Сторона квадрата a = {side:F4}");
            Console.WriteLine($"Площа квадрата S = {area:F4}\n");

            // ====================================================
            // ЗАВДАННЯ 2: Обчислення функції y від x
            // ====================================================
            Console.WriteLine("=== Завдання 2 ===");
            Console.Write("Введіть x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть c: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть d_param: ");
            double d_param = Convert.ToDouble(Console.ReadLine());

            double y;
            if (Math.Abs(x) < 10)
            {
                double v = Math.Tan(x / i + a) - Math.Log(Math.Abs(b * i + 7));
                y = v; // f(v)
            }
            else
            {
                double w = c * Math.Sqrt(Math.Pow(x, 2) + d_param * Math.Pow(i, 12));
                y = w; // f(w)
            }
            Console.WriteLine($"Результат y = {y:F4}\n");

            // ====================================================
            // ЗАВДАННЯ 3: Вибір друга за номером (switch/case)
            // ====================================================
            Console.WriteLine("=== Завдання 3 ===");
            Console.Write("Введіть номер друга (1-4): ");
            int friendNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Результат (через switch): ");
            switch (friendNo)
            {
                case 1: Console.WriteLine("Саня"); break;
                case 2: Console.WriteLine("Міша"); break;
                case 3: Console.WriteLine("Андрій"); break;
                case 4: Console.WriteLine("Олексій"); break;
                default: Console.WriteLine("Невідомий номер друга"); break;
            }

            // ====================================================
            // ЗАВДАННЯ 4: Обчислення виразу для варіанта 23
            // ====================================================
            Console.WriteLine("\n=== Завдання 4 ===");
            Console.Write("Введіть x для виразу: ");
            double x4 = Convert.ToDouble(Console.ReadLine());

            double fx = (Math.Sin(Math.Abs(x4)) / 0.1) + 9.4 * Math.Sin(3 * x4 - 2.5);
            Console.WriteLine($"Результат f(x) = {fx:F4}");

            Console.ReadKey();
        }
    }
}