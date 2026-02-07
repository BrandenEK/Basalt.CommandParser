
using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        CommandParser.Parse<TestArguments>(args);
        Console.ReadKey(true);
    }
}

public class TestArguments : BaseArguments
{
    [NewBooleanArgument("debug", "d")]
    public bool DebugMode { get; set; }

    [NewBooleanArgument("trimode", "tm")]
    public bool TriforceMode { get; set; }

    [NewStringArgument("output", "o")]
    public bool OutputPath { get; set; }

    [NewStringArgument("configuration", "c")]
    public string Configuration { get; set; }
}
