namespace DecoratorsDemo
{
    public class IntAttribute
    {
        private IValue<int> _value = new RootValue<int>(0);

        public IntAttribute()
        {
        }
        
        public int Value
        {
            get => _value.Value;
            set => _value.Value = value;
        }

        public IDecorator<int> AddDecorator(IDecorator<int> decorator)
        {
            decorator.Decorated = _value;
            _value = decorator;
            return decorator;
        }
    }
}