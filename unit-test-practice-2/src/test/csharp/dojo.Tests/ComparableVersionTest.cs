namespace dojo.Tests;

using NUnit.Framework;
using System.Globalization;
using dojo;

[TestFixture]
public class ComparableVersionsTest
{
    [Test]
    public void Should_do_something()
    {
        int result = 12;

        // Új aszszertálások a constraint model szerint:
        Assert.That(result, Is.EqualTo(12));
        Assert.That(result, Is.GreaterThan(0));
        Assert.That(result, Is.GreaterThanOrEqualTo(0));
        Assert.That(result, Is.Not.EqualTo(0));

        // Asszertálás kivételre:
        Assert.That(() => throw new NullReferenceException(), Throws.TypeOf<NullReferenceException>());
    }
}
