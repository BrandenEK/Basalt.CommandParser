using Basalt.CommandParser.Attributes;
using System;

namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        var testArgs = CommandParser.Parse<TestArguments>(args);
        //Console.ReadKey(true);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"DebugMode: {testArgs.DebugMode}");
        Console.WriteLine($"MaxPlayers: {testArgs.MaxPlayers}");
        Console.WriteLine($"TriforceMode: {testArgs.TriforceMode}");
        Console.WriteLine($"UpdateTime: {testArgs.UpdateTime}");
        Console.WriteLine($"OutputPath: {testArgs.OutputPath}");
        Console.WriteLine($"Configuration: {testArgs.Configuration}");
    }
}

public class TestArguments : BaseArguments
{
    [NewBooleanArgument("debug", "d", "Run in debug mode")]
    public bool DebugMode { get; set; }

    [NewIntegerArgument("max-players", "mp", "The maximum number of players on the server")]
    public int MaxPlayers { get; set; }

    [NewBooleanArgument("trimode", "tm", "Some sort of secret mode")]
    public bool TriforceMode { get; set; }

    [FloatArgument("update-ms", "u", "The milliseconds in between data reads")]
    public float UpdateTime { get; set; }

    [NewStringArgument("output", "o", "The file path to write the build file to")]
    public string OutputPath { get; set; }

    [NewStringArgument("configuration", "c", "The config type that should be used")]
    public string Configuration { get; set; }
}
