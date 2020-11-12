using System;

namespace programmingCs
{
    [Serializable]
    class Rectangle : VectorDocument
    {
        public Rectangle()
        {
            ChangeFigure();
        }
        private int red, green, blue, alpha;
        private double x1, y1, x2, y2, d, c, s;
        private void Edit()
        {
            d = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            c = 2 * d * Math.Sqrt(2);
            s = d * d / 2;
        }
        protected override void AngleEdit()
        {
            double _x1 = x1, _y1 = y1, _x2 = x2, _y2 = y2, _Angle = Angle * Math.PI / 180; ;
            x1 = _x1 * Math.Cos(_Angle) - _y1 * Math.Sin(_Angle);
            y1 = _x1 * Math.Sin(_Angle) + _y1 * Math.Cos(_Angle);
            x2 = _x2 * Math.Cos(_Angle) - _y2 * Math.Sin(_Angle);
            y2 = _x2 * Math.Sin(_Angle) + _y2 * Math.Cos(_Angle);
        }
        protected override void ScaleEdit()
        {
            double _Scale = Math.Sqrt(Scale);
            x1 *= _Scale;
            y1 *= _Scale;
            x2 *= _Scale;
            y2 *= _Scale;
            Edit();
        }
        protected override void CenterEdit()
        {
            x1 += Dx;
            y1 += Dy;
            x2 += Dx;
            y2 += Dy;
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
                    int.TryParse(splitString[5], out int _red) &&
                    int.TryParse(splitString[4], out int _green) &&
                    int.TryParse(splitString[5], out int _blue) &&
                    int.TryParse(splitString[6], out int _alpha))
                {
                    x1 = _x1;
                    y1 = _y1;
                    x2 = _x2;
                    y2 = _y2;
                    red = _red;
                    green = _green;
                    blue = _blue;
                    alpha = _alpha;
                    Edit();
                    break;
                }
                Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
            }
        }
        protected override void PrintDescription()
        {
            Func<double, double> rnd = _x => Math.Round(_x, 2);
            Console.Write("Четырехугольник\n" +
                          $"Первая точка: ({rnd(x1)}, {rnd(y1)})\n" +
                          $"Вторая точка: ({rnd(x2)}, {rnd(y2)})\n" +
                          $"Периметр: {rnd(c)}\n" +
                          $"Площадь: {rnd(s)}\n" +
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})");
        }
    }
}