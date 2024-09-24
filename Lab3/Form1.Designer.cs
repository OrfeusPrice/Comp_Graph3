namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonTask1 = new System.Windows.Forms.Button();
            this.ButtonTask2 = new System.Windows.Forms.Button();
            this.ButtonTask3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonTask1
            // 
            this.ButtonTask1.Location = new System.Drawing.Point(12, 12);
            this.ButtonTask1.Name = "ButtonTask1";
            this.ButtonTask1.Size = new System.Drawing.Size(250, 51);
            this.ButtonTask1.TabIndex = 0;
            this.ButtonTask1.Text = "Task1";
            this.ButtonTask1.UseVisualStyleBackColor = true;
            this.ButtonTask1.Click += new System.EventHandler(this.ButtonTask1_Click);
            // 
            // ButtonTask2
            // 
            this.ButtonTask2.Location = new System.Drawing.Point(12, 69);
            this.ButtonTask2.Name = "ButtonTask2";
            this.ButtonTask2.Size = new System.Drawing.Size(250, 51);
            this.ButtonTask2.TabIndex = 1;
            this.ButtonTask2.Text = "Task2";
            this.ButtonTask2.UseVisualStyleBackColor = true;
            this.ButtonTask2.Click += new System.EventHandler(this.ButtonTask2_Click);
            // 
            // ButtonTask3
            // 
            this.ButtonTask3.Location = new System.Drawing.Point(12, 126);
            this.ButtonTask3.Name = "ButtonTask3";
            this.ButtonTask3.Size = new System.Drawing.Size(250, 51);
            this.ButtonTask3.TabIndex = 2;
            this.ButtonTask3.Text = "Task3";
            this.ButtonTask3.UseVisualStyleBackColor = true;
            this.ButtonTask3.Click += new System.EventHandler(this.ButtonTask3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 192);
            this.Controls.Add(this.ButtonTask3);
            this.Controls.Add(this.ButtonTask2);
            this.Controls.Add(this.ButtonTask1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonTask1;
        private System.Windows.Forms.Button ButtonTask2;
        private System.Windows.Forms.Button ButtonTask3;
    }
}

