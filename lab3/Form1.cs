using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        // Завдання 1-9: Табулювання, обчислення похідної та побудова двох графіків
        private void btnTabulate_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // Завдання 9: Очищення точок для ОБОХ серій графіка перед новим розрахунком
            if (chart1.Series.Count > 0)
            {
                chart1.Series[0].Points.Clear(); // Серія для f(x)
            }
            if (chart1.Series.Count > 1)
            {
                chart1.Series[1].Points.Clear(); // Серія для f'(x)
            }

            if (!double.TryParse(textBox1.Text, out double a) ||
                !double.TryParse(textBox2.Text, out double b) ||
                !double.TryParse(textBox3.Text, out double h) || h <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для a, b, h!");
                return;
            }

            StreamWriter writer = null;
            if (checkBox2.Checked)
            {
                writer = new StreamWriter("Result.txt", false);
            }

            List<double> yValues = new List<double>();

            string header = checkBox4.Checked ? "\t X \t F(X) \t F'(X) \n" : "\t X \t F(X) \n";
            if (checkBox1.Checked) richTextBox1.AppendText(header);
            if (checkBox2.Checked && writer != null) writer.WriteLine(header.Trim());

            double x = a;
            int countInRange = 0;
            double minVal = Math.Cos(a) - 2;
            double maxVal = Math.Cos(a) - 2;

            while (x <= b + h / 2)
            {
                double y = Math.Cos(x) - 2;   // f(x)
                double y1 = -Math.Sin(x);     // f'(x) (похідна)

                // Завдання 9: Додавання точок для обох графіків
                if (chart1.Series.Count > 0)
                {
                    chart1.Series[0].Points.AddXY(x, y); // Графік функції f(x)
                }

                if (chart1.Series.Count > 1 && checkBox4.Checked)
                {
                    chart1.Series[1].Points.AddXY(x, y1); // Графік похідної f'(x)
                }

                if (checkBox3.Checked)
                {
                    yValues.Add(y);
                }

                if (y > 0.5 && y < 1.0)
                {
                    countInRange++;
                }

                if (y < minVal) minVal = y;
                if (y > maxVal) maxVal = y;

                string str1 = string.Format("\t{0:f2}", x);
                string str2 = string.Format("\t{0:f2}", y);
                string str3 = checkBox4.Checked ? string.Format("\t{0:f2}", y1) : "";
                string line = str1 + str2 + str3;

                if (checkBox1.Checked)
                {
                    richTextBox1.AppendText(line + "\n");
                }

                if (checkBox2.Checked && writer != null)
                {
                    writer.WriteLine(line.Trim());
                }

                x += h;
            }

            string summary = string.Format("\nКількість елементів (0.5; 1): {0}\nMin = {1:F2}, Max = {2:F2}\n", countInRange, minVal, maxVal);

            if (checkBox3.Checked)
            {
                summary += string.Format("Збережено в масив: {0} елементів\n", yValues.Count);
            }

            if (checkBox1.Checked)
            {
                richTextBox1.AppendText(summary);
            }

            if (checkBox2.Checked && writer != null)
            {
                writer.WriteLine(summary.Trim());
                writer.Close();
                MessageBox.Show("Результати успішно збережено у файл Result.txt!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
        }
    }
}