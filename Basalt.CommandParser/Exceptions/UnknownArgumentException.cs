
namespace Basalt.CommandParser.Exceptions;

internal class UnknownArgumentException : ArgumentProcessingException
{
    public UnknownArgumentException(string argument) : base($"unknown argument '{argument}'", true) { }
}
