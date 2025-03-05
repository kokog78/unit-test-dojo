namespace dojo.Tests;

[TestFixture]
public class ParserTest
{
    [Test]
    public void ShouldDoSomething()
    {
        string[] result = { "a", "a", "b" };

        // Új aszszertálások a constraint model szerint:
        Assert.That(result, Is.EqualTo(new string[] { "a", "a", "b" }));
        Assert.That(result.Length, Is.EqualTo(3));
        Assert.That(result, Is.EquivalentTo(new string[] { "b", "a" }));
        Assert.That(result[0], Is.EqualTo("a"));
        Assert.That(result[1], Is.Not.Null);

        // Asszertálás kivételre:
        Assert.That(() => throw new NullReferenceException(), Throws.TypeOf<NullReferenceException>());
    }
}
