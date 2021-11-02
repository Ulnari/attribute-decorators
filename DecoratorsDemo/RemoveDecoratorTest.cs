using NUnit.Framework;

namespace DecoratorsDemo
{
    public class RemoveDecoratorTest
    {
        private IntAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new IntAttribute();
        }

        [Test]
        public void TestRemoveTop()
        {
            _attribute.Value = 10;
            var modify = new ModifyDecorator(1);
            _attribute.AddDecorator(modify);
            Assert.AreEqual(11, _attribute.Value);

            Assert.IsTrue(_attribute.RemoveDecorator(modify));
            Assert.AreEqual(10, _attribute.Value);
        }

        [Test]
        public void TestRemoveBottom()
        {
            _attribute.Value = 10;
            var modify = new ModifyDecorator(1);
            _attribute.AddDecorator(modify);
            _attribute.AddDecorator(new ModifyDecorator(1));

            Assert.AreEqual(12, _attribute.Value);

            Assert.IsTrue(_attribute.RemoveDecorator(modify));
            Assert.AreEqual(11, _attribute.Value);
        }

        [Test]
        public void TestRemoveMiddle()
        {
            _attribute.Value = 10;
            _attribute.AddDecorator(new ModifyDecorator(1));
            var modify = new ModifyDecorator(1);
            _attribute.AddDecorator(modify);
            _attribute.AddDecorator(new ModifyDecorator(1));

            Assert.AreEqual(13, _attribute.Value);

            Assert.IsTrue(_attribute.RemoveDecorator(modify));
            Assert.AreEqual(12, _attribute.Value);
        }

        [Test]
        public void TestRemoveNonExisting()
        {
            _attribute.Value = 10;
            var modify = new ModifyDecorator(1);
            _attribute.AddDecorator(modify);

            Assert.IsTrue(_attribute.RemoveDecorator(modify));
            Assert.IsFalse(_attribute.RemoveDecorator(modify));
            Assert.AreEqual(10, _attribute.Value);
        }
    }
}