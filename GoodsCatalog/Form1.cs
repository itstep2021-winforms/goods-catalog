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

        List<Category> categories;
        List<Producer> producers;
        List<Product> products;

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

                string sqlQuery = $"select Login, Password from Users where Login='{login}' and Password='{passw}'";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var row = reader.Read();

                    if (row)
                    {
                        MessageBox.Show("Вы успешно авторизованы", "Сообщение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка выполнения",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
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
                //
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
                {
                    categoriesList.SelectedIndex = 0;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка загрузки категорий",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //
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
                MessageBox.Show(err.Message, "Ошибка загрузки производителей",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //
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
                        Delivery = reader["Delivery"].ToString()
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
                MessageBox.Show(err.Message, "Ошибка загрузки товаров",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            categoriesEditor.OperationTitle = "Добавление категории";
            categoriesEditor.Categories = categories;
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                // Для избежания SQL-иньекций ЗАПРЕЩЕНО подставлять значения переменных
                // прямо в строку запроса => для этого следует использовать специальные
                // параметры (параметризованные запросы) !!! 
                string query = $"insert into Categories (Name) values (@p1)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = categoriesEditor.CategoryName;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Категория успешно добавлена", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }

        private void updateCategoryItem_Click(object sender, EventArgs e)
        {
            CategoriesEditor categoriesEditor = new CategoriesEditor();
            categoriesEditor.OperationTitle = "Изменение категории";
            categoriesEditor.CategoryName = (categoriesList.SelectedItem as Category).Name;
            int id = (categoriesList.SelectedItem as Category).Id;
            categoriesEditor.Categories = categories;            
            //
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                string query = $"update Categories set Name=@p1 where Id=@p2";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = categoriesEditor.CategoryName;
                cmd.Parameters.Add("@p2", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Категория успешно изменена", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }

        private void deleteCategoryItem_Click(object sender, EventArgs e)
        {
            CategoriesEditor categoriesEditor = new CategoriesEditor();
            categoriesEditor.OperationTitle = "Удаление категории";
            categoriesEditor.CategoryName = (categoriesList.SelectedItem as Category).Name;
            int id = (categoriesList.SelectedItem as Category).Id;
            categoriesEditor.Categories = categories;
            //
            if (categoriesEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string query = $"delete from Categories where Id=@p2";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add("@p2", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Категория успешно удалена", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    LoadCategories();
                    LoadProducts();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка удаления категории",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
