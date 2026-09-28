using System;
using System.Windows.Forms;
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

            richTextBox1.AppendText("\t X \t F(X) \n");

            double x = a;
            while (x <= b + h / 2)
            {
                double y = Math.Cos(x) - 2;

                string str1 = string.Format("\t{0:f2}", x);
                string str2 = string.Format("\t{0:f2}", y);

                if (checkBox1.Checked)
                {
                    richTextBox1.AppendText(str1 + str2 + "\n");
                }

                x += h;
            }
        }
    }
}
