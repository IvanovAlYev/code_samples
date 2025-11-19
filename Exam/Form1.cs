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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form_exam f_exam;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_f.Text != "" && textBox_i.Text != "" && textBox_o.Text != "")
            {
                this.Hide();
                f_exam = new Form_exam(textBox_f.Text, textBox_i.Text, textBox_o.Text, dateTimePicker1.Value.Date);
                f_exam.Show();
            }
            else
            {
                MessageBox.Show("Вы не ввели ФИО");
            }
        }
    }
}
