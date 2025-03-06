using NUnit.Framework;
using System;

namespace dojo.Tests
{
    [TestFixture]
    public class ParserTestDone
    {
        private Parser parser;

        [SetUp]
        public void Setup()
        {
            parser = new Parser();
        }

        [Test]
        public void Parse_should_return_empty_array_when_input_is_empty()
        {
            string[] result = parser.Parse("");
            Assert.That(result, Is.EqualTo(new string[3]));
        }

        [Test]
        public void Parse_sould_handle_whitespace_correctly()
        {
            string[] result = parser.Parse("   \t  ");
            Assert.That(result, Is.EqualTo(new string[3]));
        }

        [Test]
        public void Parse_should_split_words_correctly()
        {
            string[] result = parser.Parse("hello world");
            Assert.That(result[0], Is.EqualTo("hello"));
            Assert.That(result[2], Is.EqualTo("world"));
        }

        [Test]
        public void Parse_should_recognize_numbers_as_category_zero()
        {
            string[] result = parser.Parse("1234 test");
            Assert.That(result[0], Is.EqualTo("1234"));
            Assert.That(result[2], Is.EqualTo("test"));
        }

        [Test]
        public void Lookup_should_return_zero_for_four_digit_numbers()
        {
            int category = parser.GetType()
                                 .GetMethod("Lookup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                 .Invoke(parser, new object[] { "1234" }) as int? ?? -1;
            Assert.That(category, Is.EqualTo(0));
        }

        [Test]
        public void Lookup_should_return_two_for_unknown_strings()
        {
            int category = parser.GetType()
                                 .GetMethod("Lookup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                 .Invoke(parser, new object[] { "unknown" }) as int? ?? -1;
            Assert.That(category, Is.EqualTo(2));
        }

        /*
        [Test]
        public void Is_there_should_return_false_when_resource_file_is_missing()
        {
            var mockParser = new Mock<Parser>();
            mockParser.Setup(p => p.IsThere(It.IsAny<string>())).Returns(false);
            bool result = mockParser.Object.IsThere("nonexistent");
            Assert.That(result, Is.False);
        }
        */
    }
}
