using System;

namespace programmingCs
{
    class Rectangle : Figures
    {
        public double x1 = 0, x2 = 0, y1 = 0, y2 = 0, a = 0, RectangleArea, RectanglePerimeter;
        public Rectangle()
        {
            a = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            Area();
            Perimeter();
        }
        public void Setxy(double x11, double y11, double x22, double y22)
        {
            x1 = x11;
            y1 = y11;
            x2 = x22;
            y2 = y22;
            a = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        public void Area()
        {
            RectangleArea = a * a;
        }
        public void Perimeter()
        {
            RectanglePerimeter = a * 4;
        }
        public void PrintArea()
        {
            Console.WriteLine("Площадь прямоугольника: {RectangleArea}");
        }
        public void PrintPerimeter()
        {
            Console.WriteLine("Периметр прямоугольника: {RectanglePerimeter}");
        }
        public void PrintXY()
        {
            Console.WriteLine("Координаты линии прямоугольника: ({x1}, {y1}), ({x2}, {y2})");
        }
        public void ScalePlus(double procent)
        {
            RectangleArea = RectangleArea * (1 + procent / 100);
            a = Math.Sqrt(RectangleArea);
            Perimeter();
        }
        public void ScaleMinus(double procent)
        {
            RectangleArea = RectangleArea * (1 - procent / 100);
            a = Math.Sqrt(RectangleArea);
            Perimeter();
        }
        public void Rotating(double angle)
        {
            double x11, y11, x22, y22;
            x11 = x1;
            y11 = y1;
            x22 = x2;
            y22 = y2;
            x1 = x11 * Math.Cos(angle) - y11 * Math.Sin(angle);
            y1 = x11 * Math.Sin(angle) + y11 * Math.Cos(angle);
            x2 = x22 * Math.Cos(angle) - y22 * Math.Sin(angle);
            y2 = x22 * Math.Sin(angle) + y22 * Math.Cos(angle);
        }
    }
}