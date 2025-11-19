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
    public partial class Form_res : Form
    {

        private string fam, name, otch;
        private int day, month, year;
        private DateTime dateTimeStart, dateTimeEnd;

        private void label_Click(object sender, EventArgs e)
        {
            if (((Label)sender).Cursor == Cursors.Hand)
            {
                int tag = Convert.ToInt32(((Label)sender).Tag);
                Form_exam.Question question = exam.question[(tag % 10) / 3, tag / 10];
                Form_m form = new Form_m(question);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        Form_exam.Exam exam;
        public Form_res(Form_exam.Exam exam, string f, string i, string o, int d, int m, int y,DateTime dt)
        {
            this.fam = f;
            this.name = i;
            this.otch = o;
            this.day = d;
            this.month = m;
            this.year = y;
            this.exam = exam;
            InitializeComponent();
            label_f2.Text = f;
            label_i2.Text = i;
            label_o2.Text = o;
            label_d2.Text=day.ToString()+"."+month.ToString()+"."+year.ToString();
            dateTimeStart = dt;
            dateTimeEnd = DateTime.Now;
            label_dt1.Text += dateTimeStart.Day + "." + dateTimeStart.Month + "." + dateTimeStart.Year;
            label_dt2.Text += (dateTimeEnd - dateTimeStart).Minutes + " мин " + (dateTimeEnd - dateTimeStart).Seconds + " сек";
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            test.Text = ((Label)sender).Width.ToString();
        }


        private void label_Layout(object sender, LayoutEventArgs e)
        {
            ((Label)sender).Width = label2.Width;
            int tag =Convert.ToInt32(((Label)sender).Tag);
            Form_exam.Question question = exam.question[(tag % 10) / 3, tag / 10];
            switch ((tag%10)%3)
            {
                case 0:
                    ((Label)sender).Text = question.b_q;
                    break;
                case 1:
                    ((Label)sender).Text = (question.ans+1).ToString();
                    if (question.ans == question.ans_r)
                        ((Label)sender).BackColor = Color.Green;
                    else
                    {
                        ((Label)sender).BackColor= Color.Red;
                        ((Label)sender).Cursor = Cursors.Hand;
                    }
                    break;
                case 2:
                    if (question.ans != question.ans_r)
                        ((Label)sender).Text = (question.ans_r+1).ToString();
                    else
                        ((Label)sender).Text = " ";
                    break;
            }
        }
    }
}
