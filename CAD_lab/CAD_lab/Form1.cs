using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CAD_lab
{
    public partial class Form1 : Form
    {
        //внутренние переменные
        bool point_view = true, line_view=true, curve_view = true, surface_view = true, select_on = false;
        int point_active = 11;
        int point_size = 2;
        int rx = 0, ry = 0, rz = 0; //угол вращения
        double zoom = 1;//множитель масштабирования

        //Число шагов при расчёте кривых безье
        const int steps = 50;

        //матрицы для хранения координат точек на кривых Безье и поверхности Кунса
        Matrix<double>[] curve_points = new Matrix[4];
        Matrix<double> surf_points = DenseMatrix.OfArray(new double[(steps + 1) * (steps + 1), 4]);

        //необходимость пересчёта кривых и поверхности
        bool updated = false;

        //опорные точки, задано некоторое начальное значение
        Matrix<double> ref_points = DenseMatrix.OfArray(new double[,] { 
            { 0, 0, -20, 0 },
            { 50, -10, -100, 0 },
            { -20, 0, -200, 0 },
            { 50, 0, -300, 0 },
            { 500, 20, -500, 0 },
            { 400, 0, -600, 0 },
            { 0, -100, -800, 0 },
            { 150, 0, -900, 0 },
            { 0, 50, -1000, 0 },

            { 0, 50, -1000, 0 },
            { 600, 500, -300, 0 },
            { 500, 450, -300, 0 },
            { 500, 600, -300, 0 },
            { 550, 600, -350, 0 },
            { 550, 700, -350, 0 },
            { 580, 680, -380, 0 },
            { 620, 800, -350, 0 },
            { 0, 320, -900, 0 },

            { 0, 0, -20, 0 },
            { -20, 100, -40, 0 },
            { 50, 200, -60, 0 },
            { 0, 300, -70, 0 },
            { 80, 400, -100, 0 },
            { 0, 500, -80, 0 },
            { -10, 600, -50, 0 },
            { 30, 700, -30, 0 },
            { 0, 800, -20, 0 },

            { 0, 800, -20, 0 },
            { 120, 800, -120, 0 },
            { 100, 700, -120, 0 },
            { 100, 740, -200, 0 },
            { 200, 740, -300, 0 },
            { 250, 780, -250, 0 },
            { 0, 400, -600, 0 },
            { -100, 0, -800, 0 },
            { 0, 320, -900, 0 }
        });

        //Матрица проецирования
        Matrix<double> projection = DenseMatrix.OfArray(new double[,]
        {
            {Math.Sqrt(1.0/2),    -Math.Sqrt(1.0/6),    Math.Sqrt(1.0/3), 0},
            {0,                 Math.Sqrt(2.0/3),     Math.Sqrt(1.0/3), 0},
            {-Math.Sqrt(1.0/2),   -Math.Sqrt(1.0/6),    Math.Sqrt(1.0/3), 0},
            {0,                 0,                  0,              1}
        });

        //переключение отображения опорных точек
        private void label1_Click(object sender, EventArgs e)
        {
            point_view = !point_view;
            label1.Text = (point_view ? "Отображать опорные точки" : "Не отображать опорные точки");
        }

        //переключение отображения опорных прямых
        private void label8_Click(object sender, EventArgs e)
        {
            line_view = !line_view;
            label8.Text = (line_view ? "Отображать опорные прямые" : "Не отображать опорные прямые");
        }

        //переключение отображения кривых
        private void label2_Click(object sender, EventArgs e)
        {
            curve_view = !curve_view;
            label2.Text = (curve_view ? "Отображать кривые" : "Не отображать кривые");
        }

        //переключение отображения поверхности
        private void label3_Click(object sender, EventArgs e)
        {
            surface_view = !surface_view;
            label3.Text = (surface_view ? "Отображать поверхность" : "Не отображать поверхность");
        }

        private void coord_KeyPress(object sender, KeyPressEventArgs e)
        {
            char t = e.KeyChar;
            if ((!Char.IsDigit(t) && t != 8 && t != ',' && t != '-')) e.Handled = true;
        }

        private void focus_rem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.ActiveControl = null;
            else if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;
                point_select(6);
            }
        }

        private double[] bezier (Matrix<double> points, double t) //матрица с координатами опорных точек и значение параметра (0<=t<=1)
        {
            Matrix<double> m = DenseMatrix.OfArray(new double[points.RowCount-1, 4]); //создание новой матрицы содержащей n-1 опорных точек
            for(int i = 0; i < m.RowCount; i++) //вычисление новых опорных точек
            {
                m[i, 0] = points[i, 0] + t * (points[i + 1, 0] - points[i, 0]);
                m[i, 1] = points[i, 1] + t * (points[i + 1, 1] - points[i, 1]);
                m[i, 2] = points[i, 2] + t * (points[i + 1, 2] - points[i, 2]);
            }
            if (m.RowCount == 1) return new double[] { m[0, 0], m[0, 1], m[0, 2], 0 }; //возврат координат вычисленной точки
            else return bezier(m, t); //рекурсивный вызов функции
        }

        private double[] kuns (Matrix<double> M, double u, double v) //матрица соответствующих значению параметров точек на кривых, и угловых точек; два параметра (0<=u,v<=1)
        {
            double[] Q = new double[4];
            for(int i = 0; i < 3; i++)
            {
                Q[i] = M[2, i] * (1 - v) + M[3, i] * v + M[0, i] * (1 - u) + M[1, i] * u
                    - M[4, i] * (1 - v) * (1 - u) - M[5, i] * v * (1 - u)
                    - M[6, i] * (1 - v) * u - M[7, i] * v * u;
            }
            return Q;
        }

        private void update() //пересчёт кривых и поверхности
        {
            updated = true; //установка флага
            double t = 1.0 / steps; //шаг изменения значения параметра, steps - количество шагов изменения параметра
            for (int i = 0; i < 4; i++)
            {
                curve_points[i] = DenseMatrix.OfArray(new double[steps + 1, 4]); //инициализация пустой матрицы хранящей все координаты точек на кривой
                double[] p = new double[4];
                Matrix<double> curve_p = ref_points.SubMatrix(i * 9, 9, 0, 4); //создание матрицы хранящей все опорные точки конкретной кривой
                for (int j = 0; j <= steps; j++)
                {
                    //вычисление и запись координат одной точки кривой
                    p = bezier(curve_p, j * t);
                    curve_points[i].SetRow(j, p);
                }
            }
            //проверка возможности построения поверхности
            if ((ref_points.Row(0)[0] == ref_points.Row(18)[0])
                    && (ref_points.Row(0)[1] == ref_points.Row(18)[1])
                    && (ref_points.Row(0)[2] == ref_points.Row(18)[2])
                    && (ref_points.Row(8)[0] == ref_points.Row(9)[0])
                    && (ref_points.Row(8)[1] == ref_points.Row(9)[1])
                    && (ref_points.Row(8)[2] == ref_points.Row(9)[2])
                    && (ref_points.Row(26)[0] == ref_points.Row(27)[0])
                    && (ref_points.Row(26)[1] == ref_points.Row(27)[1])
                    && (ref_points.Row(26)[2] == ref_points.Row(27)[2])
                    && (ref_points.Row(17)[0] == ref_points.Row(35)[0])
                    && (ref_points.Row(17)[1] == ref_points.Row(35)[1])
                    && (ref_points.Row(17)[2] == ref_points.Row(35)[2]))
            {
                double[] p = new double[4];
                Matrix<double> curve_p = DenseMatrix.OfArray(new double[8, 4]); //матрица для передачи координат точек в функцию
                //4 угловые точки
                curve_p.SetRow(4, ref_points.Row(0));
                curve_p.SetRow(5, ref_points.Row(9));
                curve_p.SetRow(6, ref_points.Row(27));
                curve_p.SetRow(7, ref_points.Row(17));

                for (int i = 0; i <= steps; i++)
                {
                    for (int j = 0; j <= steps; j++)
                    {
                        curve_p.SetRow(0, curve_points[0].Row(j));
                        curve_p.SetRow(1, curve_points[3].Row(j));
                        curve_p.SetRow(2, curve_points[2].Row(i));
                        curve_p.SetRow(3, curve_points[1].Row(i));
                        //вычисление и запись координат одной точки на поверхности
                        p = kuns(curve_p, i * t, j * t);
                        surf_points.SetRow(i * (steps + 1) + j, p);
                    }
                }
            }
            else MessageBox.Show("Ошибка построения поверхности.\nКривые должны состовлять замкнутый контур.");
        }

        private void redraw() //перерисовка изображения
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            //создание матриц вращения
            Matrix<double> rotate_x = DenseMatrix.OfArray(new double[,]{
            {1, 0,              0,              0},
            {0, Math.Cos(rx / 180.0 * Math.PI),   Math.Sin(rx / 180.0 * Math.PI),   0},
            {0, -Math.Sin(rx / 180.0 * Math.PI),  Math.Cos(rx / 180.0 * Math.PI),   0},
            {0, 0,              0,              1}
            });

            Matrix<double> rotate_y = DenseMatrix.OfArray(new double[,]{
            {Math.Cos(ry / 180.0 * Math.PI),  0,  -Math.Sin(ry / 180.0 * Math.PI),  0},
            {0,             1,  0,              0},
            {Math.Sin(ry / 180.0 * Math.PI),  0,  Math.Cos(ry / 180.0 * Math.PI),   0},
            {0,             0,  0,              1}
            });

            Matrix<double> rotate_z = DenseMatrix.OfArray(new double[,]{
            {Math.Cos(rz / 180.0 * Math.PI),  Math.Sin(rz / 180.0 * Math.PI),   0,  0},
            {-Math.Sin(rz / 180.0 * Math.PI), Math.Cos(rz / 180.0 * Math.PI),   0,  0},
            {0,             0,              1,  0},
            {0,             0,              0,  1}
            });

            Matrix<double> rotate = rotate_x * rotate_y * rotate_z;

            //отрисовка опорных точек
            if (point_view)
            {
                Brush brush_point = new SolidBrush(point_col.ForeColor);
                Matrix<double> draw_points = ref_points.Multiply(zoom) * rotate * projection;
                for (int i = 0; i < 36; i++)
                {
                    if ((i % 9 == 0) || (i % 9 == 8)) g.FillEllipse(brush_point, new Rectangle((int)draw_points[i, 0] - point_size * 2, (int)draw_points[i, 1] - point_size * 2, point_size * 4, point_size * 4));
                    else g.FillEllipse(brush_point, new Rectangle((int)draw_points[i, 0] - point_size, (int)draw_points[i, 1] - point_size, point_size * 2, point_size * 2));
                }
            }

            //отрисовка опорных прямых
            if (line_view)
            {
                Pen pen_line = new Pen(line_col.ForeColor);
                Matrix<double> draw_points = ref_points.Multiply(zoom) * rotate * projection;
                for (int i = 0; i < 8; i++)
                {
                    g.DrawLine(pen_line, (int)draw_points[i, 0], (int)draw_points[i, 1], (int)draw_points[i + 1, 0], (int)draw_points[i + 1, 1]);
                }
                for (int i = 9; i < 17; i++)
                {
                    g.DrawLine(pen_line, (int)draw_points[i, 0], (int)draw_points[i, 1], (int)draw_points[i + 1, 0], (int)draw_points[i + 1, 1]);
                }
                for (int i = 18; i < 26; i++)
                {
                    g.DrawLine(pen_line, (int)draw_points[i, 0], (int)draw_points[i, 1], (int)draw_points[i + 1, 0], (int)draw_points[i + 1, 1]);
                }
                for (int i = 27; i < 35; i++)
                {
                    g.DrawLine(pen_line, (int)draw_points[i, 0], (int)draw_points[i, 1], (int)draw_points[i + 1, 0], (int)draw_points[i + 1, 1]);
                }
            }


            double t = 1.0 / steps;

            //пересчёт кривых и поверхности при необходимости
            if (!updated) update();

            //отрисовка кривых
            if (curve_view)
            {
                Pen pen_curve = new Pen(curve_col.ForeColor);
                Matrix<double> draw_points = DenseMatrix.OfArray(new double[steps + 1, 4]);

                for (int j = 0; j < 4; j++)
                {
                    draw_points = curve_points[j].Multiply(zoom) * rotate * projection;
                    for (int i = 0; i < steps; i++)
                    {
                        g.DrawLine(pen_curve, (int)draw_points[i, 0], (int)draw_points[i, 1], (int)draw_points[i + 1, 0], (int)draw_points[i + 1, 1]);
                    }
                }

            }

            //отрисовка поверхности
            if (surface_view)
            {
                if ((ref_points.Row(0)[0] == ref_points.Row(18)[0])
                    && (ref_points.Row(0)[1] == ref_points.Row(18)[1])
                    && (ref_points.Row(0)[2] == ref_points.Row(18)[2])
                    && (ref_points.Row(8)[0] == ref_points.Row(9)[0])
                    && (ref_points.Row(8)[1] == ref_points.Row(9)[1])
                    && (ref_points.Row(8)[2] == ref_points.Row(9)[2])
                    && (ref_points.Row(26)[0] == ref_points.Row(27)[0])
                    && (ref_points.Row(26)[1] == ref_points.Row(27)[1])
                    && (ref_points.Row(26)[2] == ref_points.Row(27)[2])
                    && (ref_points.Row(17)[0] == ref_points.Row(35)[0])
                    && (ref_points.Row(17)[1] == ref_points.Row(35)[1])
                    && (ref_points.Row(17)[2] == ref_points.Row(35)[2]))
                {
                    Pen pen_surf = new Pen(surf_col.ForeColor);

                    Matrix<double> draw_points = DenseMatrix.OfArray(new double[(steps + 1) * (steps + 1), 4]);
                    draw_points = surf_points.Multiply(zoom) * rotate * projection;
                    for (int i = 0; i <= steps; i++)
                        for (int j = 0; j < steps; j++)
                            g.DrawLine(pen_surf, (int)draw_points[i * (steps + 1) + j, 0], (int)draw_points[i * (steps + 1) + j, 1], (int)draw_points[i * (steps + 1) + j + 1, 0], (int)draw_points[i * (steps + 1) + j + 1, 1]);

                    for (int i = 0; i < steps; i++)
                        for (int j = 0; j <= steps; j++)
                            g.DrawLine(pen_surf, (int)draw_points[i * (steps + 1) + j, 0], (int)draw_points[i * (steps + 1) + j, 1], (int)draw_points[(i + 1) * (steps + 1) + j, 0], (int)draw_points[(i + 1) * (steps + 1) + j, 1]);

                }
            }

            Matrix<double> coord = DenseMatrix.OfArray(new double[,] { { 0, 0, 0, 0 }, { 100, 0, 0, 0 }, { 0, 100, 0, 0 }, { 0, 0, 100, 0 } });
            coord=coord.Multiply(zoom) * rotate * projection;
            g.DrawLine(Pens.Red, (int)coord[0, 0], (int)coord[0, 1], (int)coord[1, 0], (int)coord[1, 1]);
            g.DrawLine(Pens.Green, (int)coord[0, 0], (int)coord[0, 1], (int)coord[2, 0], (int)coord[2, 1]);
            g.DrawLine(Pens.Blue, (int)coord[0, 0], (int)coord[0, 1], (int)coord[3, 0], (int)coord[3, 1]);
            
            //вывод созданного изображения
            pictureBox1.Image = bmp;
        }
        private void redraw_clk(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            redraw();
        }

        private void point_label_col(int a, Color color)
        {
            switch (a)
            {
                case 11:
                    c1_p1.BackColor = color;
                    break;
                case 12:
                    c1_p2.BackColor = color;
                    break;
                case 13:
                    c1_p3.BackColor = color;
                    break;
                case 14:
                    c1_p4.BackColor = color;
                    break;
                case 15:
                    c1_p5.BackColor = color;
                    break;
                case 16:
                    c1_p6.BackColor = color;
                    break;
                case 17:
                    c1_p7.BackColor = color;
                    break;
                case 18:
                    c1_p8.BackColor = color;
                    break;
                case 19:
                    c1_p9.BackColor = color;
                    break;

                case 21:
                    c2_p1.BackColor = color;
                    break;
                case 22:
                    c2_p2.BackColor = color;
                    break;
                case 23:
                    c2_p3.BackColor = color;
                    break;
                case 24:
                    c2_p4.BackColor = color;
                    break;
                case 25:
                    c2_p5.BackColor = color;
                    break;
                case 26:
                    c2_p6.BackColor = color;
                    break;
                case 27:
                    c2_p7.BackColor = color;
                    break;
                case 28:
                    c2_p8.BackColor = color;
                    break;
                case 29:
                    c2_p9.BackColor = color;
                    break;

                case 31:
                    c3_p1.BackColor = color;
                    break;
                case 32:
                    c3_p2.BackColor = color;
                    break;
                case 33:
                    c3_p3.BackColor = color;
                    break;
                case 34:
                    c3_p4.BackColor = color;
                    break;
                case 35:
                    c3_p5.BackColor = color;
                    break;
                case 36:
                    c3_p6.BackColor = color;
                    break;
                case 37:
                    c3_p7.BackColor = color;
                    break;
                case 38:
                    c3_p8.BackColor = color;
                    break;
                case 39:
                    c3_p9.BackColor = color;
                    break;

                case 41:
                    c4_p1.BackColor = color;
                    break;
                case 42:
                    c4_p2.BackColor = color;
                    break;
                case 43:
                    c4_p3.BackColor = color;
                    break;
                case 44:
                    c4_p4.BackColor = color;
                    break;
                case 45:
                    c4_p5.BackColor = color;
                    break;
                case 46:
                    c4_p6.BackColor = color;
                    break;
                case 47:
                    c4_p7.BackColor = color;
                    break;
                case 48:
                    c4_p8.BackColor = color;
                    break;
                case 49:
                    c4_p9.BackColor = color;
                    break;
            }
        }


        //выбор точки для изменения координат
        private void point_select(int arg)
        {
            switch(arg)
            {
                case 1:
                    if (select_on)
                    {
                        select_on = false;
                        point_label_col(point_active,SystemColors.Control);
                        panel_coord.Visible = false;
                        coord_x.Text = "";
                        coord_y.Text = "";
                        coord_z.Text = "";
                    }
                    else
                    {
                        select_on = true;
                        point_label_col(point_active, SystemColors.ControlDark);
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        coord_x.Text = ref_points[p, 0].ToString();
                        coord_y.Text = ref_points[p, 1].ToString();
                        coord_z.Text = ref_points[p, 2].ToString();
                        panel_coord.Visible = true;
                    }
                    break;
                case 2:
                    if (select_on)
                    {
                        point_label_col(point_active, SystemColors.Control);
                        point_active += 10;
                        if (point_active > 50) point_active -= 40;
                        point_label_col(point_active, SystemColors.ControlDark);
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        coord_x.Text = ref_points[p, 0].ToString();
                        coord_y.Text = ref_points[p, 1].ToString();
                        coord_z.Text = ref_points[p, 2].ToString();
                    }
                    break;
                case 3:
                    if (select_on)
                    {
                        point_label_col(point_active, SystemColors.Control);
                        point_active -= 10;
                        if (point_active < 10) point_active += 40;
                        point_label_col(point_active, SystemColors.ControlDark);
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        coord_x.Text = ref_points[p, 0].ToString();
                        coord_y.Text = ref_points[p, 1].ToString();
                        coord_z.Text = ref_points[p, 2].ToString();
                    }
                    break;
                case 4:
                    if (select_on)
                    {
                        point_label_col(point_active, SystemColors.Control);
                        point_active -= 1;
                        if (point_active % 10 == 0) point_active += 9;
                        point_label_col(point_active, SystemColors.ControlDark);
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        coord_x.Text = ref_points[p, 0].ToString();
                        coord_y.Text = ref_points[p, 1].ToString();
                        coord_z.Text = ref_points[p, 2].ToString();
                    }
                    break;
                case 5:
                    if (select_on)
                    {
                        point_label_col(point_active, SystemColors.Control);
                        point_active += 1;
                        if (point_active % 10 == 0) point_active -= 9;
                        point_label_col(point_active, SystemColors.ControlDark);
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        coord_x.Text = ref_points[p, 0].ToString();
                        coord_y.Text = ref_points[p, 1].ToString();
                        coord_z.Text = ref_points[p, 2].ToString();
                    }
                    break;
                case 6:
                    if (select_on)
                    {
                        int p = (point_active % 10 - 1) + 9 * (point_active / 10 - 1);
                        ref_points[p, 0] = Convert.ToDouble(coord_x.Text);
                        ref_points[p, 1] = Convert.ToDouble(coord_y.Text);
                        ref_points[p, 2] = Convert.ToDouble(coord_z.Text);
                        updated = false;
                    }
                    break;
            }

        }

        
        //вращение
        private void rotate(char arg)
        {
            switch(arg)
            {
                case 'W':
                    rx += 1;
                    rx %= 360;
                    rot_x.Text = rx.ToString();
                    break;
                case 'S':
                    rx -= 1;
                    rx += (rx < 0 ? 360 : 0);
                    rot_x.Text = rx.ToString();
                    break;
                case 'A':
                    ry += 1;
                    ry %= 360;
                    rot_y.Text = ry.ToString();
                    break;
                case 'D':
                    ry -= 1;
                    ry += (ry < 0 ? 360 : 0);
                    rot_y.Text = ry.ToString();
                    break;
                case 'Q':
                    rz += 1;
                    rz %= 360;
                    rot_z.Text = rz.ToString();
                    break;
                case 'E':
                    rz -= 1;
                    rz += (rz < 0 ? 360 : 0);
                    rot_z.Text = rz.ToString();
                    break;
            }
            redraw();
        }

        //чтения нажатия управляющих клавиш
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Tab:
                    point_select(1);
                    break;
                case Keys.Right:
                    point_select(2);
                    break;
                case Keys.Left:
                    point_select(3);
                    break;
                case Keys.Up:
                    point_select(4);
                    break;
                case Keys.Down:
                    point_select(5);
                    break;
                case Keys.Enter:
                    point_select(6);
                    break;
                case Keys.W:
                case Keys.S:
                case Keys.A:
                case Keys.D:
                case Keys.Q:
                case Keys.E:
                    rotate(((char)e.KeyCode));
                    break;
            }

        }

        //выбор цвета для отрисовки элементов
        private void color_choice(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            ((Label)sender).ForeColor = colorDialog1.Color;
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
