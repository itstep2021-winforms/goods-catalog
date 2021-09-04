namespace GoodsCatalog
{
    partial class ProducersEditor
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
            this.createProducerButton = new System.Windows.Forms.Label();
            this.updateProducerButton = new System.Windows.Forms.Label();
            this.DeleteProducerButton = new System.Windows.Forms.Label();
            this.listProducer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameProducer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createProducerButton
            // 
            this.createProducerButton.AutoSize = true;
            this.createProducerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createProducerButton.ForeColor = System.Drawing.Color.Maroon;
            this.createProducerButton.Location = new System.Drawing.Point(4, 100);
            this.createProducerButton.Name = "createProducerButton";
            this.createProducerButton.Size = new System.Drawing.Size(75, 20);
            this.createProducerButton.TabIndex = 0;
            this.createProducerButton.Text = "Создать";
            // 
            // updateProducerButton
            // 
            this.updateProducerButton.AutoSize = true;
            this.updateProducerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateProducerButton.ForeColor = System.Drawing.Color.Maroon;
            this.updateProducerButton.Location = new System.Drawing.Point(85, 100);
            this.updateProducerButton.Name = "updateProducerButton";
            this.updateProducerButton.Size = new System.Drawing.Size(84, 20);
            this.updateProducerButton.TabIndex = 1;
            this.updateProducerButton.Text = "Обновить";
            // 
            // DeleteProducerButton
            // 
            this.DeleteProducerButton.AutoSize = true;
            this.DeleteProducerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteProducerButton.ForeColor = System.Drawing.Color.Maroon;
            this.DeleteProducerButton.Location = new System.Drawing.Point(183, 100);
            this.DeleteProducerButton.Name = "DeleteProducerButton";
            this.DeleteProducerButton.Size = new System.Drawing.Size(76, 20);
            this.DeleteProducerButton.TabIndex = 2;
            this.DeleteProducerButton.Text = "Удалить";
            // 
            // listProducer
            // 
            this.listProducer.FormattingEnabled = true;
            this.listProducer.Location = new System.Drawing.Point(8, 45);
            this.listProducer.Name = "listProducer";
            this.listProducer.Size = new System.Drawing.Size(251, 21);
            this.listProducer.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Производитель:";
            // 
            // nameProducer
            // 
            this.nameProducer.Location = new System.Drawing.Point(8, 73);
            this.nameProducer.Name = "nameProducer";
            this.nameProducer.Size = new System.Drawing.Size(251, 20);
            this.nameProducer.TabIndex = 6;
            // 
            // ProducersEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 170);
            this.Controls.Add(this.nameProducer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listProducer);
            this.Controls.Add(this.DeleteProducerButton);
            this.Controls.Add(this.updateProducerButton);
            this.Controls.Add(this.createProducerButton);
            this.Name = "ProducersEditor";
            this.Text = "ProducersEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createProducerButton;
        private System.Windows.Forms.Label updateProducerButton;
        private System.Windows.Forms.Label DeleteProducerButton;
        private System.Windows.Forms.ComboBox listProducer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameProducer;
    }
}