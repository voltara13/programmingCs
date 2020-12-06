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
            double x1 = this.x1, y1 = this.y1, x2 = this.x2, y2 = this.y2, angle = Angle * Math.PI / 180; ;
            this.x1 = x1 * Math.Cos(angle) - y1 * Math.Sin(angle);
            this.y1 = x1 * Math.Sin(angle) + y1 * Math.Cos(angle);
            this.x2 = x2 * Math.Cos(angle) - y2 * Math.Sin(angle);
            this.y2 = x2 * Math.Sin(angle) + y2 * Math.Cos(angle);
        }
        protected override void ScaleEdit()
        {
            double scale = Math.Sqrt(Scale);
            x1 *= scale;
            y1 *= scale;
            x2 *= scale;
            y2 *= scale;
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
        public override string ToString()
        {
            Func<double, double> rnd = x => Math.Round(x, 2);
            return "\nЧетырехугольник\n" +
                   $"Первая точка: ({rnd(x1)}, {rnd(y1)})\n" +
                   $"Вторая точка: ({rnd(x2)}, {rnd(y2)})\n" +
                   $"Периметр: {rnd(c)}\n" +
                   $"Площадь: {rnd(s)}\n" +
                   $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})";
        }
    }
}