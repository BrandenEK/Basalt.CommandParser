using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class ProcessingStringTests : ProcessingTests
{
    [TestMethod]
    public void Test_StringArgs_Nothing()
    {
        ValidateSuccess(new string[] { }, data => data.String == string.Empty);
    }

    [TestMethod]
    public void Test_StringArgs_Missing()
    {
        ValidateFailure<MissingParameterException>(new string[] { "-s" });
    }

    [TestMethod]
    public void Test_StringArgs_Short()
    {
        ValidateSuccess(new string[] { "-s", "value" }, data => data.String == "value");
    }

    [TestMethod]
    public void Test_StringArgs_Long()
    {
        ValidateSuccess(new string[] { "--string", "value" }, data => data.String == "value");
    }
}
