using System;

namespace programmingCs
{
    class Figures
    {
        public double RED = 0, GREEN = 0, BLUE = 0, Opacity = 0;
        public void SetColor(int R, int G, int B)
        {
            RED = R;
            GREEN = G;
            BLUE = B;
        }
        public void SetOpacity(double O)
        {
            Opacity = O;
        }
        public void PrintColor()
        {
            Console.WriteLine("Цвет фигуры(RGB): {RED}, {GREEN}, {BLUE}");
        }
        public void PrintOpacity()
        {
            Console.WriteLine("Прозрачность фигуры: {Opacity}%");
        }
    }
}
