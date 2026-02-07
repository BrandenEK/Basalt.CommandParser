
namespace Basalt.CommandParser.Exceptions;

internal class InvalidParameterException : ArgumentProcessingException
{
    public InvalidParameterException(string argument, string condition) : base($"{argument} must be {condition}", false) { }
}
