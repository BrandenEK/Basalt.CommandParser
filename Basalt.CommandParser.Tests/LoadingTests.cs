
namespace Basalt.CommandParser.Tests;

[TestClass]
public class LoadingTests
{
    [TestMethod]
    public void Test_NoArgs()
    {
        string[] args = { };

        var data = new NoArguments();
        data.Process(args);

        //CommandParser.ProcessArguments<NoArguments>(args);
    }
}

public class NoArguments : ProgramArguments
{

}
