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
        public string Passw { get; set; }
        public string Login { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            Login = loginField.Text;
            Passw = passwField.Text;
            if(String.IsNullOrWhiteSpace(Login))
            {
                MessageBox.Show("Login not entered!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrWhiteSpace(Passw))
            {
                MessageBox.Show("Password not entered!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }



    }
}
