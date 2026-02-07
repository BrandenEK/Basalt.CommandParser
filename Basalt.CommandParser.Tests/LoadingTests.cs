using Basalt.CommandParser.Exceptions;

namespace Basalt.CommandParser.Tests;

[TestClass]
public class LoadingTests
{
    private readonly string[] _args = Array.Empty<string>();
    //private ProgramArguments _none;

    //[TestInitialize]
    //public void Setup_Arguments()
    //{
    //    _none = new NoArguments();
    //}

    private void ProcessArguments<TArgs>(string[] args) where TArgs : ProgramArguments, new()
    {
        var data = new TArgs();

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

    //[DataTestMethod]
    //[DataRow(_none, new string[] { })]
    //public void Test_LoadingArguments(ProgramArguments data, string[] args)
    //{
    //    Assert.ThrowsException<ArgumentLoadingException>(() => data.Process(args));
    //}
}

public class NoArguments : ProgramArguments
{

}
