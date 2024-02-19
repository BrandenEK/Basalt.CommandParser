
namespace CommandParser;

public class TestArgument : ArgumentData
{
    public TestArgument() : base()
    {
        AddCommand(new StringCommand("n", "name", x => Name = x));
        AddCommand(new StringCommand("t", "token", x => Token = x));
        AddCommand(new BoolCommand("e", "encrypt", x => UseEncryption = x));
        AddCommand(new BoolCommand("aa", "auto-add", x => AutomaticallyAdd = x));
        AddCommand(new IntCommand("sd", "seach-delay", x => SearchDelay = x));
    }

    public string Name { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public bool UseEncryption { get; set; }

    public bool AutomaticallyAdd { get; set; }

    public int SearchDelay { get; set; }
}
