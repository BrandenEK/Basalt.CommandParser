
namespace CommandParser;

public class TestArgument : ArgumentData
{
    public string Name { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public bool UseEncryption { get; set; }

    public bool AutomaticallyAdd { get; set; }

    public int SearchDelay { get; set; }
}
