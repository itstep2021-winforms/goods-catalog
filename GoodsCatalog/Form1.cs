using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using GoodsCatalog.Models;

namespace GoodsCatalog
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;

        public List<Category> categories;
        public List<Producer> producers;
        public List<Product> products;
        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            connection = new SqlConnection(connectionString);

            categories = new List<Category>();
            producers = new List<Producer>();
            products = new List<Product>();
        }

        private string GetHash(string passw)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(passw));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        private void AuthUser()
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == DialogResult.OK)
            {
                string login = loginWindow.Login;
                string passw = loginWindow.Passw;
                passw = GetHash(passw);
                string sqlQuery = $"select Login, Passw from Users" +
                    $"where Login='{login}' and Password='{passw}'";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var row = reader.Read();
                    if (row)
                        MessageBox.Show("Autorisation passed", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Autorisation failed", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    this.Close();
                }
            }
        }

        private void LoadCategories()
        {
            try
            {
                string query = "select * from Categories";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                categoriesList.Items.Clear();
                categories.Clear();
                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    };
                    categoriesList.Items.Add(category);
                    categories.Add(category);
                }
                categoriesList.DisplayMember = "Name";
                categoriesList.ValueMember = "Id";
                if (categoriesList.Items.Count > 0)
                    categoriesList.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadProducers()
        {
            try
            {
                string query = "select * from Producers";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                producersList.Items.Clear();
                producers.Clear();
                while (reader.Read())
                {
                    Producer producer = new Producer()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    };
                    producersList.Items.Add(producer);
                    producers.Add(producer);
                }
                producersList.DisplayMember = "Name";
                producersList.ValueMember = "Id";
                if (producersList.Items.Count > 0)
                {
                    producersList.SelectedIndex = 0;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadProducts()
        {
            try
            {
                string query = "select * from Products";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                productsList.Items.Clear();
                products.Clear();
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                                                CategoryId = (int)reader["CategoryId"],
                        ProducerId = (int)reader["ProducerId"],
                        Price = (decimal)reader["Price"],
                        Count = (int)reader["Count"],
                        Measure = reader["Measure"].ToString(),
                        Expire = (DateTime)reader["Expire"],
                        Delivery = reader["Delivery"].ToString(),
                    };
                    var item = productsList.Items.Add(product.Name);
                    item.SubItems.Add(product.Price.ToString("F"));
                    item.SubItems.Add(product.Count.ToString());
                    item.SubItems.Add(product.Measure);
                    item.SubItems.Add(product.Expire.ToLongDateString());
                    item.SubItems.Add(product.Delivery.ToString());
                    products.Add(product);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AuthUser();
            LoadCategories();
            LoadProducers();
            LoadProducts();
        }

        private void createCategoryItem_Click(object sender, EventArgs e)
        {
            CategoriesEditor categoriesEditor = new CategoriesEditor();
            categoriesEditor.OperationTitle = "Додавання категорії";
            categoriesEditor.Categories = categories;
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                // Для запобігання sql-injections ЗАБОРОНЕНЕ підставляння значень змінних в запити
                // для цього використовують параметри - (@p1)
                // запити звуть ПАРАМЕТРИЗОВАНІ ЗАПИТИ 

                string query = $"insert into Categories (Name) values (@p1)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = categoriesEditor.CategoryName;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Категорія успішно додана", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }

        private void updateCategoryItem_Click(object sender, EventArgs e)
        {
            CategoriesEditor categoriesEditor = new CategoriesEditor();
            categoriesEditor.OperationTitle = "Редагування категорії";
            categoriesEditor.CategoryName = (categoriesList.SelectedItem as Category).Name;
            int id = (categoriesList.SelectedItem as Category).Id;
            categoriesEditor.Categories = categories;
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                string query = $"update Categories set Name=@p1 where Id=@p2";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = categoriesEditor.CategoryName;
                cmd.Parameters.Add("@p2", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Категорія успішно відредагована", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }

        private void deleteCategoryItem_Click(object sender, EventArgs e)
        {
            CategoriesEditor categoriesEditor = new CategoriesEditor();
            categoriesEditor.OperationTitle = "Видалення категорії";
            categoriesEditor.CategoryName = (categoriesList.SelectedItem as Category).Name;
            int id = (categoriesList.SelectedItem as Category).Id;
            categoriesEditor.Categories = categories;
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string query = $"delete from Categories where Id=@p2";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add("@p2", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Категорія успішно видалена", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    LoadCategories();
                    LoadProducts();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Помилка видалення категорії",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
