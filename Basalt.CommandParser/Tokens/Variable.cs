
namespace Basalt.CommandParser.Tokens;

public class Variable(string content) : Token
{
    public string Content { get; } = content;
}
