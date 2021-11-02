namespace DecoratorsDemo
{
    public class IntAttribute
    {
        private IValue<int> _value = new RootValue<int>(0);

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

        public bool RemoveDecorator(IDecorator<int> decorator)
        {
            IDecorator<int> previous = null;
            var next = _value;

            while (next is IDecorator<int> current)
            {
                next = current.Decorated;

                if (current == decorator)
                {
                    if (previous != null) previous.Decorated = next;
                    else _value = next;
                    return true;
                }

                previous = current;
            }

            return false;
        }
    }
}