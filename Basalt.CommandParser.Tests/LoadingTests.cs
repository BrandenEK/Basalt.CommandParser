using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class LoadingTests
{
    private readonly string[] _args = Array.Empty<string>();

    private void ValidateSuccess(ProgramArguments data, string[] args)
    {
        data.Process(args);
    }

    private void ValidateFailure(ProgramArguments data, string[] args)
    {
        Assert.ThrowsException<ArgumentLoadingException>(() => data.Process(args));
    }

    [TestMethod]
    public void Test_NoArgs()
    {
        ValidateFailure(new NoArguments(), _args);
    }

    [TestMethod]
    public void Test_HelpLongArgs()
    {
        ValidateFailure(new HelpLongArguments(), _args);
    }

    [TestMethod]
    public void Test_HelpShortArgs()
    {
        ValidateFailure(new HelpShortArguments(), _args);
    }

    [TestMethod]
    public void Test_DuplicateArgs()
    {
        ValidateFailure(new DuplicateArguments(), _args);
    }

    [TestMethod]
    public void Test_WrongTypeArgs()
    {
        ValidateFailure(new WrongTypeArguments(), _args);
    }

    [TestMethod]
    public void Test_ValidArgs()
    {
        ValidateSuccess(new ValidArguments(), _args);
    }
}
