
namespace CommandParser;

public class TestCommand : CommandData
{
    [StringArgument('n', "name")]
    public string Name { get; set; } = "Default name";

    [StringArgument('t', "token")]
    public string Token { get; set; } = string.Empty;

    [BooleanArgument('e', "encrypt")]
    public bool UseEncryption { get; set; }

    [BooleanArgument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; } = true;

    [IntegerArgument('d', "delay")]
    public int SearchDelay { get; set; }
}
