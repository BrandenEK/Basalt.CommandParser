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

public class WrongTypeArguments : ProgramArguments
{
    [StringArgument("long", "s", "desc")]
    public int A { get; set; }
}

// Invalid names

public class ValidArguments : ProgramArguments
{
    [StringArgument("string", "ss", "desc")]
    public string String { get; set; }

    [BooleanArgument("bool", "bb", "desc")]
    public bool Boolean { get; set; }

    [IntegerArgument("int", "i", "desc")]
    public int Integer { get; set; }

    [FloatArgument("float", "f", "desc")]
    public float Float { get; set; }
}
