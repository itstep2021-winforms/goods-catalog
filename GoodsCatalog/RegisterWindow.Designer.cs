namespace GoodsCatalog
{
    partial class RegisterWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.register_button = new System.Windows.Forms.Button();
            this.role_selector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(388, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.role_selector);
            this.groupBox2.Controls.Add(this.register_button);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.password_textBox);
            this.groupBox2.Controls.Add(this.login_textBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 73);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox2.Size = new System.Drawing.Size(388, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // login_textBox
            // 
            this.login_textBox.Location = new System.Drawing.Point(183, 25);
            this.login_textBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(172, 34);
            this.login_textBox.TabIndex = 0;
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(183, 69);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(172, 34);
            this.password_textBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(61, 25);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(261, 43);
            label1.TabIndex = 0;
            label1.Text = "Registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Login:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // register_button
            // 
            this.register_button.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.register_button.Location = new System.Drawing.Point(116, 151);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(147, 51);
            this.register_button.TabIndex = 4;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            // 
            // role_selector
            // 
            this.role_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role_selector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.role_selector.FormattingEnabled = true;
            this.role_selector.Items.AddRange(new object[] {
            "User",
            "Admin",
            "Manager"});
            this.role_selector.Location = new System.Drawing.Point(183, 112);
            this.role_selector.Name = "role_selector";
            this.role_selector.Size = new System.Drawing.Size(172, 33);
            this.role_selector.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Role:";
            // 
            // RegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(388, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "RegisterWindow";
            this.Text = "RegisterWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox role_selector;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox login_textBox;
    }
}