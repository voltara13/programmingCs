using System;

namespace programmingCs
{
    class Circle : Figures
    {
        public double x = 0, y = 0, r = 0, CircleArea, CirclePerimeter;
        public Circle()
        {
            Area();
            Perimeter();
        }
        public void Setxyr(double x1, double y1, double r1)
        {
            x = x1;
            y = y1;
            r = r1;
        }
        public void Area()
        {
            CircleArea = Math.PI * r * r;
        }
        public void Perimeter()
        {
            CirclePerimeter = 2 * Math.PI * r;
        }
        public void MathtabPlus(double Procent)
        {
            CircleArea = CircleArea * (1 + (Procent / 100));
            r = Math.Sqrt(CircleArea / Math.PI);
            Perimeter();
        }
        public void MathtabMinus(double Procent)
        {
            CircleArea = CircleArea * (1 - (Procent / 100));
            r = Math.Sqrt(CircleArea / Math.PI);
            Perimeter();
        }
        public void Rotating(double angle)
        {
            double x11, y11;
            x11 = x;
            y11 = y;
            x = x11 * Math.Cos(angle) - y11 * Math.Sin(angle);
            y = x11 * Math.Sin(angle) + y11 * Math.Cos(angle);
        }
        public void PrintXYR()
        {
            Console.WriteLine("Координаты центра круга и радиус: ({x}, {y}), r = {r}");
        }
        public void PrintArea()
        {
            Console.WriteLine("Площадь круга: {CircleArea}");
        }
        public void PrintPerimeter()
        {
            Console.WriteLine("Периметр круга: {CirclePerimeter}");
        }
    }
}
