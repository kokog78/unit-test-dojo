using NUnit.Framework;
using System;

namespace dojo
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void ShouldDoSomething()
        {
            stringresult = new string{ "a", "a", "b" };

            // Asszertálás példák:
            Assert.AreEqual(new string{ "a", "a", "b" }, result);
            Assert.AreEqual(3, result.Length);
            CollectionAssert.AreEquivalent(new string{ "b", "a" }, result);
            Assert.AreEqual("a", result[0]);
            Assert.IsNotNull(result[1]);

            // Asszertálás kivételre:
            Assert.Throws<NullPointerException>(() =>
            {
                throw new NullPointerException();
            });
        }
    }
}