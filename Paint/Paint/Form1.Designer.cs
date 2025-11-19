namespace Paint
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DT_3 = new System.Windows.Forms.Button();
            this.DT_2 = new System.Windows.Forms.Button();
            this.DT_1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DT_0 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Color2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_6 = new System.Windows.Forms.Button();
            this.BT_5 = new System.Windows.Forms.Button();
            this.BT_4 = new System.Windows.Forms.Button();
            this.BT_3 = new System.Windows.Forms.Button();
            this.BT_2 = new System.Windows.Forms.Button();
            this.BT_1 = new System.Windows.Forms.Button();
            this.BT_0 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.Color1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 673);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1000, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 673);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button16);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 516);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 157);
            this.panel4.TabIndex = 4;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(53, 6);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(182, 38);
            this.button16.TabIndex = 0;
            this.button16.Text = "Сохранить как...";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DT_3);
            this.panel3.Controls.Add(this.DT_2);
            this.panel3.Controls.Add(this.DT_1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.DT_0);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 363);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 153);
            this.panel3.TabIndex = 3;
            // 
            // DT_3
            // 
            this.DT_3.BackColor = System.Drawing.Color.White;
            this.DT_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DT_3.Location = new System.Drawing.Point(131, 75);
            this.DT_3.Name = "DT_3";
            this.DT_3.Size = new System.Drawing.Size(128, 30);
            this.DT_3.TabIndex = 16;
            this.DT_3.Text = "Эллипс";
            this.DT_3.UseVisualStyleBackColor = false;
            this.DT_3.Click += new System.EventHandler(this.button15_Click);
            // 
            // DT_2
            // 
            this.DT_2.BackColor = System.Drawing.Color.White;
            this.DT_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DT_2.Location = new System.Drawing.Point(-3, 75);
            this.DT_2.Name = "DT_2";
            this.DT_2.Size = new System.Drawing.Size(128, 30);
            this.DT_2.TabIndex = 15;
            this.DT_2.Text = "Прямоугольник";
            this.DT_2.UseVisualStyleBackColor = false;
            this.DT_2.Click += new System.EventHandler(this.button15_Click);
            // 
            // DT_1
            // 
            this.DT_1.BackColor = System.Drawing.Color.White;
            this.DT_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DT_1.Location = new System.Drawing.Point(131, 39);
            this.DT_1.Name = "DT_1";
            this.DT_1.Size = new System.Drawing.Size(128, 30);
            this.DT_1.TabIndex = 14;
            this.DT_1.Text = "Ластик";
            this.DT_1.UseVisualStyleBackColor = false;
            this.DT_1.Click += new System.EventHandler(this.button15_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-1, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Инструмент:";
            // 
            // DT_0
            // 
            this.DT_0.BackColor = System.Drawing.Color.Red;
            this.DT_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DT_0.Location = new System.Drawing.Point(-3, 39);
            this.DT_0.Name = "DT_0";
            this.DT_0.Size = new System.Drawing.Size(128, 30);
            this.DT_0.TabIndex = 0;
            this.DT_0.Text = "Карандаш";
            this.DT_0.UseVisualStyleBackColor = false;
            this.DT_0.Click += new System.EventHandler(this.button15_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Color2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BT_6);
            this.panel2.Controls.Add(this.BT_5);
            this.panel2.Controls.Add(this.BT_4);
            this.panel2.Controls.Add(this.BT_3);
            this.panel2.Controls.Add(this.BT_2);
            this.panel2.Controls.Add(this.BT_1);
            this.panel2.Controls.Add(this.BT_0);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Color1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 363);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(23, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Доп. цвет кисти";
            // 
            // Color2
            // 
            this.Color2.BackColor = System.Drawing.Color.Black;
            this.Color2.Location = new System.Drawing.Point(181, 78);
            this.Color2.Name = "Color2";
            this.Color2.Size = new System.Drawing.Size(30, 30);
            this.Color2.TabIndex = 15;
            this.Color2.UseVisualStyleBackColor = false;
            this.Color2.Click += new System.EventHandler(this.Color2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Осн. цвет кисти";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Цвет карандаша";
            // 
            // BT_6
            // 
            this.BT_6.BackColor = System.Drawing.Color.White;
            this.BT_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_6.Location = new System.Drawing.Point(131, 287);
            this.BT_6.Name = "BT_6";
            this.BT_6.Size = new System.Drawing.Size(101, 63);
            this.BT_6.TabIndex = 12;
            this.BT_6.Text = "Оба \r\nштрих.";
            this.BT_6.UseVisualStyleBackColor = false;
            this.BT_6.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_5
            // 
            this.BT_5.BackColor = System.Drawing.Color.White;
            this.BT_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_5.Location = new System.Drawing.Point(68, 287);
            this.BT_5.Name = "BT_5";
            this.BT_5.Size = new System.Drawing.Size(57, 63);
            this.BT_5.TabIndex = 11;
            this.BT_5.Text = "Втор. диаг. \r\nштрих.";
            this.BT_5.UseVisualStyleBackColor = false;
            this.BT_5.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_4
            // 
            this.BT_4.BackColor = System.Drawing.Color.White;
            this.BT_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_4.Location = new System.Drawing.Point(0, 287);
            this.BT_4.Name = "BT_4";
            this.BT_4.Size = new System.Drawing.Size(62, 63);
            this.BT_4.TabIndex = 10;
            this.BT_4.Text = "Гл. диаг. \r\nштрих.";
            this.BT_4.UseVisualStyleBackColor = false;
            this.BT_4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_3
            // 
            this.BT_3.BackColor = System.Drawing.Color.White;
            this.BT_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_3.Location = new System.Drawing.Point(131, 237);
            this.BT_3.Name = "BT_3";
            this.BT_3.Size = new System.Drawing.Size(101, 44);
            this.BT_3.TabIndex = 9;
            this.BT_3.Text = "Оба \r\nштрих.";
            this.BT_3.UseVisualStyleBackColor = false;
            this.BT_3.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_2
            // 
            this.BT_2.BackColor = System.Drawing.Color.White;
            this.BT_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_2.Location = new System.Drawing.Point(68, 237);
            this.BT_2.Name = "BT_2";
            this.BT_2.Size = new System.Drawing.Size(57, 44);
            this.BT_2.TabIndex = 8;
            this.BT_2.Text = "Гор. \r\nштрих.";
            this.BT_2.UseVisualStyleBackColor = false;
            this.BT_2.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_1
            // 
            this.BT_1.BackColor = System.Drawing.Color.White;
            this.BT_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_1.Location = new System.Drawing.Point(0, 237);
            this.BT_1.Name = "BT_1";
            this.BT_1.Size = new System.Drawing.Size(62, 44);
            this.BT_1.TabIndex = 7;
            this.BT_1.Text = "Верт. \r\nштрих.";
            this.BT_1.UseVisualStyleBackColor = false;
            this.BT_1.Click += new System.EventHandler(this.button4_Click);
            // 
            // BT_0
            // 
            this.BT_0.BackColor = System.Drawing.Color.Red;
            this.BT_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_0.Location = new System.Drawing.Point(0, 203);
            this.BT_0.Name = "BT_0";
            this.BT_0.Size = new System.Drawing.Size(232, 28);
            this.BT_0.TabIndex = 6;
            this.BT_0.Text = "Сплошная";
            this.BT_0.UseVisualStyleBackColor = false;
            this.BT_0.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Стиль кисти:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Толщина линий";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(-3, 128);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(262, 56);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(181, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Color1
            // 
            this.Color1.BackColor = System.Drawing.Color.Black;
            this.Color1.Location = new System.Drawing.Point(181, 42);
            this.Color1.Name = "Color1";
            this.Color1.Size = new System.Drawing.Size(30, 30);
            this.Color1.TabIndex = 1;
            this.Color1.UseVisualStyleBackColor = false;
            this.Color1.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = "ЛР3 по графическому программированию";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Color1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_2;
        private System.Windows.Forms.Button BT_1;
        private System.Windows.Forms.Button BT_0;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button DT_3;
        private System.Windows.Forms.Button DT_2;
        private System.Windows.Forms.Button DT_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DT_0;
        private System.Windows.Forms.Button BT_6;
        private System.Windows.Forms.Button BT_5;
        private System.Windows.Forms.Button BT_4;
        private System.Windows.Forms.Button BT_3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Color2;
    }
}

