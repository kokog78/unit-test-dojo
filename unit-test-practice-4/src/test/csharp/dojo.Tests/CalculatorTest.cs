namespace dojo.Tests;

public class Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator calculator = new Calculator();

        [Test]
        public void Should_throw_exception_for_null_input()
        {
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null));
        }

        [Test]
        public void Should_throw_exception_for_empty_string()
        {
            Assert.Throws<ArgumentException>(() => calculator.Calculate(""));
        }

        [Test]
        public void Should_throw_exception_for_input_with_only_spaces()
        {
            Assert.Throws<ArgumentException>(() => calculator.Calculate(" \t\n"));
        }

        [Test]
        public void Should_throw_exception_for_non_numeric_input()
        {
            Assert.Throws<FormatException>(() => calculator.Calculate("a"));
        }

        [Test]
        public void Should_return_the_only_integer_input()
        {
            int result = calculator.Calculate("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should_add_two_integers()
        {
            int result = calculator.Calculate("1+2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Should_add_three_integers()
        {
            int result = calculator.Calculate("1+2+3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Should_add_multiple_integers()
        {
            int result = calculator.Calculate("1+2+3+4+5+6");
            Assert.AreEqual(21, result);
        }

        [Test]
        public void Should_skip_spaces_between_numbers()
        {
            int result = calculator.Calculate("1 + 2\n+ 3\t+ 4");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Should_handle_leading_plus_sign()
        {
            int result = calculator.Calculate("+1 + 2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Should_handle_leading_minus_sign()
        {
            int result = calculator.Calculate("-1 + 2");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should_handle_leading_plus_and_minus_sign()
        {
            int result = calculator.Calculate("-1 + +2");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Should_do_subtraction()
        {
            int result = calculator.Calculate("1 - 2");
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Should_handle_negative_number()
        {
            int result = calculator.Calculate("1 + -2-1");
            Assert.AreEqual(-2, result);
        }
    }
}
