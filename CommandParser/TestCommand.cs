
namespace CommandParser;

public class TestCommand : CommandData
{
    [StringArgument('n', "name", "Default name")]
    public string Name { get; set; }

    [StringArgument('t', "token")]
    public string? Token { get; set; }

    [BooleanArgument('e', "encrypt", true)]
    public bool UseEncryption { get; set; }

    [BooleanArgument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; }

    [IntegerArgument('d', "delay")]
    public int SearchDelay { get; set; }
}
