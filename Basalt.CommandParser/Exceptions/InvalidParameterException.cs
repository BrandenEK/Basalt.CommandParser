
namespace Basalt.CommandParser.Exceptions;

public class InvalidParameterException : ArgumentProcessingException
{
    public InvalidParameterException(string argument, string condition) : base($"error: {argument} must be {condition}", false) { }
}
