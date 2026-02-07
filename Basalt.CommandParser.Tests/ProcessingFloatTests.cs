using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class ProcessingFloatTests : ProcessingTests
{
    [TestMethod]
    public void Test_FloatArgs_Nothing()
    {
        ValidateSuccess(new string[] { }, data => data.Float == 0);
    }

    [TestMethod]
    public void Test_FloatArgs_Missing()
    {
        ValidateFailure<MissingParameterException>(new string[] { "-f" });
    }

    [TestMethod]
    public void Test_FloatArgs_Short()
    {
        ValidateSuccess(new string[] { "-f", "33.33" }, data => data.Float == 33.33f);
    }

    [TestMethod]
    public void Test_FloatArgs_Long()
    {
        ValidateSuccess(new string[] { "--float", "33.33" }, data => data.Float == 33.33f);
    }

    [TestMethod]
    public void Test_FloatArgs_Invalid()
    {
        ValidateFailure<InvalidParameterException>(new string[] { "-f", "invalid" });
    }
}
