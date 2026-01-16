using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //var d = DateTime.Now;
            InitializeComponent();

            //Apple apple0 = new Apple();
            //Apple apple1 = new Apple();
            //Apple apple2 = new Apple();

            //Apple[] apples = new Apple[3];
            //apples[0] = apple0;
            //apples[1] = apple1;
            //apples[2] = apple2;
            //List<Apple> list = new List<Apple>();
            //list.Add(apple0);
            //list.Add(apple1);
            //list.Add(apple2);
            //list.Add(apple0);
            //list.AddRange(apples);

            //apple0.Eat();
            //apple1.Eat();
            //apple2.Eat();

            //int v = apple0.GetVolume();
        }
        private readonly Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;
            this.timer.Start();
        }
        private readonly Pen second_pen = new Pen(Color.Red, 4);
        private readonly Pen miniute_pen = new Pen(Color.Red, 4);
        private readonly Pen hour_pen = new Pen(Color.Yellow, 6);
        const int r_second = 140;
        const int r_miniute = 120;
        const int r_hour = 80;
        private readonly Pen a = new Pen(Color.White, 1);
        const int r_a = 160;
        const int r_b = 90;
        const int r_c = 120;

        private int b = 0;
        private readonly Font font = new Font(FontFamily.GenericSansSerif,
            40.0f, FontStyle.Regular);
        private void Timer_Tick(object sender, EventArgs e)
        {
            var ct = DateTime.Now;
            using (var bitmap = new Bitmap(this.Width, this.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Green);
                    int x0 = this.Width / 2;
                    int y0 = this.Height / 2;
                    g.DrawRectangle(Pens.AliceBlue, x0 - 150, 1000, 350, 75);

                    //g.Clear(Color.Green);
                    g.FillPie(Brushes.Blue, new Rectangle(
                        x0 - 160, y0 - 160, 2 * 160, 2 * 160), 0, 360);
                    double alpha = 0;

                    for (int i = 0; i < 360; i += 30)
                    {
                        alpha = (i) * Math.PI / 180.0;//
                        int xs = (int)(x0 + r_a * Math.Cos(alpha));
                        int ys = (int)(y0 + r_a * Math.Sin(alpha));
                        int r_m = i % 90 == 0 ? r_b : r_c;
                        int x = (int)(x0 + r_m * Math.Cos(alpha));
                        int y = (int)(y0 + r_m * Math.Sin(alpha));

                        g.DrawLine(a, new Point(x, y), new Point(xs, ys));

                        alpha = (i - 60) * Math.PI / 180.0;//
                        int xst = (int)(x0 + (r_a + 32) * Math.Cos(alpha));
                        int yst = (int)(y0 + (r_a + 32) * Math.Sin(alpha));

                        var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        g.DrawString(((i) / 30 + 1).ToString(), font, Brushes.Black, new PointF(xst, yst), sf);
                    }

                    alpha = (ct.Second * 6 - 90) * Math.PI / 180.0;

                    int x1 = (int)(x0 + r_second * Math.Cos(alpha));
                    int y1 = (int)(y0 + r_second * Math.Sin(alpha));
                    g.DrawLine(second_pen, new Point(x0, y0), new Point(x1, y1));


                    alpha = (ct.Minute * 6 - 90) * Math.PI / 180.0;//

                    int x2 = (int)(x0 + r_miniute * Math.Cos(alpha));
                    int y2 = (int)(y0 + r_miniute * Math.Sin(alpha));
                    g.DrawLine(miniute_pen, new Point(x0, y0), new Point(x2, y2));


                    alpha = (ct.Hour * 30 - 90) * Math.PI / 180.0;//
                    int x3 = (int)(x0 + r_hour * Math.Cos(alpha));
                    int y3 = (int)(y0 + r_hour * Math.Sin(alpha));
                    g.DrawLine(hour_pen, new Point(x0, y0), new Point(x3, y3));

                    g.FillPie(Brushes.Green, new Rectangle(
                       758, 570, 90, 70), 0, 360);

                    string text = "";
                    if (ct.Hour >= 12)
                    {
                        text = $"{ct.Hour - 12:D2}:{ct.Minute:D2}:{ct.Second:D2} PM";
                    }
                    else
                    {
                        text
                            = $"{ct.Hour:D2}:{ct.Minute:D2}:{ct.Second:D2} AM";
                    }

                    g.DrawString(text, font, Brushes.Black, new PointF(x0 - 136, 1005));
                    //g.DrawLine(Pens.AliceBlue, x0 - 80, y0, x0 - 160, y0);
                    //g.DrawLine(Pens.AliceBlue, x0 + 80, y0, x0 + 160, y0);
                    //g.DrawLine(Pens.AliceBlue, x0, y0 - 80, x0, y0 - 160);
                    //g.DrawLine(Pens.AliceBlue, x0, y0 + 80, x0, y0 + 160);

                    //alpha = (30) * Math.PI / 180.0;//
                    //int xs = (int)(x0 + r_a * Math.Cos(alpha));
                    //int ys = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 + 90, y0 + 50), new Point(xs, ys));
                    //alpha = (60) * Math.PI / 180.0;//
                    //int xa = (int)(x0 + r_a * Math.Cos(alpha));
                    //int ya = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 + 50, y0 + 90), new Point(xa, ya));
                    //alpha = (120) * Math.PI / 180.0;//
                    //int xd = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yd = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 - 50, y0 + 90), new Point(xd, yd));
                    //alpha = (150) * Math.PI / 180.0;//
                    //int xf = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yf = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 - 90, y0 + 50), new Point(xf, yf));
                    //alpha = (210) * Math.PI / 180.0;//
                    //int xg = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yg = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 - 90, y0 - 50), new Point(xg, yg));
                    //alpha = (240) * Math.PI / 180.0;//
                    //int xh = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yh = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 - 50, y0 - 90), new Point(xh, yh));
                    //alpha = (300) * Math.PI / 180.0;//
                    //int xj = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yj = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 + 50, y0 - 90), new Point(xj, yj));
                    //alpha = (330) * Math.PI / 180.0;//
                    //int xk = (int)(x0 + r_a * Math.Cos(alpha));
                    //int yk = (int)(y0 + r_a * Math.Sin(alpha));

                    //g.DrawLine(a, new Point(x0 + 90, y0 - 50), new Point(xk, yk));
                    //g.DrawString("8", font, Brushes.Black, new PointF(xs, ys));
                    //g.DrawString("10", font, Brushes.Black, new PointF(xa, ya));
                    //g.DrawString("14", font, Brushes.Black, new PointF(xd - 90, yd));
                    //g.DrawString("16", font, Brushes.Black, new PointF(xf - 80, yf));
                    //g.DrawString("20", font, Brushes.Black, new PointF(xg - 80, yg-40));
                    //g.DrawString("22", font, Brushes.Black, new PointF(xh - 80, yh-50));
                    //g.DrawString("2", font, Brushes.Black, new PointF(xj +10, yj-50));
                    //g.DrawString("4", font, Brushes.Black, new PointF(xk +10, yk - 40));
                    //g.DrawString("6", font, Brushes.Black, new PointF(x0 + 170, y0-30));
                    //g.DrawString("12", font, Brushes.Black, new PointF(x0-40, y0+ 160));
                    //g.DrawString("18", font, Brushes.Black, new PointF(x0-250, y0-30));
                    //g.DrawString("24", font, Brushes.Black, new PointF(x0-40, y0-220));


                }
                using (var g = this.CreateGraphics())
                {
                    g.DrawImage(bitmap, new Point(0, 0));
                }
            }
        }
    }
}
