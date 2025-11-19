using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        private bool isMouseDown = false;
        Pen pen = new Pen(Color.Black, 1);
        Bitmap map = new Bitmap(100,100);
        Graphics graphics;

        SolidBrush sbrush = new SolidBrush(Color.Black);
        HatchBrush hbrush = new HatchBrush(HatchStyle.Horizontal, Color.Black, Color.Black);

        HatchBrush tmp;
        private int brushTipe = 0;

        

        private int drowTipe = 0;

        private class TwoPoints
        {
            private Point[] points;
            private int l;

            public TwoPoints()
            {
                points = new Point[2];
            }

            public void Set(int x, int y)
            {
                if (l >= 2) l = 0;
                points[l] = new Point(x, y);
                l++;
            }

            public void Reset()
            {
                l = 0;
            }

            public int GetCount()
            {
                return l;
            }

            public Point[] GetPoints()
            {
                return points;
            }
        }

        private void SetSize()
        {
            Rectangle rectangle = pictureBox1.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            graphics.Clear(Color.White);
        }

        private TwoPoints coords = new TwoPoints();



        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if ((drowTipe == 2) || (drowTipe == 3)) coords.Set(e.X, e.Y);
            if (drowTipe == 1)
            {
                graphics.FillRectangle(Brushes.White, e.X - pen.Width, e.Y - pen.Width, pen.Width * 2, pen.Width * 2);
                pictureBox1.Image = map;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if ((drowTipe == 2) || (drowTipe == 3))
            {
                int x, y, dx, dy;
                x = (coords.GetPoints()[0].X < e.X ? coords.GetPoints()[0].X : e.X);
                y = (coords.GetPoints()[0].Y < e.Y ? coords.GetPoints()[0].Y : e.Y);
                dx = (coords.GetPoints()[0].X > e.X ? coords.GetPoints()[0].X : e.X) - x;
                dy = (coords.GetPoints()[0].Y > e.Y ? coords.GetPoints()[0].Y : e.Y) - y;
                if (drowTipe == 2)
                {
                   
                    if (brushTipe == 0) graphics.FillRectangle(sbrush, x, y, dx, dy);
                    else graphics.FillRectangle(hbrush, x, y, dx, dy);
                    graphics.DrawRectangle(pen, x, y, dx, dy);
                }
                else
                {
                   
                    if (brushTipe == 0) graphics.FillEllipse(sbrush, x, y, dx, dy);
                    else graphics.FillEllipse(hbrush, x, y, dx, dy);
                    graphics.DrawEllipse(pen, x, y, dx, dy);

                }
                pictureBox1.Image = map;
            }
            coords.Reset();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown) return;
            if (drowTipe == 0) {
                coords.Set(e.X, e.Y);
                if (coords.GetCount() == 2)
                {
                    graphics.DrawLine(pen, coords.GetPoints()[0], coords.GetPoints()[1]);
                    pictureBox1.Image = map;
                    coords.Set(e.X, e.Y);
                }
            }

            if (drowTipe == 1)
            {
                graphics.FillRectangle(Brushes.White, e.X - pen.Width, e.Y - pen.Width, pen.Width * 2, pen.Width * 2);
                pictureBox1.Image = map;
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch (drowTipe)
            {
                case 0:
                    DT_0.BackColor = Color.White;
                    break;
                case 1:
                    DT_1.BackColor = Color.White;
                    break;
                case 2:
                    DT_2.BackColor = Color.White;
                    break;
                case 3:
                    DT_3.BackColor = Color.White;
                    break;
            }
            switch (((Button)sender).Name)
            {
                case "DT_0":
                    drowTipe = 0;
                    break;
                case "DT_1":
                    drowTipe = 1;
                    break;
                case "DT_2":
                    drowTipe = 2;
                    break;
                case "DT_3":
                    drowTipe = 3;
                    break;
            }
            ((Button)sender).BackColor = Color.Red;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;   
        }

        private void button16_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "BMP(*.BMP)|*.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (brushTipe)
            {
                case 0:
                    BT_0.BackColor = Color.White;
                    break;
                case 1:
                    BT_1.BackColor = Color.White;
                    break;
                case 2:
                    BT_2.BackColor = Color.White;
                    break;
                case 3:
                    BT_3.BackColor = Color.White;
                    break;
                case 4:
                    BT_4.BackColor = Color.White;
                    break;
                case 5:
                    BT_5.BackColor = Color.White;
                    break;
                case 6:
                    BT_6.BackColor = Color.White;
                    break;
            }
            switch (((Button)sender).Name)
            {
                case "BT_0":
                    brushTipe = 0;
                    break;
                case "BT_1":
                    brushTipe = 1;
                    tmp = new HatchBrush(HatchStyle.Vertical, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
                case "BT_2":
                    brushTipe = 2;
                    tmp = new HatchBrush(HatchStyle.Horizontal, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
                case "BT_3":
                    brushTipe = 3;
                    tmp = new HatchBrush(HatchStyle.Cross, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
                case "BT_4":
                    brushTipe = 4;
                    tmp = new HatchBrush(HatchStyle.ForwardDiagonal, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
                case "BT_5":
                    brushTipe = 5;
                    tmp = new HatchBrush(HatchStyle.BackwardDiagonal, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
                case "BT_6":
                    brushTipe = 6;
                    tmp = new HatchBrush(HatchStyle.DiagonalCross, hbrush.BackgroundColor, hbrush.ForegroundColor);
                    hbrush.Dispose();
                    hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                    tmp.Dispose();
                    break;
            }
            ((Button)sender).BackColor = Color.Red;
        }

        private void Color1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                sbrush.Color = colorDialog1.Color;
                tmp = new HatchBrush(hbrush.HatchStyle, colorDialog1.Color, hbrush.ForegroundColor);
                hbrush.Dispose();
                hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                tmp.Dispose();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void Color2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                tmp = new HatchBrush(hbrush.HatchStyle, hbrush.BackgroundColor, colorDialog1.Color);
                hbrush.Dispose();
                hbrush = new HatchBrush(tmp.HatchStyle, tmp.BackgroundColor, tmp.ForegroundColor);
                tmp.Dispose();
                ((Button)sender).BackColor = colorDialog1.Color;
            }
            
        }
    }
}
