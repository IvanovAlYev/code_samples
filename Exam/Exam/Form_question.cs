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
    public partial class Form_question : Form
    {
        public Form_exam.Question question;
        public int c_ans;
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
            c_ans = -1;
            
        }
        public Form_question(Form_exam.Question q)
        {
            question = q;
            InitializeComponent();
            Init();
        }

        

        private void ans_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = SystemColors.ControlDark;
        }

        private void ans_MouseLeave(object sender, EventArgs e)
        {
            if(c_ans!=Convert.ToInt32(((Label)sender).Tag))
                ((Label)sender).BackColor = SystemColors.Control;
            else
                ((Label)sender).BackColor = SystemColors.ActiveCaption;
        }

        private void ans_Click(object sender, EventArgs e)
        {
            switch (c_ans)
            {
                case 0:
                    label5.BackColor = SystemColors.Control;
                    label1.BackColor = SystemColors.Control;
                    break;
                case 1:
                    label6.BackColor = SystemColors.Control;
                    label2.BackColor = SystemColors.Control;
                    break;
                case 2:
                    label7.BackColor = SystemColors.Control;
                    label3.BackColor = SystemColors.Control;
                    break;
                case 3:
                    label8.BackColor = SystemColors.Control;
                    label4.BackColor = SystemColors.Control;
                    break;
            }
            switch (((Label)sender).Name)
            {
                case "label1":
                    label5.BackColor= SystemColors.ActiveCaption;
                    c_ans = 0;
                    break;
                case "label2":
                    label6.BackColor= SystemColors.ActiveCaption;
                    c_ans = 1;
                    break;
                case "label3":
                    label7.BackColor= SystemColors.ActiveCaption;
                    c_ans = 2;
                    break;
                case "label4":
                    label8.BackColor= SystemColors.ActiveCaption;
                    c_ans = 3;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c_ans != -1)
            {
                question.ans = c_ans;
                this.Close();
            }
        }

        private void Form_question_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 600;
            pictureBox1.Height = (pictureBox1.Width * 280) / 750;
            pictureBox1.Location = new Point(300, 12);
            label_q.Width = pictureBox1.Width;
            label_q.Location = new Point(300, 12 + pictureBox1.Height);
            label1.Width = pictureBox1.Width;
            label2.Width = pictureBox1.Width;
            label3.Width = pictureBox1.Width;
            label4.Width = pictureBox1.Width;
            label1.Location = new Point(300, label_q.Location.Y + label_q.Height);
            label2.Location = new Point(300, label1.Location.Y + label1.Height);
            label3.Location = new Point(300, label2.Location.Y + label2.Height);
            label4.Location = new Point(300, label3.Location.Y + label3.Height);
            label5.Location = label1.Location;
            label6.Location = label2.Location;
            label7.Location = label3.Location;
            label8.Location = label4.Location;
            button1.Location = new Point(label4.Location.X, label4.Location.Y + label4.Height + 10);
            button2.Location = new Point(label4.Location.X + label4.Width - button2.Width, label4.Location.Y + label4.Height + 10);
        }
    }
}
