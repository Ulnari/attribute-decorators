namespace DecoratorsDemo
{
    public class ModifyDecorator : IDecorator<int>
    {
        public ModifyDecorator(int delta)
        {
            Delta = delta;
        }

        public int Delta { get; set; }

        public int Value
        {
            get => Decorated.Value + Delta;
            set => Decorated.Value = value;
        }

        public IValue<int> Decorated { get; set; }
    }
}