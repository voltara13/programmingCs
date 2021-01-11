namespace programmingCs
{
    class Square : Shape2D
    {
        protected double l;
        public Square(string color, double l) : base(color)
        {
            this.l = l;
        }

        public override double volume()
        {
            return l * l;
        }
    }
}
