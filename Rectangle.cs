using System;

namespace programmingCs
{
    [Serializable]
    sealed class Rectangle : VectorDocument
    {
        public Rectangle()
        {
            ChangeFigure();
        }
        private byte red, green, blue, alpha;
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
                string[] splitString = Console.ReadLine().Split(' ');
                try
                {
                    x1 = Convert.ToByte(splitString[0]);
                    y1 = Convert.ToByte(splitString[1]);
                    x2 = Convert.ToByte(splitString[2]);
                    y2 = Convert.ToByte(splitString[3]);
                    red = Convert.ToByte(splitString[4]);
                    green = Convert.ToByte(splitString[5]);
                    blue = Convert.ToByte(splitString[6]);
                    alpha = Convert.ToByte(splitString[7]);
                    Edit();
                    break;
                }
                catch (Exception)
                {
                    Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
                }
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
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})\n");
        }
    }
}