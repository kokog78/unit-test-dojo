namespace dojo.Tests;

using System;
using NUnit.Framework;

public class SnakeCaseTransformerTest
{
    private readonly SnakeCaseTransformer transformer = new SnakeCaseTransformer();

    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(4, 4);
    }
}

