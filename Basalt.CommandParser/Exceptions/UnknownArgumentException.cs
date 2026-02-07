
namespace Basalt.CommandParser.Exceptions;

public class UnknownArgumentException : ArgumentProcessingException
{
    public UnknownArgumentException(string argument) : base($"unknown argument '{argument}'", true) { }
}
