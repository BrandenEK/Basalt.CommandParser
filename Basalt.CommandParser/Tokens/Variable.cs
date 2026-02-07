
namespace Basalt.CommandParser.Tokens;

internal class Variable(string content) : Token
{
    public string Content { get; } = content;
}
