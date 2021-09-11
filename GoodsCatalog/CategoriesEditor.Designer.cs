namespace GoodsCatalog
{
    partial class CategoriesEditor
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
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameFiled = new System.Windows.Forms.TextBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(108, 35);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(181, 17);
            this.title.TabIndex = 0;
            this.title.Text = "Операції з категоріями";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Найменування категорії";
            // 
            // nameFiled
            // 
            this.nameFiled.Location = new System.Drawing.Point(80, 99);
            this.nameFiled.Name = "nameFiled";
            this.nameFiled.Size = new System.Drawing.Size(253, 20);
            this.nameFiled.TabIndex = 2;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(137, 158);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(113, 23);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Виконати";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // CategoriesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 226);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.nameFiled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CategoriesEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CategoriesEditor";
            this.Load += new System.EventHandler(this.CategoriesEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameFiled;
        private System.Windows.Forms.Button executeButton;
    }
}