using System;

namespace programmingCs
{
    class Circle : Shape2D
    {
        protected double r;
        public Circle(string color, double r) : base(color)
        {
            this.r = r;
        }

        public override double volume()
        {
            return Math.PI * r * r;
        }
    }
}
