namespace programmingCs
{
    abstract class Shape
    {
        protected string color;
        protected Shape(string color)
        {
            this.color = color;
        }

        public abstract double volume();
    }
}
