using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser.Tests;

public class NoArguments : ProgramArguments
{

}

public class HelpLongArguments : ProgramArguments
{
    [StringArgument("help", "s", "desc")]
    public string Help { get; set; }
}

public class HelpShortArguments : ProgramArguments
{
    [StringArgument("long", "h", "desc")]
    public string Help { get; set; }
}

public class DuplicateArguments : ProgramArguments
{
    [IntegerArgument("longname", "a", "desc")]
    public int A { get; set; }

    [IntegerArgument("longname", "b", "desc")]
    public int B { get; set; }
}

// Mismatched property type

// Invalid names
