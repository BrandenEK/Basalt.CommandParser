using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class ProcessingTests
{
    private void ValidateSuccess(string[] args, Func<TestArguments, bool> isValid)
    {
        var data = new TestArguments();
        data.Process(args);

        Assert.IsTrue(isValid(data));
    }

    private void ValidateFailure<TException>(string[] args) where TException : ArgumentProcessingException
    {
        var data = new TestArguments();

        Assert.ThrowsException<TException>(() => data.Process(args));
    }

    [TestMethod]
    public void Test_NoArgs()
    {
        ValidateSuccess(new string[] { }, data => true);
    }

    [TestMethod]
    public void Test_BoolArgs_Nothing()
    {
        ValidateSuccess(new string[] { }, data => !data.Boolean);
    }

    [TestMethod]
    public void Test_BoolArgs_Short()
    {
        ValidateSuccess(new string[] { "-b" }, data => data.Boolean);
    }

    [TestMethod]
    public void Test_BoolArgs_Long()
    {
        ValidateSuccess(new string[] { "--bool" }, data => data.Boolean);
    }

    [TestMethod]
    public void Test_BoolArgs_True()
    {
        ValidateSuccess(new string[] { "-b", "true" }, data => data.Boolean);
    }

    [TestMethod]
    public void Test_BoolArgs_False()
    {
        ValidateSuccess(new string[] { "-b", "FALSE" }, data => !data.Boolean);
    }

    [TestMethod]
    public void Test_BoolArgs_Invalid()
    {
        ValidateFailure<InvalidParameterException>(new string[] { "-b", "invalid" });
    }
}
