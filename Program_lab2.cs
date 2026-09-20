using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_SelfTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 23;
            int cols = n / 2; // 11 стовпчиків

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string masPath = Path.Combine(desktopPath, "Mas");

            if (!Directory.Exists(masPath))
            {
                Directory.CreateDirectory(masPath);
            }

            // --- ЗАВДАННЯ 1 ---
            Console.WriteLine("=== Завдання 1 ===");
            Console.Write("Введіть ім'я файлу для масиву A (наприклад, arrayA.txt): ");
            string fileNameA = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileNameA)) fileNameA = "arrayA.txt";

            string pathA = Path.Combine(masPath, fileNameA);

            int[] arrayA = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                arrayA[i] = rnd.Next(1, n + 1);
            }

            File.WriteAllText(pathA, string.Join(" ", arrayA));
            Console.WriteLine($"Масив A (23 елементи) збережено в: {pathA}");
            Console.WriteLine("Зміст масиву A: " + string.Join(" ", arrayA));

            // --- ЗАВДАННЯ 2 ---
            Console.WriteLine("\n=== Завдання 2 ===");
            string[] rawA = File.ReadAllText(pathA).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] loadedA = Array.ConvertAll(rawA, int.Parse);

            int[,] arrayB = new int[2, cols];
            int evenIdx = 0, oddIdx = 0;

            for (int i = 0; i < loadedA.Length; i++)
            {
                if (i % 2 == 0 && evenIdx < cols)
                    arrayB[0, evenIdx++] = loadedA[i];
                else if (i % 2 != 0 && oddIdx < cols)
                    arrayB[1, oddIdx++] = loadedA[i];
            }

            string pathB = Path.Combine(masPath, "arrayB.txt");
            using (StreamWriter sw = new StreamWriter(pathB, false))
            {
                for (int r = 0; r < 2; r++)
                {
                    for (int c = 0; c < cols; c++)
                        sw.Write(arrayB[r, c] + " ");
                    sw.WriteLine();
                }
            }
            Console.WriteLine($"Двовимірний масив B (2x11) збережено у: {pathB}");

            // --- ЗАВДАННЯ 3 ---
            Console.WriteLine("\n=== Завдання 3 ===");
            char[] arrayC = new char[cols];
            char[] arrayCTransformed = new char[cols];

            for (int c = 0; c < cols; c++)
            {
                // Для коректного відображення символів зміщуємо код в діапазон читабельних ASCII (65-90)
                char ch = (char)(65 + (arrayB[1, c] % 26));
                arrayC[c] = ch;

                if (char.IsUpper(ch))
                    arrayCTransformed[c] = char.ToLower(ch);
                else
                    arrayCTransformed[c] = char.ToUpper(ch);
            }

            string pathC = Path.Combine(masPath, "arrayC.txt");
            using (StreamWriter sw = new StreamWriter(pathC, false))
            {
                sw.WriteLine(new string(arrayC));
                sw.WriteLine(new string(arrayCTransformed));
            }

            string[] readC = File.ReadAllLines(pathC);
            Console.WriteLine("Вихідний масив C:       " + readC[0]);
            Console.WriteLine("Трансформований масив C: " + readC[1]);

            // --- ЗАВДАННЯ 4 ---
            Console.WriteLine("\n=== Завдання 4 ===");
            DirectoryInfo dirInfo = new DirectoryInfo(masPath);
            FileInfo[] files = dirInfo.GetFiles().OrderBy(f => f.CreationTime).ToArray();

            Console.WriteLine("Створені файли:");
            foreach (var file in files)
            {
                Console.WriteLine($"Файл: {file.Name,-15} | Час створення: {file.CreationTime:HH:mm:ss}");
            }

            if (files.Length > 0)
            {
                FileInfo lastFile = files.Last();
                string newNamePath = Path.Combine(masPath, "renamed_last_file.txt");
                if (File.Exists(newNamePath)) File.Delete(newNamePath);

                string oldName = lastFile.Name;
                lastFile.MoveTo(newNamePath);
                Console.WriteLine($"\nОстанній файл '{oldName}' перейменовано на '{lastFile.Name}'");
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}