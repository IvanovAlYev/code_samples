namespace Exam
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_f = new System.Windows.Forms.TextBox();
            this.textBox_i = new System.Windows.Forms.TextBox();
            this.textBox_o = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 261);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(325, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "Экзамен";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите ФИО и дату рождения";
            // 
            // textBox_f
            // 
            this.textBox_f.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_f.Location = new System.Drawing.Point(44, 51);
            this.textBox_f.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox_f.Name = "textBox_f";
            this.textBox_f.Size = new System.Drawing.Size(322, 38);
            this.textBox_f.TabIndex = 2;
            this.textBox_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_i
            // 
            this.textBox_i.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_i.Location = new System.Drawing.Point(44, 101);
            this.textBox_i.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox_i.Name = "textBox_i";
            this.textBox_i.Size = new System.Drawing.Size(322, 38);
            this.textBox_i.TabIndex = 3;
            this.textBox_i.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_o
            // 
            this.textBox_o.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_o.Location = new System.Drawing.Point(44, 151);
            this.textBox_o.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox_o.Name = "textBox_o";
            this.textBox_o.Size = new System.Drawing.Size(322, 38);
            this.textBox_o.TabIndex = 4;
            this.textBox_o.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 201);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(322, 38);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 360);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox_o);
            this.Controls.Add(this.textBox_i);
            this.Controls.Add(this.textBox_f);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Arial Narrow", 16.2F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные ученика";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_f;
        private System.Windows.Forms.TextBox textBox_i;
        private System.Windows.Forms.TextBox textBox_o;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

