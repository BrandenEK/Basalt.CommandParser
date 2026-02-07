using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        var testArgs = CommandParser.Parse<TestArguments>(args);
        //Console.ReadKey(true);

        
    }
}

public class TestArguments : BaseArguments
{
    [NewBooleanArgument("debug", "d", "debug mode", "Run in debug mode")]
    public bool DebugMode { get; set; }

    [NewBooleanArgument("trimode", "tm", "triforce mode", "Some sort of secret mode")]
    public bool TriforceMode { get; set; }

    [NewStringArgument("output", "o", "output path", "The file path to write the build file to")]
    public bool OutputPath { get; set; }

    [NewStringArgument("configuration", "c", "configuration", "The config type that should be used")]
    public string Configuration { get; set; }
}
