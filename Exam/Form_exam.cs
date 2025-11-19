using Exam.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam
{
    public partial class Form_exam : Form
    {
        private string fam, name, otch;
        private int day, month, year;
        private int c_que = 0, answ_c = 0;
        private DateTime dateTime;

        private Random rand;

        private struct Q_list
        {
            public int n1, n2, n3, n4;
            public string[] list1, list2, list3, list4;
        }


        private Q_list Q_list_read()
        {
            Q_list q_list = new Q_list();
            
            StreamReader sr = new StreamReader(".\\resource\\t1_list.txt");
            q_list.n1= Convert.ToInt32(sr.ReadLine());
            q_list.list1 = new string[q_list.n1];
            for(int i = 0; i < q_list.n1; i++)
            {
                q_list.list1[i] = sr.ReadLine();
            }
            sr.Close();

            sr = new StreamReader(".\\resource\\t2_list.txt");
            q_list.n2 = Convert.ToInt32(sr.ReadLine());
            q_list.list2 = new string[q_list.n2];
            for (int i = 0; i < q_list.n2; i++)
            {
                q_list.list2[i] = sr.ReadLine();
            }
            sr.Close();

            sr = new StreamReader(".\\resource\\t3_list.txt");
            q_list.n3 = Convert.ToInt32(sr.ReadLine());
            q_list.list3 = new string[q_list.n3];
            for (int i = 0; i < q_list.n3; i++)
            {
                q_list.list3[i] = sr.ReadLine();
            }
            sr.Close();

            sr = new StreamReader(".\\resource\\t4_list.txt");
            q_list.n4 = Convert.ToInt32(sr.ReadLine());
            q_list.list4 = new string[q_list.n4];
            for (int i = 0; i < q_list.n4; i++)
            {
                q_list.list4[i] = sr.ReadLine();
            }
            sr.Close();

            return q_list;
        }

        private Q_list q_List;
        public struct Question
        {
            public string im_path;
            public int ans_c, ans_r;
            public string[] answers;
            public string comment;
            public int ans;
            public string que;
            public string b_q;
        }

        private Question add_question(int tem)
        {
            string str = "";
            int r;
            switch (tem)
            {
                case 0:
                    r = rand.Next(0, q_List.n1);
                    str = q_List.list1[r];
                    q_List.list1[r] = q_List.list1[q_List.n1 - 1];
                    q_List.n1--;
                    break;
                case 1:
                    r = rand.Next(0, q_List.n2);
                    str = q_List.list2[r];
                    q_List.list2[r] = q_List.list2[q_List.n2 - 1];
                    q_List.n2--;
                    break;
                case 2:
                    r = rand.Next(0, q_List.n3);
                    str = q_List.list3[r];
                    q_List.list3[r] = q_List.list3[q_List.n3 - 1];
                    q_List.n3--;
                    break;
                case 3:
                    r = rand.Next(0, q_List.n4);
                    str = q_List.list4[r];
                    q_List.list4[r] = q_List.list4[q_List.n4 - 1];
                    q_List.n4--;
                    break;
            }
            Question q = new Question();
            q.im_path = ".\\resource\\"+str+".jpg";
            StreamReader sr= new StreamReader(".\\resource\\" + str + ".txt");
            q.ans_c = Convert.ToInt32(sr.ReadLine());
            q.ans_r = Convert.ToInt32(sr.ReadLine())-1;
            q.que= sr.ReadLine();
            q.answers= new string[q.ans_c];
            for (int i = 0; i < q.ans_c; i++)
            {
                q.answers[i] = sr.ReadLine();
            }
            q.comment = sr.ReadLine();
            q.b_q= sr.ReadLine();
            q.b_q += "\n";
            q.b_q += sr.ReadLine();
            q.ans = -1;
            return q;
        }

        public struct Exam
        {
            public Question[,] question;

        }

        private Exam gen_exam()
        {
            Exam exam = new Exam();

            exam.question = new Question[3, 20];
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j<20; j++)
                {
                    exam.question[i,j]=add_question(j/5);
                }
            }          



            return exam;
        }

        public Exam exam;

        private int ask_q(int b,int q)
        {
            Form_question que = new Form_question(exam.question[b,q]);
            this.Hide();
            que.ShowDialog();
            this.Show();
            exam.question[b, q].ans = que.question.ans;
            return que.question.ans;
        }

        private void next_b()
        {
            if (c_que == 2)
            {
                /*Form_res form_Res = new Form_res(exam,fam,name,otch,day,month,year,dateTime);
                this.Hide();
                form_Res.ShowDialog();*/
                this.Close();
            }
            else
            {
                c_que++;
                answ_c = 0;
                {
                    pictureBox1_1.ImageLocation = exam.question[c_que, 0].im_path;
                    pictureBox1_1.Cursor = Cursors.Hand;
                    pictureBox1_2.ImageLocation = exam.question[c_que, 1].im_path;
                    pictureBox1_2.Cursor = Cursors.Hand;
                    pictureBox1_3.ImageLocation = exam.question[c_que, 2].im_path;
                    pictureBox1_3.Cursor = Cursors.Hand;
                    pictureBox1_4.ImageLocation = exam.question[c_que, 3].im_path;
                    pictureBox1_4.Cursor = Cursors.Hand;
                    pictureBox1_5.ImageLocation = exam.question[c_que, 4].im_path;
                    pictureBox1_5.Cursor = Cursors.Hand;

                    pictureBox2_1.ImageLocation = exam.question[c_que, 5].im_path;
                    pictureBox2_1.Cursor = Cursors.Hand;
                    pictureBox2_2.ImageLocation = exam.question[c_que, 6].im_path;
                    pictureBox2_2.Cursor = Cursors.Hand;
                    pictureBox2_3.ImageLocation = exam.question[c_que, 7].im_path;
                    pictureBox2_3.Cursor = Cursors.Hand;
                    pictureBox2_4.ImageLocation = exam.question[c_que, 8].im_path;
                    pictureBox2_4.Cursor = Cursors.Hand;
                    pictureBox2_5.ImageLocation = exam.question[c_que, 9].im_path;
                    pictureBox2_5.Cursor = Cursors.Hand;

                    pictureBox3_1.ImageLocation = exam.question[c_que, 10].im_path;
                    pictureBox3_1.Cursor = Cursors.Hand;
                    pictureBox3_2.ImageLocation = exam.question[c_que, 11].im_path;
                    pictureBox3_2.Cursor = Cursors.Hand;
                    pictureBox3_3.ImageLocation = exam.question[c_que, 12].im_path;
                    pictureBox3_3.Cursor = Cursors.Hand;
                    pictureBox3_4.ImageLocation = exam.question[c_que, 13].im_path;
                    pictureBox3_4.Cursor = Cursors.Hand;
                    pictureBox3_5.ImageLocation = exam.question[c_que, 14].im_path;
                    pictureBox3_5.Cursor = Cursors.Hand;

                    pictureBox4_1.ImageLocation = exam.question[c_que, 15].im_path;
                    pictureBox4_1.Cursor = Cursors.Hand;
                    pictureBox4_2.ImageLocation = exam.question[c_que, 16].im_path;
                    pictureBox4_2.Cursor = Cursors.Hand;
                    pictureBox4_3.ImageLocation = exam.question[c_que, 17].im_path;
                    pictureBox4_3.Cursor = Cursors.Hand;
                    pictureBox4_4.ImageLocation = exam.question[c_que, 18].im_path;
                    pictureBox4_4.Cursor = Cursors.Hand;
                    pictureBox4_5.ImageLocation = exam.question[c_que, 19].im_path;
                    pictureBox4_5.Cursor = Cursors.Hand;
                }
            }
        }
        private void question_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Image != null)
            {
                int q_num = Convert.ToInt32(((PictureBox)sender).Tag);
                int ans_g = ask_q(c_que, q_num);
                if (ans_g != -1)
                {
                    ((PictureBox)sender).ImageLocation = "";
                    ((PictureBox)sender).Cursor = Cursors.Default;
                    answ_c++;
                }
                if (answ_c == 20)
                {
                    next_b();
                }
            }
        }

        public Form_exam()
        {
            InitializeComponent();
            
        }

        private void Form_exam_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_res form_Res = new Form_res(exam, fam, name, otch, day, month, year, dateTime);
            this.Hide();
            form_Res.ShowDialog();
            
            Application.Exit();
        }
                
        private void Form_exam_Resize(object sender, EventArgs e)
        {
            int w = this.Width;
            int h = panel1.Height;

            panel1.Width = w / 4;
            panel2.Width = w / 4;
            panel3.Width = w / 4;
            panel4.Width = w / 4;

            pictureBox1_1.Height = h / 5;
            pictureBox1_2.Height = h / 5;
            pictureBox1_3.Height = h / 5;
            pictureBox1_4.Height = h / 5;
            pictureBox1_5.Height = h / 5;
            pictureBox2_1.Height = h / 5;
            pictureBox2_2.Height = h / 5;
            pictureBox2_3.Height = h / 5;
            pictureBox2_4.Height = h / 5;
            pictureBox2_5.Height = h / 5;
            pictureBox3_1.Height = h / 5;
            pictureBox3_2.Height = h / 5;
            pictureBox3_3.Height = h / 5;
            pictureBox3_4.Height = h / 5;
            pictureBox3_5.Height = h / 5;
            pictureBox4_1.Height = h / 5;
            pictureBox4_2.Height = h / 5;
            pictureBox4_3.Height = h / 5;
            pictureBox4_4.Height = h / 5;
            pictureBox4_5.Height = h / 5;
        }

        public Form_exam(string f,string n,string o, DateTime d)
        {
            q_List = Q_list_read();
            rand = new Random();
            fam = f;
            name=n;
            otch = o;
            day = d.Day;
            month = d.Month;
            year = d.Year;
            exam = gen_exam();
            
            InitializeComponent();
            {
                int w = this.Width;
                int h = panel1.Height;

                panel1.Width = w / 4;
                panel2.Width = w / 4;
                panel3.Width = w / 4;
                panel4.Width = w / 4;

                pictureBox1_1.Height = h / 5;
                pictureBox1_2.Height = h / 5;
                pictureBox1_3.Height = h / 5;
                pictureBox1_4.Height = h / 5;
                pictureBox1_5.Height = h / 5;
                pictureBox2_1.Height = h / 5;
                pictureBox2_2.Height = h / 5;
                pictureBox2_3.Height = h / 5;
                pictureBox2_4.Height = h / 5;
                pictureBox2_5.Height = h / 5;
                pictureBox3_1.Height = h / 5;
                pictureBox3_2.Height = h / 5;
                pictureBox3_3.Height = h / 5;
                pictureBox3_4.Height = h / 5;
                pictureBox3_5.Height = h / 5;
                pictureBox4_1.Height = h / 5;
                pictureBox4_2.Height = h / 5;
                pictureBox4_3.Height = h / 5;
                pictureBox4_4.Height = h / 5;
                pictureBox4_5.Height = h / 5;
            }

            {
                pictureBox1_1.ImageLocation = exam.question[0, 0].im_path;
                pictureBox1_2.ImageLocation = exam.question[0, 1].im_path;
                pictureBox1_3.ImageLocation = exam.question[0, 2].im_path;
                pictureBox1_4.ImageLocation = exam.question[0, 3].im_path;
                pictureBox1_5.ImageLocation = exam.question[0, 4].im_path;

                pictureBox2_1.ImageLocation = exam.question[0, 5].im_path;
                pictureBox2_2.ImageLocation = exam.question[0, 6].im_path;
                pictureBox2_3.ImageLocation = exam.question[0, 7].im_path;
                pictureBox2_4.ImageLocation = exam.question[0, 8].im_path;
                pictureBox2_5.ImageLocation = exam.question[0, 9].im_path;

                pictureBox3_1.ImageLocation = exam.question[0, 10].im_path;
                pictureBox3_2.ImageLocation = exam.question[0, 11].im_path;
                pictureBox3_3.ImageLocation = exam.question[0, 12].im_path;
                pictureBox3_4.ImageLocation = exam.question[0, 13].im_path;
                pictureBox3_5.ImageLocation = exam.question[0, 14].im_path;

                pictureBox4_1.ImageLocation = exam.question[0, 15].im_path;
                pictureBox4_2.ImageLocation = exam.question[0, 16].im_path;
                pictureBox4_3.ImageLocation = exam.question[0, 17].im_path;
                pictureBox4_4.ImageLocation = exam.question[0, 18].im_path;
                pictureBox4_5.ImageLocation = exam.question[0, 19].im_path;
            }


            dateTime = DateTime.Now;

        }

    }
}
