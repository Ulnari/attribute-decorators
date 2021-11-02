namespace DecoratorsDemo
{
    public sealed class RootValue<T> : IValue<T>
    {
        public RootValue(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public IValue<T> Root => this;
    }
}