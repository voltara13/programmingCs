namespace programmingCs
{
    abstract class Shape3D : Shape
    {
        protected Shape3D(string color) : base(color) { }
        public abstract override double volume();
    }
}
