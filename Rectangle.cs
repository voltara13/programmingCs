using System;

namespace programmingCs
{
    [Serializable]
    class Rectangle : VectorDocument
    {
        private double x1, y1, x2, y2, d, c, s, red, green, blue, alpha;
        private void Edit()
        {
            d = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            c = 2 * Math.Sqrt(2) * d * d;
            s = d * d / 2;
        }
        public Rectangle(double x1, double x2, double y1, double y2, double red, double green, double blue, double alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }
        protected override void AngleEdit()
        {
            double _x1, _y1, _x2, _y2;
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            x1 = _x1 * Math.Cos(Angle) - _y1 * Math.Sin(Angle);
            y1 = _x1 * Math.Sin(Angle) + _y1 * Math.Cos(Angle);
            x2 = _x2 * Math.Cos(Angle) - _y2 * Math.Sin(Angle);
            y2 = _x2 * Math.Sin(Angle) + _y2 * Math.Cos(Angle);
        }
        protected override void ScaleEdit()
        {
            double _Scale = Math.Sqrt(Scale);
            x1 *= _Scale;
            y1 *= _Scale;
            x2 *= _Scale;
            y2 *= _Scale;
        }
        protected override void CenterEdit()
        {
            x1 = X1;
            y1 = Y1;
            x2 = X2;
            y2 = Y2;
        }
        protected override void ChangeFigure()
        {
            while (true)
            {
                Console.Write("Введите координаты крайних точек диагонали,и цвет в формате 'x1 y1 x2 y2 RED GREEN BLUE ALPHA'\nВВОД: ");
                string temp = Console.ReadLine();
                string[] splitString = temp.Split(' ');
                if (splitString.Length == 8 &&
                    double.TryParse(splitString[0], out double _x1) &&
                    double.TryParse(splitString[1], out double _y1) &&
                    double.TryParse(splitString[2], out double _x2) &&
                    double.TryParse(splitString[3], out double _y2) &&
                    double.TryParse(splitString[5], out double _red) &&
                    double.TryParse(splitString[4], out double _green) &&
                    double.TryParse(splitString[5], out double _blue) &&
                    double.TryParse(splitString[6], out double _alpha))
                {
                    x1 = _x1;
                    y1 = _y1;
                    x2 = _x2;
                    y2 = _y2;
                    red = _red;
                    green = _green;
                    blue = _blue;
                    alpha = _alpha;
                    break;
                }
                Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
            }
        }
        protected override void PrintDescription()
        {
            Console.Write("Четырехугольник\n" +
                          $"Первая точка: ({x1}, {y1})\n" +
                          $"Вторая точка: ({x2}, {y2})\n" +
                          $"Периметр: {c}\n" +
                          $"Площадь: {s}\n" +
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})");
        }
        protected double X1
        {
            get => x1;
            set
            {
                x1 = value + base.X;
                AngleEdit();
                ScaleEdit();
                Edit();
            }
        }
        protected double Y1
        {
            get => y1;
            set
            {
                y1 = value + base.Y;
                AngleEdit();
                ScaleEdit();
                Edit();
            }
        }
        protected double X2
        {
            get => x2;
            set
            {
                x2 = value + base.X;
                AngleEdit();
                ScaleEdit();
                Edit();
            }
        }
        protected double Y2
        {
            get => y2;
            set
            {
                y2 = value + base.Y;
                AngleEdit();
                ScaleEdit();
                Edit();
            }
        }
    }
}