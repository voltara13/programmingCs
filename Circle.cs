using System;

namespace programmingCs
{
    [Serializable]
    sealed class Circle : VectorDocument
    {
        public Circle()
        {
            ChangeFigure();
        }
        private byte red, green, blue, alpha;
        private double x, y, r, c, s;
        private void Edit()
        {
            c = Math.PI * 2 * r;
            s = Math.PI * r * r;
        }
        protected override void AngleEdit()
        {
            double _x = x, _y = y, _Angle = Angle * Math.PI / 180;
            x = _x * Math.Cos(_Angle) - _y * Math.Sin(_Angle);
            y = _x * Math.Sin(_Angle) + _y * Math.Cos(_Angle);
        }
        protected override void ScaleEdit()
        {
            double _Scale = Math.Sqrt(Scale);
            r *= _Scale;
            Edit();
        }
        protected override void CenterEdit()
        {
            x += Dx;
            y += Dy;
        }
        protected override void ChangeFigure()
        {
            while (true)
            {
                Console.Write("Введите координаты центра, радиус и цвет в формате 'x y r RED GREEN BLUE ALPHA'\nВВОД: ");
                string[] splitString = Console.ReadLine().Split(' ');
                try
                {
                    x = Convert.ToByte(splitString[0]);
                    y = Convert.ToByte(splitString[1]);
                    r = Convert.ToByte(splitString[2]);
                    red = Convert.ToByte(splitString[3]);
                    green = Convert.ToByte(splitString[4]);
                    blue = Convert.ToByte(splitString[5]);
                    alpha = Convert.ToByte(splitString[6]);
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
            Console.Write("Круг\n" +
                          $"Центр: ({rnd(x)}, {rnd(y)})\n" +
                          $"Радиус: {rnd(r)}\n" +
                          $"Длина окружности: {rnd(c)}\n" +
                          $"Площадь: {rnd(s)}\n" +
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})\n");
        }
    }
}
