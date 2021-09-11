using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsCatalog
{
    public partial class LoginWindow : Form
    {
        public string Login { get; set; }
        public string Passw { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login = loginField.Text;
            Passw = passwField.Text;
            if (String.IsNullOrWhiteSpace(Login))
            {
                MessageBox.Show("Вы не ввели логин!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrWhiteSpace(Passw))
            {
                MessageBox.Show("Вы не ввели пароль!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }            
        }
    }
}
