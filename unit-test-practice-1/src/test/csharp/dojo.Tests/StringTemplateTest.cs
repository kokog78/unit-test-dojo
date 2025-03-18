namespace Dojo.Tests;

using NUnit.Framework;
using System.Globalization;
using Dojo;
using FluentAssertions;

public class StringTemplateTest
{
    private StringTemplate template;

    [SetUp]
    public void SetUp()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("hu-HU");
        template = new StringTemplate();
    }

    [Test]
    public void Render_should_return_null_if_pattern_is_null()
    {
        string? result = template.Render(null);
        result.Should().BeNull();
    }

    [Test]
    public void Render_should_return_pattern_without_parameters()
    {
        string? result = template.Render("pattern");
        result.Should().Be("pattern");
    }

    [Test]
    public void Render_should_include_empty_string_for_null()
    {
        string? result = template.Render("pattern ${0}", (object?) null);
        result.Should().Be("pattern ");
    }

    [Test]
    public void Render_should_include_formatted_double()
    {
        string? result1 = template.Render("pattern ${0}", 0.1);
        string? result2 = template.Render("pattern ${0}", 123456.12);
        result1.Should().Be("pattern 0,10");
        result2.Should().Be("pattern 123456,12");
    }

    [Test]
    public void Render_should_include_formatted_float()
    {
        string? result1 = template.Render("pattern ${0}", 0.1f);
        string? result2 = template.Render("pattern ${0}", 123456.12f);
        result1.Should().Be("pattern 0,10");
        result2.Should().Be("pattern 123456,12");
    }

    [Test]
    public void Render_should_include_formatted_decimal()
    {
        string? result1 = template.Render("pattern ${0}", new decimal(0.1));
        string? result2 = template.Render("pattern ${0}", new decimal(123456.12));
        result1.Should().Be("pattern 0,10");
        result2.Should().Be("pattern 123456,12");
    }

    [Test]
    public void Render_should_include_integer()
    {
        string? result = template.Render("pattern ${0}", 123456);
        result.Should().Be("pattern 123456");
    }

    [Test]
    public void Render_should_include_formatted_date()
    {
        var calendar = new DateTime(2001, 1, 10, 19, 32, 18, 23);
        string? result = template.Render("pattern ${0}", calendar);
        result.Should().Be("pattern 2001-01-10 19:32:18");
    }

    [Test]
    public void Render_should_include_formatted_calendar()
    {
        var calendar = new DateTime(2001, 1, 10, 19, 32, 18, 23);
        string? result = template.Render("pattern ${0}", calendar);
        result.Should().Be("pattern 2001-01-10 19:32:18");
    }

    [Test]
    public void Render_should_include_to_string_for_object()
    {
        var obj = new System.Text.StringBuilder();
        obj.Append("string value");
        string? result = template.Render("pattern ${0}", obj);
        result.Should().Be("pattern string value");
    }

    [Test]
    public void Render_should_include_multiple_parameters()
    {
        string? result = template.Render("pattern ${0} ${1} ${2} ${3}", 12, 5.2, "test", true);
        result.Should().Be("pattern 12 5,20 test True");
    }

    [Test]
    public void Render_should_skip_unused_and_unspecified_parameters()
    {
        string? result = template.Render("pattern ${0} ${2} ${3}", 12, 5.2, "test");
        result.Should().Be("pattern 12 test ${3}");
    }
}