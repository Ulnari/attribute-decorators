namespace DecoratorsDemo
{
    public interface IDecorator<T> : IValue<T>
    {
        IValue<T> Decorated { get; set; }
    }
}