using NUnit.Framework;

namespace DecoratorsDemo
{
    public class DecoratorTests
    {
        private IntAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new IntAttribute();
        }

        [Test]
        public void TestDecrease()
        {
            _attribute.Value = 10;
            var shield = new ShieldDecorator(1);
            _attribute.AddDecorator(shield);

            _attribute.Value = 8;   // reduce value by 2
            Assert.AreEqual(9, _attribute.Value);   // shield protection was 1
        }
        
        [Test]
        public void TestIncrease()
        {
            _attribute.Value = 10;
            var shield = new ShieldDecorator(1);
            _attribute.AddDecorator(shield);

            _attribute.Value = 12;   // increase value by 2
            Assert.AreEqual(12, _attribute.Value);   // shield does not protect against increase
        }

        [Test]
        public void TestDecreaseLowerThanProtection()
        {
            _attribute.Value = 10;
            var shield = new ShieldDecorator(5);    // high protection of 5
            _attribute.AddDecorator(shield);

            _attribute.Value = 9;   // small decrease
            Assert.AreEqual(10, _attribute.Value);   // shield does increase value above initial
        }

        
    }
}