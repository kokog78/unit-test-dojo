using FluentAssertions;
using NUnit.Framework;
using System;
using dojo;

namespace dojo.Tests
{
    [TestFixture]
    public class ComparableVersionsTest
    {
        [Test]
        public void Should_do_something()
        {
            int result = 12;
            result.Should().Be(12);
            result.Should().BeGreaterThan(0);
            result.Should().BeGreaterThanOrEqualTo(0);
            result.Should().NotBe(0);
            
            Action act = () => throw new NullReferenceException();
            act.Should().Throw<NullReferenceException>();
        }
    }
}