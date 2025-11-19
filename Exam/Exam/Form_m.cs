using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam
{
    public partial class Form_m : Form
    {
        public Form_exam.Question question;

        private void Init()
        {
            pictureBox1.ImageLocation = question.im_path;
            label1.Text = question.answers[0];
            label1.Visible = true;
            label2.Text = question.answers[1];
            label2.Visible = true;
            label3.Text = question.answers[2];
            label3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label_q.Text = question.que;
            if (question.ans_c == 4)
            {
                label4.Text = question.answers[3];
                label4.Visible = true;
                label8.Visible = true;
            }
            label9.Text = question.comment;
            switch (question.ans_r)
            {
                case 0:
                    label1.BackColor = Color.Green;
                    break;
                case 1:
                    label2.BackColor = Color.Green;
                    break;
                case 2:
                    label3.BackColor = Color.Green;
                    break;
                case 3:
                    label4.BackColor = Color.Green;
                    break;
            }
            switch (question.ans)
            {
                case 0:
                    label1.BackColor = Color.Red;
                    break;
                case 1:
                    label2.BackColor = Color.Red;
                    break;
                case 2:
                    label3.BackColor = Color.Red;
                    break;
                case 3:
                    label4.BackColor = Color.Red;
                    break;
            }
        }
        public Form_m(Form_exam.Question q)
        {
            question= q;
            InitializeComponent();
            Init();
        }

        private void Form_m_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 600;
            pictureBox1.Height = (pictureBox1.Width * 280) / 750;
            pictureBox1.Location = new Point(300, 12);
            label_q.Width = pictureBox1.Width;
            label_q.Location = new Point(300, 12 + pictureBox1.Height);
            label9.Width = pictureBox1.Width;
            label1.Width = pictureBox1.Width;
            label2.Width = pictureBox1.Width;
            label3.Width = pictureBox1.Width;
            label4.Width = pictureBox1.Width;
            label9.Location = new Point(300, label_q.Location.Y + label_q.Height);
            label1.Location = new Point(300, label9.Location.Y + label9.Height);
            label2.Location = new Point(300, label1.Location.Y + label1.Height);
            label3.Location = new Point(300, label2.Location.Y + label2.Height);
            label4.Location = new Point(300, label3.Location.Y + label3.Height);
            label5.Location = label1.Location;
            label6.Location = label2.Location;
            label7.Location = label3.Location;
            label8.Location = label4.Location;
            button2.Location = new Point(label4.Location.X, label4.Location.Y + label4.Height + 10);
            button2.Width = pictureBox1.Width;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
