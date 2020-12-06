using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace programmingCs
{
    sealed class Circle : IComparable<Circle>, ICloneable
    {
        internal class SortAreaAscendingHelper : IComparer<Circle>
        {
            public int Compare(Circle x, Circle y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.s.CompareTo(y.s);
            }
        }
        internal class SortAreaDescendingHelper : IComparer<Circle>
        {
            public int Compare(Circle x, Circle y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return y.s.CompareTo(x.s);
            }
        }
        private byte red, green, blue, alpha;
        private double x, y, r, c, s;
        private void Edit()
        {
            c = Math.PI * 2 * r;
            s = Math.PI * r * r;
        }
        protected void ChangeFigure()
        {
            var rand = new Random();
            x = rand.Next(-100, 101);
            y = rand.Next(-100, 101);
            r = rand.Next(1, 101);
            red = Convert.ToByte(rand.Next(0, 256));
            green = Convert.ToByte(rand.Next(0, 256));
            blue = Convert.ToByte(rand.Next(0, 256));
            alpha = Convert.ToByte(rand.Next(0, 256));
            Edit();
        } 
        public Circle()
        {
            ChangeFigure();
        }
        public override string ToString()
        {
            Func<double, double> rnd = x => Math.Round(x, 2);
            return "\nКруг\n" +
                   $"Центр: ({rnd(x)}, {rnd(y)})\n" +
                   $"Радиус: {rnd(r)}\n" +
                   $"Длина окружности: {rnd(c)}\n" +
                   $"Площадь: {rnd(s)}\n" +
                   $"Цвет RGBA: ({red}, {green}, {blue}, {alpha})";
        }
        public object Clone() => new Circle { 
            x = this.x,
            y = this.y,
            r = this.r,
            c = this.c,
            s = this.s,
            red = this.red,
            green = this.green,
            blue = this.blue,
            alpha = this.alpha
        };
        public int CompareTo(Circle other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return s.CompareTo(other.s);
        }
        public static SortAreaAscendingHelper SortAreaAscending() => new SortAreaAscendingHelper();
        public static SortAreaDescendingHelper SortAreaDescending() => new SortAreaDescendingHelper();
        public static void Circle_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Срабатывает при добавлении элемента
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Circle newItem = e.NewItems[0] as Circle;
                Console.WriteLine($"\nДобавлена окружность площадью: {newItem.s}");
            }
            //Срабатывает при удалении элемента
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Circle oldItem = e.OldItems[0] as Circle;
                Console.WriteLine($"\nУдалена окружность площадью: {oldItem.s}");
            }
        }
    }
}