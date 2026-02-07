using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser.Tests;

public class TestArguments : ProgramArguments
{
    [StringArgument("string", "s", "desc")]
    public string String { get; set; } = string.Empty;

    [BooleanArgument("bool", "b", "desc")]
    public bool Boolean { get; set; } = false;

    [IntegerArgument("int", "i", "desc")]
    public int Integer { get; set; } = 0;

    [FloatArgument("float", "f", "desc")]
    public float Float { get; set; } = 0f;
}
