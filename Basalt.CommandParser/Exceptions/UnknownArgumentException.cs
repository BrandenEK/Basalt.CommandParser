
namespace Basalt.CommandParser.Exceptions;

public class UnknownArgumentException : ArgumentProcessingException
{
    public UnknownArgumentException(string argument) : base($"error: unknown argument '{argument}'", true) { }
}
