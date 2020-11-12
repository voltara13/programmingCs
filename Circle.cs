﻿using System;

namespace programmingCs
{
    [Serializable]
    class Circle : VectorDocument
    {
        public Circle()
        {
            ChangeFigure();
        }
        private int red, green, blue, alpha;
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
                string temp = Console.ReadLine();
                string[] splitString = temp.Split(' ');
                if (splitString.Length == 7 &&
                    double.TryParse(splitString[0], out double _x) &&
                    double.TryParse(splitString[1], out double _y) &&
                    double.TryParse(splitString[2], out double _r) &&
                    int.TryParse(splitString[3], out int _red) &&
                    int.TryParse(splitString[4], out int _green) &&
                    int.TryParse(splitString[5], out int _blue) &&
                    int.TryParse(splitString[6], out int _alpha))
                {
                    x = _x;
                    y = _y;
                    r = _r;
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
            Console.Write("Круг\n" +
                          $"Центр: ({rnd(x)}, {rnd(y)})\n" +
                          $"Радиус: {rnd(r)}\n" +
                          $"Длина окружности: {rnd(c)}\n" +
                          $"Площадь: {rnd(s)}\n" +
                          $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})");
        }
    }
}
