
namespace CommandParser;

public class TestArgument : ArgumentData
{
    public TestArgument() : base()
    {
        AddValidArgument(new Argument("n", "name", x => Name = x));
        AddValidArgument(new Argument("t", "token", x => Token = x));
        AddValidArgument(new Argument("e", "encrypt", x => UseEncryption = bool.Parse(x)));
        AddValidArgument(new Argument("aa", "auto-add", x => AutomaticallyAdd = bool.Parse(x)));
        AddValidArgument(new Argument("sd", "seach-delay", x => SearchDelay = int.Parse(x)));
    }

    public string Name { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public bool UseEncryption { get; set; }

    public bool AutomaticallyAdd { get; set; }

    public int SearchDelay { get; set; }
}
