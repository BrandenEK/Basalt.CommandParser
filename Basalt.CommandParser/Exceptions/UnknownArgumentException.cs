
namespace Basalt.CommandParser.Exceptions;

public class UnknownArgumentException(string name) : System.Exception
{
    public string Name { get; } = name;
}
