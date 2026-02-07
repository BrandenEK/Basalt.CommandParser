
using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        CommandParser.Parse<TestArguments>(args);
        //Console.ReadKey(true);
    }
}

public class TestArguments : BaseArguments
{
    [NewBooleanArgument("debug", "d", "Run in debug mode")]
    public bool DebugMode { get; set; }

    [NewBooleanArgument("trimode", "tm", "Some sort of secret mode")]
    public bool TriforceMode { get; set; }

    [NewStringArgument("output", "o", "The file path to write the build file to")]
    public bool OutputPath { get; set; }

    [NewStringArgument("configuration", "c", "The config type that should be used")]
    public string Configuration { get; set; }
}
