using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class ProcessingIntegerTests : ProcessingTests
{
    [TestMethod]
    public void Test_IntArgs_Nothing()
    {
        ValidateSuccess(new string[] { }, data => data.Integer == 0);
    }

    [TestMethod]
    public void Test_IntArgs_Missing()
    {
        ValidateFailure<MissingParameterException>(new string[] { "-i" });
    }

    [TestMethod]
    public void Test_IntArgs_Short()
    {
        ValidateSuccess(new string[] { "-i", "33" }, data => data.Integer == 33);
    }

    [TestMethod]
    public void Test_IntArgs_Long()
    {
        ValidateSuccess(new string[] { "--int", "33" }, data => data.Integer == 33);
    }

    [TestMethod]
    public void Test_IntArgs_Invalid()
    {
        ValidateFailure<InvalidParameterException>(new string[] { "-i", "invalid" });
    }
}
