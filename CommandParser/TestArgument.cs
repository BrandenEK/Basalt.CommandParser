
namespace CommandParser;

public class TestArgument : ArgumentData
{
    public TestArgument() : base()
    {
        //AddCommand(new StringCommand("n", "name", x => Name = x));
        //AddCommand(new StringCommand("t", "token", x => Token = x));
        //AddCommand(new BoolCommand("e", "encrypt", x => UseEncryption = x));
        //AddCommand(new BoolCommand("aa", "auto-add", x => AutomaticallyAdd = x));
        //AddCommand(new IntCommand("sd", "seach-delay", x => SearchDelay = x));
    }

    [Argument('n', "name")]
    public string Name { get; set; } = string.Empty;

    [Argument('t', "token")]
    public string Token { get; set; } = string.Empty;

    [Argument('e', "encrypt")]
    public bool UseEncryption { get; set; }

    [Argument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; }

    [Argument('d', "delay")]
    public int SearchDelay { get; set; }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class ArgumentAttribute : Attribute
{
    public ArgumentAttribute(char initial, string name)
    {
        Initial = initial;
        Name = name;
    }

    public char Initial { get; set; }

    public string Name { get; set; }
}
