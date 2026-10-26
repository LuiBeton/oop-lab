using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lab3
{
    public partial class Form1 : Form
    {
        // Рядок підключення до MAMP (порт 8889, користувач root, пароль root)
        private string constr = "Server=127.0.0.1;Port=3306;Database=grocery_base;Uid=root;Pwd=root;Charset=utf8;";
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(constr);
            connection.Open();
        }

        // 1. Вивести всі товари
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT p.Id_product, p.Product_name, p.Unit, p.Price, c.Category_name, p.Quantity " +
                           "FROM products p JOIN categories c ON p.Id_category = c.Id_category";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            SetGridHeaders();
        }

        // 2. Фільтрація по RadioButton (Група/Категорія)
        private void radioButton_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string categoryName = rb.Text;

            string query = "SELECT p.Id_product, p.Product_name, p.Unit, p.Price, c.Category_name, p.Quantity " +
                           "FROM products p JOIN categories c ON p.Id_category = c.Id_category " +
                           "WHERE c.Category_name = @catName";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@catName", categoryName);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            SetGridHeaders();
        }

        // Заголовки стовпчиків
        private void SetGridHeaders()
        {
            if (dataGridView1.Columns.Count >= 6)
            {
                dataGridView1.Columns[0].HeaderText = "Код товару";
                dataGridView1.Columns[1].HeaderText = "Назва";
                dataGridView1.Columns[2].HeaderText = "Од. вим.";
                dataGridView1.Columns[3].HeaderText = "Ціна (грн)";
                dataGridView1.Columns[4].HeaderText = "Категорія";
                dataGridView1.Columns[5].HeaderText = "Кількість";
            }
        }

        // 3. Редагувати
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int productId = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                EditProduct frm = new EditProduct(false, productId, connection);
                frm.ShowDialog();
                button1_Click(null, null); // Оновити таблицю
            }
        }

        // 4. Додати запис
        private void button3_Click(object sender, EventArgs e)
        {
            EditProduct frm = new EditProduct(true, 0, connection);
            frm.ShowDialog();
            button1_Click(null, null); // Оновити таблицю
        }

        // 5. Видалити
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int productId = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);

                string query = "DELETE FROM products WHERE Id_product = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", productId);
                command.ExecuteNonQuery();

                MessageBox.Show("Товар видалено з бази");
                button1_Click(null, null);
            }
        }
    }
}