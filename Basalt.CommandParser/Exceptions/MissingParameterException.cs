
namespace Basalt.CommandParser.Exceptions;

internal class MissingParameterException : ArgumentProcessingException
{
    public MissingParameterException(string argument) : base($"a value is required for {argument}", false) { }
}
