using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic1
{
    public partial class Form1 : Form
    {
        Dot linDot1;
        Dot linDot2;
        Dot linCenter;
        static List<Dot> cubeDots;
        static Dot center, dot, dot1, dot2, dot3, dot5, dot6, dot7, tet1, tet2, tet3, incenter;
        static List<Dot> tetDots;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.DarkBlue, 3);
            SolidBrush solidBrush = new SolidBrush(Color.DarkBlue);
            SolidBrush solidBrush1 = new SolidBrush(Color.DarkOrange);
            linDot1 = new Dot(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            linDot2 = new Dot((int)(linDot1.X + Convert.ToInt32(textBox3.Text)), (int)(linDot1.Y + Convert.ToInt32(textBox3.Text)));
            linDot2.Rotate(Convert.ToInt32(textBox4.Text), linDot1);
            graphics.DrawLine(pen, linDot1.X, linDot1.Y, linDot2.X, linDot2.Y);
            linCenter = new Dot((int)(linDot1.X / 2 + linDot2.X / 2), (int)(linDot1.Y / 2 + linDot2.Y / 2));
            center = new Dot((int)(linCenter.X-300), (int)(linCenter.Y - 150));
            dot = new Dot((int)(linCenter.X - 300), (int)(linCenter.Y - 200));
            dot1 = new Dot((int)(linCenter.X - 300), (int)(linCenter.Y - 200));
            dot2 = new Dot((int)(linCenter.X - 300), (int)(linCenter.Y - 200));
            dot1.Rotate(90, center);
            dot2.Rotate(-135, center);
            dot3 = new Dot((int)dot1.X, (int)dot1.Y - 50);
            dot3.Rotate(-135, dot1);
            dot5 = new Dot((int)dot1.X, (int)dot1.Y - 50);
            dot6 = new Dot((int)dot2.X, (int)dot2.Y - 50);
            dot7 = new Dot((int)dot3.X, (int)dot3.Y - 50);
            graphics.DrawLine(pen, center.X, center.Y, dot.X, dot.Y);
            graphics.DrawLine(pen, center.X, center.Y, dot1.X, dot1.Y);
            graphics.DrawLine(pen, center.X, center.Y, dot2.X, dot2.Y);
            graphics.DrawLine(pen, dot1.X, dot1.Y, dot3.X, dot3.Y);
            graphics.DrawLine(pen, dot2.X, dot2.Y, dot3.X, dot3.Y);
            graphics.DrawLine(pen, dot.X, dot.Y, dot5.X, dot5.Y);
            graphics.DrawLine(pen, dot5.X, dot5.Y, dot7.X, dot7.Y);
            graphics.DrawLine(pen, dot6.X, dot6.Y, dot7.X, dot7.Y);
            graphics.DrawLine(pen, dot6.X, dot6.Y, dot.X, dot.Y);
            graphics.DrawLine(pen, dot5.X, dot5.Y, dot1.X, dot1.Y);
            graphics.DrawLine(pen, dot2.X, dot2.Y, dot6.X, dot6.Y);
            graphics.DrawLine(pen, dot7.X, dot7.Y, dot3.X, dot3.Y);
            cubeDots = new List<Dot> { center, dot, dot1, dot2, dot3, dot5, dot6, dot7 };
            tet1 = new Dot((int)(linCenter.X + 200), (int)(linCenter.Y + 100));
            tet3 = new Dot((int)tet1.X+50, (int)tet1.Y);
            tet3.Rotate(30,tet1);
            tet2 = new Dot((int)tet1.X + 100, (int)tet1.Y);
            graphics.DrawLine(pen, tet1.X, tet1.Y, tet2.X, tet2.Y);
            graphics.DrawLine(pen, tet2.X, tet2.Y, tet3.X, tet3.Y);
            graphics.DrawLine(pen, tet3.X, tet3.Y, tet1.X, tet1.Y);
            incenter = new Dot();
            incenter.MedianIntersection(tet1,tet2,tet3);
            incenter.Y -= 75;
            graphics.DrawLine(pen, tet1.X, tet1.Y, incenter.X, incenter.Y);
            graphics.DrawLine(pen, tet2.X, tet2.Y, incenter.X, incenter.Y);
            graphics.DrawLine(pen, tet3.X, tet3.Y, incenter.X, incenter.Y);
            tetDots = new List<Dot> { tet1, tet2, tet3, incenter};
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timer timer3 = new Timer();
            timer3.Tick += new EventHandler(RotateFigures);
            timer3.Interval = 250;
            timer3.Start();

        }
        public void RotateFigures(object sender, EventArgs e)
        {
            
            foreach (Dot dt in cubeDots)
            {
                dt.Rotate(10, linCenter);
            }
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.DarkBlue, 3);
            graphics.DrawLine(pen, linDot1.X, linDot1.Y, linDot2.X, linDot2.Y);
            graphics.DrawLine(pen, center.X, center.Y, dot.X, dot.Y);
            graphics.DrawLine(pen, center.X, center.Y, dot1.X, dot1.Y);
            graphics.DrawLine(pen, center.X, center.Y, dot2.X, dot2.Y);
            graphics.DrawLine(pen, dot1.X, dot1.Y, dot3.X, dot3.Y);
            graphics.DrawLine(pen, dot2.X, dot2.Y, dot3.X, dot3.Y);
            graphics.DrawLine(pen, dot.X, dot.Y, dot5.X, dot5.Y);
            graphics.DrawLine(pen, dot5.X, dot5.Y, dot7.X, dot7.Y);
            graphics.DrawLine(pen, dot6.X, dot6.Y, dot7.X, dot7.Y);
            graphics.DrawLine(pen, dot6.X, dot6.Y, dot.X, dot.Y);
            graphics.DrawLine(pen, dot5.X, dot5.Y, dot1.X, dot1.Y);
            graphics.DrawLine(pen, dot2.X, dot2.Y, dot6.X, dot6.Y);
            graphics.DrawLine(pen, dot7.X, dot7.Y, dot3.X, dot3.Y);
            foreach (Dot dt in tetDots)
            {
                dt.Rotate(-10, linCenter);
            }
            graphics.DrawLine(pen, tet1.X, tet1.Y, tet2.X, tet2.Y);
            graphics.DrawLine(pen, tet2.X, tet2.Y, tet3.X, tet3.Y);
            graphics.DrawLine(pen, tet3.X, tet3.Y, tet1.X, tet1.Y);
            graphics.DrawLine(pen, tet1.X, tet1.Y, incenter.X, incenter.Y);
            graphics.DrawLine(pen, tet2.X, tet2.Y, incenter.X, incenter.Y);
            graphics.DrawLine(pen, tet3.X, tet3.Y, incenter.X, incenter.Y);
        }
        
    }
    
}
