
namespace CommandParser;

public class TestCommand : CommandData
{
    public TestCommand() : base()
    {
        //AddCommand(new StringCommand("n", "name", x => Name = x));
        //AddCommand(new StringCommand("t", "token", x => Token = x));
        //AddCommand(new BoolCommand("e", "encrypt", x => UseEncryption = x));
        //AddCommand(new BoolCommand("aa", "auto-add", x => AutomaticallyAdd = x));
        //AddCommand(new IntCommand("sd", "seach-delay", x => SearchDelay = x));
    }

    [StringArgument('n', "name")]
    public string Name { get; set; } = string.Empty;

    [StringArgument('t', "token")]
    public string Token { get; set; } = string.Empty;

    [BooleanArgument('e', "encrypt")]
    public bool UseEncryption { get; set; }

    [BooleanArgument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; }

    [IntegerArgument('d', "delay")]
    public int SearchDelay { get; set; }
}
