using Basalt.CommandParser.Attributes;
using System;

namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Gray;

        var testArgs = CommandParser.ProcessArguments<NewTestArguments>(args);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"DebugMode: {testArgs.DebugMode}");
        Console.WriteLine($"MaxPlayers: {testArgs.MaxPlayers}");
        Console.WriteLine($"TriforceMode: {testArgs.TriforceMode}");
        Console.WriteLine($"UpdateTime: {testArgs.UpdateTime}");
        Console.WriteLine($"OutputPath: {testArgs.OutputPath}");
        Console.WriteLine($"Configuration: {testArgs.Configuration}");
        //Console.WriteLine($"DesktopSetup: {testArgs.DesktopSetup}");
    }
}

public class NewTestArguments : ProgramArguments
{
    [BooleanArgument("debug", "d", "Run in debug mode")]
    public bool DebugMode { get; set; }

    [IntegerArgument("max-players", "mp", "The maximum number of players on the server")]
    public int MaxPlayers { get; set; }

    [BooleanArgument("trimode", "tm", "Some sort of secret mode")]
    public bool TriforceMode { get; set; }

    [FloatArgument("update-ms", "u", "The milliseconds in between data reads")]
    public float UpdateTime { get; set; }

    [StringArgument("output", "o", "The file path to write the build file to")]
    public string OutputPath { get; set; }

    [StringArgument("configuration", "c", "The config type that should be used")]
    public string Configuration { get; set; }

    //[NewStringArgument("new-prop-x", "p", "A test property")]
    //public string NewProp { get; set; }

    //[NewBooleanArgument("desktop", "d", "Set up as a desktop")]
    //public bool DesktopSetup { get; set; }
}
