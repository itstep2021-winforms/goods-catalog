using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoodsCatalog.Models;

namespace GoodsCatalog
{
    public partial class CategoriesEditor : Form
    {
        public string OperationTitle { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
        public CategoriesEditor()
        {
            InitializeComponent();

        }

        private void CategoriesEditor_Load(object sender, EventArgs e)
        {
            title.Text = OperationTitle;
            nameFiled.Text = CategoryName;
            //nameFiled.Text = Categories.Count.ToString();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            CategoryName = nameFiled.Text;
            var category = Categories
                .Where(c => c.Name == CategoryName).FirstOrDefault();
            if (String.IsNullOrWhiteSpace(CategoryName))
            {
                MessageBox.Show("Назва категорії не введена!", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (category != null && OperationTitle != "Видалення категорії")
            {
                MessageBox.Show($"Категорія '{CategoryName}' вже існує", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (category == null && OperationTitle != "Додавання категорії")
            {
                MessageBox.Show($"Категорії '{CategoryName}' не існує", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
