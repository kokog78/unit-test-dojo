using NUnit.Framework;
using FluentAssertions;
using System;

namespace Dojo
{
    [TestFixture]
    public class ParserCharacterizationTest
    {
        private Parser parser = new Parser();

        [Test]
        public void Test_GoodAddress()
        {
            TestParser("2040 Budaörs Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Budaörs 2040 Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Valami utca 5. Budaörs 2040", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Valami utca 5. 2040 Budaörs", "2040", "Budaörs", "Valami utca 5.");
        }

        [Test]
        public void Test_BadAddress()
        {
            TestParser("Valami 2040 Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Valami 2040 utca 5. Budaörs", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Valami Budaörs utca 5. 2040", "2040", "Budaörs", "Valami utca 5.");
            TestParser("Budaörs Valami 2040 utca 5.", "2040", "Budaörs", "Valami utca 5.");
            TestParser("2040 Valami Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
        }

        [Test]
        public void Test_DuplicatedParts()
        {
            TestParser("2040 Budaörs Valami utca 2040", "2040", "Budaörs", "Valami utca 2040");
            TestParser("2040 Budaörs 2040 Valami utca", "2040", "Budaörs", "2040 Valami utca");
            TestParser("Budaörs 2040 Budaörs utca 5.", "2040", "Budaörs", "Budaörs utca 5.");
            TestParser("Budaörs Budaörs utca 5. 2040", "2040", "Budaörs", "Budaörs utca 5.");
            TestParser("Budaörs Kis Budaörs utca 5. 2040", "2040", "Budaörs", "Kis Budaörs utca 5.");
        }

        [Test]
        public void Test_Numbers()
        {
            TestParser("123 1234", "1234", null, "123");
            TestParser("1234 123", "1234", null, "123");
        }

        [Test]
        public void Test_AddressWithWhitespace()
        {
            TestParser(" 2040", "2040", null, null);
            TestParser("\t2040", "2040", null, null);
            TestParser("\n2040", "2040", null, null);
            TestParser("\r2040", "2040", null, null);
            TestParser("2040 ", "2040", null, null);
            TestParser("2040\t", "2040", null, null);
            TestParser("2040\n", "2040", null, null);
            TestParser("2040\r", "2040", null, null);
        }

        private void TestParser(string input, params string?[] expectedResult)
        {
            string?[] result = parser.Parse(input);
            result.Should().BeEquivalentTo(expectedResult, options => options.WithStrictOrdering().WithAutoConversion());
        }
    }
}
