using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3
{
    public partial class EditProduct : Form
    {
        private MySqlConnection connection;
        private int id;
        private bool isNew; // true - додавання, false - редагування

        public EditProduct(bool isNew, int id, MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            this.id = id;
            this.isNew = isNew;

            LoadCategories();

            if (!isNew)
            {
                // Режим редагування
                LoadProductData();
            }
            else
            {
                // Режим додавання
                this.Text = "Додати запис";
                label2.Visible = false;
                textBox5.Visible = true; // Відображаємо поле для введення коду
                button1.Text = "Додати";
            }
        }

        // Завантаження категорій у ComboBox
        private void LoadCategories()
        {
            string query = "SELECT Id_category, Category_name FROM categories ORDER BY Id_category";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "Category_name";
            comboBox1.ValueMember = "Id_category";
        }

        // Завантаження даних обраного товару
        private void LoadProductData()
        {
            string query = "SELECT Id_product, Product_name, Unit, Price, Id_category, Quantity FROM products WHERE Id_product = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    label2.Text = reader["Id_product"].ToString();
                    textBox1.Text = reader["Product_name"].ToString();
                    textBox2.Text = reader["Unit"].ToString();
                    textBox3.Text = reader["Price"].ToString();
                    comboBox1.SelectedValue = reader["Id_category"];
                    textBox4.Text = reader["Quantity"].ToString();
                }
            }
        }

        // Кнопка Зберегти / Додати
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isNew)
            {
                // Оновлення (UPDATE)
                string query = "UPDATE products SET Product_name = @name, Unit = @unit, Price = @price, " +
                               "Id_category = @catId, Quantity = @qty WHERE Id_product = @id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@unit", textBox2.Text);
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox3.Text));
                command.Parameters.AddWithValue("@catId", comboBox1.SelectedValue);
                command.Parameters.AddWithValue("@qty", Convert.ToInt32(textBox4.Text));
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                MessageBox.Show("Дані оновлено");
            }
            else
            {
                // Створення нового (INSERT)
                string query = "INSERT INTO products (Id_product, Product_name, Unit, Price, Id_category, Quantity) " +
                               "VALUES (@id, @name, @unit, @price, @catId, @qty)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Convert.ToInt32(textBox5.Text));
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@unit", textBox2.Text);
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox3.Text));
                command.Parameters.AddWithValue("@catId", comboBox1.SelectedValue);
                command.Parameters.AddWithValue("@qty", Convert.ToInt32(textBox4.Text));

                command.ExecuteNonQuery();
                MessageBox.Show("Дані внесено");
            }

            this.Close();
        }

        // Кнопка Скасувати
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}