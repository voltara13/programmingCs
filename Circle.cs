using System;

namespace programmingCs
{
    [Serializable]
    class Circle : VectorDocument
    {
        private double x, y, r, c, s, red, green, blue, alpha;
        public Circle(double x, double y, double r, double red, double green, double blue, double alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            X = x;
            Y = y;
            R = r;
        }
        protected override void AngleEdit()
        {
            double _x, _y;
            _x = x;
            _y = y;
            x = _x * Math.Cos(Angle) - _y * Math.Sin(Angle);
            y = _x * Math.Sin(Angle) + _y * Math.Cos(Angle);
        }
        protected override void ScaleEdit()
        {
            double _Scale = Math.Sqrt(Scale);
            r *= _Scale;
            c = Math.PI * 2 * r;
            s = Math.PI * r * r;
        }
        protected override void CenterEdit()
        {
            x = X;
            y = Y;
        }
        protected override void ChangeFigure()
        {
            while (true)
            {
                Console.Write("Введите координаты центра, радиус и цвет в формате 'x y r RED GREEN BLUE ALPHA'\nВВОД: ");
                string temp = Console.ReadLine();
                string[] splitString = temp.Split(' ');
                if (splitString.Length == 7 &&
                    double.TryParse(splitString[0], out double _x) &&
                    double.TryParse(splitString[1], out double _y) &&
                    double.TryParse(splitString[2], out double _r) &&
                    double.TryParse(splitString[3], out double _red) &&
                    double.TryParse(splitString[4], out double _green) &&
                    double.TryParse(splitString[5], out double _blue) &&
                    double.TryParse(splitString[6], out double _alpha))
                {
                    x = _x;
                    y = _y;
                    r = _r;
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
            Console.Write("Круг\n" +
                          $"Центр: ({x}, {y})\n" +
                          $"Радиус: {r}\n" +
                          $"Длина окружности: {c}\n" +
                          $"Площадь: {s}\n" +
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})");
        }
        protected double X
        {
            get => x;
            set
            {
                x = value + base.X;
                AngleEdit();
            }
        }
        protected double Y
        {
            get => y;
            set
            {
                y = value + base.Y;
                AngleEdit();
            }
        }
        protected double R
        {
            get => r;
            set
            {
                r = value;
                ScaleEdit();
            }
        }
    }
}
