namespace dojo.Tests;

using NUnit.Framework;
using System.Globalization;
using dojo;

[TestFixture]
public class ComparableVersionsTestDone
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

    [Test]
    public void Compare_to_should_return_zero_for_equal_versions()
    {
        var version1 = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        var version2 = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        
        Assert.That(version1.CompareTo(version2), Is.EqualTo(0));
    }

    [Test]
    public void Compare_to_should_return_negative_for_lower_version()
    {
        var lowerVersion = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        var higherVersion = new dojo.ComperableVersions.ComparableVersion("1.2.4");
        
        Assert.That(lowerVersion.CompareTo(higherVersion), Is.LessThan(0));
    }

    [Test]
    public void Compare_to_should_return_positive_for_higher_version()
    {
        var higherVersion = new dojo.ComperableVersions.ComparableVersion("2.0.0");
        var lowerVersion = new dojo.ComperableVersions.ComparableVersion("1.9.9");
        
        Assert.That(higherVersion.CompareTo(lowerVersion), Is.GreaterThan(0));
    }

    [Test]
    public void Is_enabled_should_return_false_by_default()
    {
        var version = new dojo.ComperableVersions.ComparableVersion("1.0.0");
        
        Assert.That(version.IsEnabled(), Is.False);
    }

    [Test]
    public void Set_enabled_should_enable_version()
    {
        var version = new dojo.ComperableVersions.ComparableVersion("1.0.0");
        version.SetEnabled(true);
        
        Assert.That(version.IsEnabled(), Is.True);
    }

    [Test]
    public void Set_enabled_should_disable_version()
    {
        var version = new dojo.ComperableVersions.ComparableVersion("1.0.0");
        version.SetEnabled(true);
        version.SetEnabled(false);
        
        Assert.That(version.IsEnabled(), Is.False);
    }

    [Test]
    public void Equals_should_return_true_for_equal_versions()
    {
        var version1 = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        var version2 = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        
        Assert.That(version1.Equals(version2), Is.True);
    }

    [Test]
    public void Equals_should_return_false_for_different_versions()
    {
        var version1 = new dojo.ComperableVersions.ComparableVersion("1.2.3");
        var version2 = new dojo.ComperableVersions.ComparableVersion("1.2.4");
        
        Assert.That(version1.Equals(version2), Is.False);
    }
}