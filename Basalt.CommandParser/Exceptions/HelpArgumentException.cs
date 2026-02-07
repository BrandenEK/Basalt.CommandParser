
namespace Basalt.CommandParser.Exceptions;

public class HelpArgumentException : ArgumentProcessingException
{
    public HelpArgumentException() : base(null, true) { }
}
