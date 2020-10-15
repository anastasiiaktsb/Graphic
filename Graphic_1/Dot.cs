using System;
using System.Drawing;

namespace Graphic1
{
    class Dot
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; } = 1;
        public Dot() { }
        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw(Graphics graphics, SolidBrush solidBrush)
        {
            graphics.FillRectangle(solidBrush, X, Y, 5, 5);
        }
        public void Rotate(double angle, Dot center)
        {
            float xCopy = X;
            float yCopy = Y;
            float[] result = new float[3];
            double[,] turnMatrix = new double[3, 3];
            turnMatrix[0, 0] = Math.Cos(angle * Math.PI / 180.0);
            turnMatrix[0, 1] = Math.Sin(angle * Math.PI / 180.0);
            turnMatrix[0, 2] = 0;
            turnMatrix[1, 0] = -Math.Sin(angle * Math.PI / 180.0);
            turnMatrix[1, 1] = Math.Cos(angle * Math.PI / 180.0);
            turnMatrix[1, 2] = 0;
            turnMatrix[2, 0] = -center.X * (Math.Cos(angle * Math.PI / 180.0) - 1) + center.Y * Math.Sin(angle * Math.PI / 180.0);
            turnMatrix[2, 1] = -center.X * Math.Sin(angle * Math.PI / 180.0) - center.Y * (Math.Cos(angle * Math.PI / 180.0) - 1);
            turnMatrix[2, 2] = 1;
            X = (float)(xCopy * turnMatrix[0,0]+ yCopy * turnMatrix[1,0]+Z*turnMatrix[2,0]);
            Y = (float)(xCopy * turnMatrix[0, 1] + yCopy * turnMatrix[1, 1] + Z * turnMatrix[2, 1]);
            Z = 1;
        }
        public void MedianIntersection(Dot dot1, Dot dot2, Dot dot3)
        {
            int x, y;
            double side1 = Math.Sqrt(Math.Pow((dot2.X - dot3.X), 2) + Math.Pow((dot2.Y - dot3.Y), 2));
            double side2 = Math.Sqrt(Math.Pow((dot1.X - dot3.X), 2) + Math.Pow((dot1.Y - dot3.Y), 2));
            double side3 = Math.Sqrt(Math.Pow((dot1.X - dot2.X), 2) + Math.Pow((dot1.Y - dot2.Y), 2));
            x = (int)((side1 * dot1.X + side2 * dot2.X + side3 * dot3.X) / (side1 + side2 + side3));
            y = (int)((side1 * dot1.Y + side2 * dot2.Y + side3 * dot3.Y) / (side1 + side2 + side3));
            X = x;
            Y = y;
            Z = 1;
        }
    }
}
