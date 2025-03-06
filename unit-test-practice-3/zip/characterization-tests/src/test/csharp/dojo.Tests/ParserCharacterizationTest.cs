using NUnit.Framework;
using System;

namespace dojo.Tests
{
    [TestFixture]
    public class ParserCharacterizationTest
    {
        private Parser parser = new Parser();

        [Test]
        public void Test_Good_Address()
        {
            Test("2040 Budaörs Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
            Test("Budaörs 2040 Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
            Test("Valami utca 5. Budaörs 2040", "2040", "Budaörs", "Valami utca 5.");
            Test("Valami utca 5. 2040 Budaörs", "2040", "Budaörs", "Valami utca 5.");
        }

        [Test]
        public void Test_Bad_Address()
        {
            Test("Valami 2040 Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
            Test("Valami 2040 utca 5. Budaörs", "2040", "Budaörs", "Valami utca 5.");
            Test("Valami Budaörs utca 5. 2040", "2040", "Budaörs", "Valami utca 5.");
            Test("Budaörs Valami 2040 utca 5.", "2040", "Budaörs", "Valami utca 5.");
            Test("2040 Valami Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
        }

        [Test]
        public void Test_Duplicated_Parts()
        {
            Test("2040 Budaörs Valami utca 2040", "2040", "Budaörs", "Valami utca 2040");
            Test("2040 Budaörs 2040 Valami utca", "2040", "Budaörs", "2040 Valami utca");
            Test("Budaörs 2040 Budaörs utca 5.", "2040", "Budaörs", "Budaörs utca 5.");
            Test("Budaörs Budaörs utca 5. 2040", "2040", "Budaörs", "Budaörs utca 5.");
            Test("Budaörs Kis Budaörs utca 5. 2040", "2040", "Budaörs", "Kis Budaörs utca 5.");
        }

        [Test]
        public void Test_Numbers()
        {
            Test("123 1234", "1234", null, "123");
            Test("1234 123", "1234", null, "123");
        }

        [Test]
        public void Test_Address_With_Whitespace()
        {
            Test(" 2040", "2040", null, null);
            Test("\t2040", "2040", null, null);
            Test("\n2040", "2040", null, null);
            Test("\r2040", "2040", null, null);
            Test("2040 ", "2040", null, null);
            Test("2040\t", "2040", null, null);
            Test("2040\n", "2040", null, null);
            Test("2040\r", "2040", null, null);
        }

        private void Test(string input, params string[] expectedResult)
        {
            string[] result = parser.Parse(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
