using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        private float k = 40;
        private int d_x = 0;
        private int d_y = 0;
        private int tmp_dx = 0;
        private int tmp_dy = 0;
        private Point mouse_down_loc;
        private Point mouse_down_loc1;
        private bool is_down = false;
        private double scale = 1;
        private List<int> p;
        private Pen pen_1;
        private HatchBrush hBrush;
        private Brush LinearGradientBrush;
        private int flag = 0;
        private bool ball = false;
        private float d_start_x;
        public Form1()
        {
            InitializeComponent();
            p = new List<int>();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Draw_Space = e.Graphics;
            if (Draw_Space != null) Draw_Space.Clear(panel1.BackColor);
            if (hBrush != null) Draw_Space.FillRectangle(hBrush, 0, 0, panel1.Width, panel1.Height);
            if (LinearGradientBrush != null) Draw_Space.FillRectangle(LinearGradientBrush, panel1.ClientRectangle);
            Pen pen = new Pen(Color.Black, 2);
            Point y1 = new Point(panel1.Width / 2 + d_x, 0);
            Point y2 = new Point(panel1.Width / 2 + d_x, panel1.Height);
            Draw_Space.DrawLine(pen, y1, y2);

            Point x1 = new Point(0, panel1.Height / 2 + d_y);
            Point x2 = new Point(panel1.Width, panel1.Height / 2 + d_y);
            Draw_Space.DrawLine(pen, x1, x2);

            Point center = new Point(panel1.Width / 2 + d_x, panel1.Height / 2 + d_y);
            Pen pen_1 = new Pen(Color.Black, 1);
            for (int i = center.X; i >= 0; i -= 40)
            {
                Draw_Space.DrawLine(pen_1, new Point(i, 0), new Point(i, panel1.Height));
            }
            for (int i = center.X; i < panel1.Width; i += 40)
            {
                Draw_Space.DrawLine(pen_1, new Point(i, 0), new Point(i, panel1.Height));
            }
            for (int i = center.Y; i >= 0; i -= 40)
            {
                Draw_Space.DrawLine(pen_1, new Point(0, i), new Point(panel1.Width, i));
            }
            for (int i = center.Y; i < panel1.Height; i += 40)
            {
                Draw_Space.DrawLine(pen_1, new Point(0, i), new Point(panel1.Width, i));
            }
            float[] dashValues = { 3, 3, 3, 3 };
            Pen pen_punc = new Pen(Color.Red, 3);
            pen_punc.DashPattern = dashValues;
            Draw_Space.DrawEllipse(pen_punc, center.X - k, center.Y - k, 2 * k, 2 * k);
            if (flag == 1)
            {
                Draw_Space.DrawLine(pen_punc, new Point(mouse_down_loc.X, panel1.Height), mouse_down_loc);
                Draw_Space.DrawLine(pen_punc, new Point(mouse_down_loc.X, 0), mouse_down_loc);
            }
            if (p != null)
            {
                Draw_Grafic(Draw_Space);
            }
            if (scale != 1)
            {
                string ScaleText = $"Масштаб: " + scale.ToString() + " единиц";
                Draw_Space.DrawString(ScaleText, Font, Brushes.Black, new PointF(panel1.Width - 120, 10));
            }
            if (ball == true && p.Count != 0)
            {
                Pen pen2 = new Pen(Color.Green, 2);
                IFunc a;
                if (p[0] == 1) a = new Sin();
                else if (p[0] == 2) a = new Line();
                else if (p[0] == 3) a = new Sqr();
                else if (p[0] == 4) a = new Cube();
                else a = new Tg();
                PointF curr = new PointF(d_start_x * k + panel1.Width / 2 + d_x, panel1.Height / 2 - a.Calc(d_start_x) * k + d_y);
                Draw_Ball(Draw_Space, pen2, curr.X, curr.Y);
                if (d_start_x == panel1.Width / k)
                {
                    ball = false;
                    
                };
            }
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) k *= 2;
            else k /= 2;
            if (e.Delta > 0 && scale >= 1)
            {
                scale += 1;
            }
            else if (e.Delta > 0 && scale < 1)
            {
                scale *= 2;
            }
            else if (e.Delta < 0 && scale > 1)
            {
                scale -= 1;
            }
            else
            {
                scale /= 2;
            }
            panel1.Refresh();

        }
        private void Random_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int r = random.Next(1, 1);
            p.Add(r);
            Color color = new Color();
            ColorDialog dialog = new ColorDialog();
            MessageBox.Show("Выберите цвет графика");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                color = dialog.Color;
            }
            pen_1 = new Pen(color, (float)1.5);
            panel1.Refresh();
        }
        private void Draw_Grafic(Graphics Draw_Space)
        {
            if (p.Count() != 0)
            {
                for (int j = 0; j < p.Count(); j++)
                {
                    float step = 0.01f;
                    IFunc a;
                    if (p[j] == 1) a = new Sin();
                    else if (p[j] == 2) a = new Line();
                    else if (p[j] == 3) a = new Sqr();
                    else if (p[j] == 4) a = new Cube();
                    else a = new Tg();
                    PointF last_point = new PointF(0, a.Calc(0) * k);
                    for (float i = -panel1.Width ; i <= panel1.Width; i += step)
                    {
                        PointF curr = new PointF(i*k  + panel1.Width / 2 + d_x, panel1.Height / 2 - a.Calc(i)*k + d_y);
                        Draw_Space.DrawLine(pen_1, curr, last_point);
                        last_point = curr;
                    }
                    if (flag == 1)
                    {
                        string text = ((float)(mouse_down_loc1.X - (panel1.Width / 2 + d_x)) / k).ToString() + "  " + (a.Calc((float)(mouse_down_loc1.X - (panel1.Width / 2 + d_x)) / k)).ToString();
                        Point g = new Point(mouse_down_loc1.X, mouse_down_loc1.Y);
                        Draw_Space.DrawString(text, Font, Brushes.Black, g);
                        flag = 0;
                        //To do: при нажатии кнопки по функции катится шарик слева направо 
                    }
                }
            }
        }
        private void Style_Click(object sender, EventArgs e)
        {
            hBrush = null;
            LinearGradientBrush = null;
            DialogResult re_s = MessageBox.Show("Хотите изменить цвет фона?", "Цвет", MessageBoxButtons.OKCancel);
            if (re_s == DialogResult.OK)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    panel1.BackColor = dialog.Color;
            }
            DialogResult result = MessageBox.Show("Хотите заштриховать фон?", "Штриховка", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Form2 f = new Form2();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    int style = f.get_item();
                    Color h = Color.FromName("White");
                    ColorDialog dia = new ColorDialog();
                    if (dia.ShowDialog() == DialogResult.OK)
                    {
                        h = dia.Color;
                    }
                    if (style == 0)
                    {
                        hBrush = new HatchBrush(HatchStyle.Horizontal, h, panel1.BackColor);
                    }
                    else if (style == 1)
                    {
                        hBrush = new HatchBrush(HatchStyle.Vertical, h, panel1.BackColor);
                    }
                    else if (style == 2)
                    {
                        hBrush = new HatchBrush(HatchStyle.Wave, h, panel1.BackColor);
                    }
                    else if (style == 3)
                    {
                        hBrush = new HatchBrush(HatchStyle.BackwardDiagonal, panel1.BackColor);
                    }
                    else if (style == 4)
                    {
                        hBrush = new HatchBrush(HatchStyle.Cross, h, panel1.BackColor);
                    }
                    else
                    {
                        hBrush = new HatchBrush(HatchStyle.DiagonalCross, h, panel1.BackColor);
                    }
                    panel1.Refresh();
                }
            }
            DialogResult res = MessageBox.Show("Хотите сделать фон градиентным?", "Градиент", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                ColorDialog choose_grad1 = new ColorDialog();
                Color first = new Color();
                Color second = new Color();
                MessageBox.Show("Выберите цвета");
                if (choose_grad1.ShowDialog() == DialogResult.OK)
                {
                    first = choose_grad1.Color;
                }
                ColorDialog choose_grad2 = new ColorDialog();
                if (choose_grad2.ShowDialog() == DialogResult.OK)
                {
                    second = choose_grad2.Color;
                }
                LinearGradientBrush = new LinearGradientBrush(new Point(0, panel1.Height), new Point(panel1.Width, 0), first, second);
                panel1.Refresh();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down_loc = new Point(e.Location.X, e.Location.Y);
            is_down = true;
            tmp_dx = d_x;
            tmp_dy = d_y;
            if (e.Button == MouseButtons.Right)
            {
                flag = 1;
                mouse_down_loc1 = new Point(e.Location.X, e.Location.Y);
                panel1.Refresh();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.Filter = "*.jpeg|*";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(btm, panel1.ClientRectangle);
                btm.Save(Dialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            is_down = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_down == true)
            {
                d_x = tmp_dx + e.Location.X - mouse_down_loc.X;
                d_y = tmp_dy + e.Location.Y - mouse_down_loc.Y;
                panel1.Refresh();
            }
        }
        private void Draw_Ball(Graphics Draw_Space, Pen pen2, float x, float y)
        {
            int ball_rad = 10;
            Draw_Space.DrawEllipse(pen2, x, y, ball_rad, ball_rad);
        }
        private void Ball_Click(object sender, EventArgs e)
        {
            if (p.Count != 0)
            {
                d_start_x = -(panel1.Width / k) / 2;
                Timer timer = new Timer();
                timer.Interval = 10;
                timer.Tick += timer_Tick;
                timer.Start();
                ball = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
            d_start_x += 0.01f;
        }
    }
}
