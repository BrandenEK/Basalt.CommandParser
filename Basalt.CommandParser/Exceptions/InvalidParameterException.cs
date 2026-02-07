
namespace Basalt.CommandParser.Exceptions;

public class InvalidParameterException : ArgumentProcessingException
{
    public InvalidParameterException(string argument, string condition) : base($"{argument} must be {condition}", false) { }
}
