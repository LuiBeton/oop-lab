using System;
using System.Collections.Generic; // Потрібно для List<double>
using System.IO;                  // Потрібно для StreamWriter (файли)
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Завдання 1, 4, 5, 6, 7: Повний комплекс обчислень та виведення
        private void btnTabulate_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (!double.TryParse(textBox1.Text, out double a) ||
                !double.TryParse(textBox2.Text, out double b) ||
                !double.TryParse(textBox3.Text, out double h) || h <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для a, b, h!");
                return;
            }

            // Підготовка файлу для запису (Завдання 7)
            StreamWriter writer = null;
            if (checkBox2.Checked) // «Файл»
            {
                writer = new StreamWriter("Result.txt", false);
            }

            // Підготовка масиву/списку (Завдання 7)
            List<double> yValues = new List<double>();

            // Формування шапки
            string header = checkBox4.Checked ? "\t X \t F(X) \t F'(X) \n" : "\t X \t F(X) \n";
            if (checkBox1.Checked) richTextBox1.AppendText(header);
            if (checkBox2.Checked && writer != null) writer.WriteLine(header.Trim());

            double x = a;
            int countInRange = 0; // Завдання 5
            double minVal = Math.Cos(a) - 2; // Завдання 6
            double maxVal = Math.Cos(a) - 2;

            while (x <= b + h / 2)
            {
                double y = Math.Cos(x) - 2;   // f(x)
                double y1 = -Math.Sin(x);     // f'(x)

                // Завдання 7: Збереження в масив/список
                if (checkBox3.Checked) // «Масив»
                {
                    yValues.Add(y);
                }

                // Завдання 5: Перевірка умови (0.5; 1)
                if (y > 0.5 && y < 1.0)
                {
                    countInRange++;
                }

                // Завдання 6: Min / Max
                if (y < minVal) minVal = y;
                if (y > maxVal) maxVal = y;

                string str1 = string.Format("\t{0:f2}", x);
                string str2 = string.Format("\t{0:f2}", y);
                string str3 = checkBox4.Checked ? string.Format("\t{0:f2}", y1) : "";
                string line = str1 + str2 + str3;

                // Завдання 1: Вивід на Форму
                if (checkBox1.Checked)
                {
                    richTextBox1.AppendText(line + "\n");
                }

                // Завдання 7: Запис рядка у файл
                if (checkBox2.Checked && writer != null)
                {
                    writer.WriteLine(line.Trim());
                }

                x += h;
            }

            // Формування підсумків
            string summary = string.Format("\nКількість елементів (0.5; 1): {0}\nMin = {1:F2}, Max = {2:F2}\n", countInRange, minVal, maxVal);

            if (checkBox3.Checked)
            {
                summary += string.Format("Збережено в масив: {0} елементів\n", yValues.Count);
            }

            if (checkBox1.Checked)
            {
                richTextBox1.AppendText(summary);
            }

            // Завершення роботи з файлом
            if (checkBox2.Checked && writer != null)
            {
                writer.WriteLine(summary.Trim());
                writer.Close();
                MessageBox.Show("Результати успішно збережено у файл Result.txt!");
            }
        }

        // Завдання 2: «Завершити» в контекстному меню
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Завдання 3: Зняти всі прапорці
        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        // Завдання 3: Встановити всі прапорці
        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
        }
    }
}