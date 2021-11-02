using NUnit.Framework;

namespace DecoratorsDemo
{
    public class ModifyDecoratorTest
    {
        private IntAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new IntAttribute();
        }

        [Test]
        public void TestModify()
        {
            _attribute.Value = 10;
            var modify = new ModifyDecorator(-1);
            _attribute.AddDecorator(modify);
            Assert.AreEqual(9, _attribute.Value);

            modify.Delta = 1;
            Assert.AreEqual(11, _attribute.Value);

            _attribute.RemoveDecorator(modify);
            Assert.AreEqual(10, _attribute.Value);
        }
    }
}