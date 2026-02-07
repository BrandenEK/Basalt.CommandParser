using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

public class ProcessingTests
{
    private protected void ValidateSuccess(string[] args, Func<TestArguments, bool> isValid)
    {
        var data = new TestArguments();
        data.Process(args);

        Assert.IsTrue(isValid(data));
    }

    private protected void ValidateFailure<TException>(string[] args) where TException : ArgumentProcessingException
    {
        var data = new TestArguments();

        Assert.ThrowsException<TException>(() => data.Process(args));
    }
}
