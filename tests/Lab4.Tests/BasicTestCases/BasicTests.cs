using ObjectOrientedProgramming.Lab4.ConsoleParser;
using ObjectOrientedProgramming.Lab4.CustomExceptions;
using Xunit;

namespace ObjectOrientedProgramming.Lab4.Tests.BasicTestCases;

public class BasicTests
{
    [Fact]
    public void TestParsingConnectCommand()
    {
        var parser = new Parser("-", "*", "     ");
        string? result = parser.Parse();
        Assert.Equal("noting added", result);
    }

    [Fact]
    public void TestParsingCommandKeyException()
    {
        var parser = new Parser("-", "*", "     ");
        try
        {
            parser.Parse("connect V:\\SoftwareEngineering\\C# -k local");
            Assert.Fail();
        }
        catch (InvalidKeyException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void TestParsingCommandModeException()
    {
        var parser = new Parser("-", "*", "     ");
        try
        {
            parser.Parse("connect V:\\SoftwareEngineering\\C# -m google");
            Assert.Fail();
        }
        catch (InvalidModeException)
        {
            Assert.True(true);
        }
    }
}