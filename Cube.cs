namespace programmingCs
{
    class Cube : Shape3D
    {
        protected double l;
        public Cube(string color, double l) : base(color)
        {
            this.l = l;
        }

        public override double volume()
        {
            return l * l * l;
        }
    }
}
