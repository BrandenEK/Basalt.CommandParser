
namespace Basalt.CommandParser.Exceptions;

public class MissingParameterException : ArgumentProcessingException
{
    public MissingParameterException(string argument) : base($"error: a value is required for {argument}", false) { }
}
