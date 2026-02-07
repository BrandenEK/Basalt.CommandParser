using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class LoadingTests
{
    private readonly string[] _args = Array.Empty<string>();

    private void ValidateFailure(ProgramArguments data, string[] args)
    {
        Assert.ThrowsException<ArgumentLoadingException>(() => data.Process(args));
    }

    [TestMethod]
    public void Test_NoArgs()
    {
        ValidateFailure(new NoArguments(), _args);
    }
}

public class NoArguments : ProgramArguments
{

}
