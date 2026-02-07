
namespace Basalt.CommandParser.Exceptions;

internal class HelpArgumentException : ArgumentProcessingException
{
    public HelpArgumentException() : base(null, true) { }
}
