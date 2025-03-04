using NUnit.Framework;
using System;

namespace dojo
{
    [TestFixture]
    public class ComparableVersionTest
    {
        [Test]
        public void ShouldDoSomething()
        {
            int result = 12;

            // Asszertálás példák:
            Assert.AreEqual(12, result);
            Assert.IsTrue(result > 0);
            Assert.IsTrue(result >= 0);
            Assert.IsTrue(result != 0);

            // Asszertálás kivételre:
            Assert.Throws<NullPointerException>(() =>
            {
                throw new NullPointerException();
            });
        }
    }
}