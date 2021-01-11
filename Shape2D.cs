namespace programmingCs
{
    abstract class Shape2D : Shape
    {
        protected Shape2D(string color) : base(color) {}
        public abstract override double volume();
    }
}
