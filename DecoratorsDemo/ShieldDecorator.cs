using System;

namespace DecoratorsDemo
{
        public class ShieldDecorator : IDecorator<int>
        {
            private readonly int _protection;

            public ShieldDecorator(int protection)
            {
                _protection = protection;
            }
        
            public int Value { get => Decorated.Value;
                set
                {
                    var currentValue = Decorated.Value;
                    var delta = value - currentValue;
                    if (delta < 0)
                    {
                        Decorated.Value = Math.Min(value + _protection, currentValue);
                    }
                    else
                    {
                        Decorated.Value = value;
                    }
                }
            }

            public IValue<int> Decorated { get; set; }
        }
}