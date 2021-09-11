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
            nameField.Text = CategoryName;        
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            CategoryName = nameField.Text;
            var category = Categories.Where(c => c.Name == CategoryName).FirstOrDefault();
            if (String.IsNullOrWhiteSpace(CategoryName))
            {
                MessageBox.Show("Вы не ввели название категории!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (category != null && OperationTitle != "Удаление категории")
            {
                MessageBox.Show("Категория с таким именем уже существует", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (category == null && OperationTitle == "Удаление категории")
            {
                MessageBox.Show("Категории с таким именем не существует", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
