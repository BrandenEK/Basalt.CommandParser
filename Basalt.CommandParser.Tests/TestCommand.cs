
namespace Basalt.CommandParser.Tests;

public class TestCommand : CommandData
{
    [StringArgument('n', "name")]
    public string Name { get; set; } = "Default name";

    [StringArgument('t', "token")]
    public string Token { get; set; } = string.Empty;

    [BooleanArgument('e', "encrypt")]
    public bool UseEncryption { get; set; } = false;

    [BooleanArgument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; } = true;

    [IntegerArgument('d', "delay")]
    public int SearchDelay { get; set; } = 100;

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj is not TestCommand cmd)
            return false;

        return Name == cmd.Name
            && Token == cmd.Token
            && UseEncryption == cmd.UseEncryption
            && AutomaticallyAdd == cmd.AutomaticallyAdd
            && SearchDelay == cmd.SearchDelay;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
