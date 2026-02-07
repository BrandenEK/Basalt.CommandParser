using Basalt.CommandParser.Attributes;

namespace Basalt.CommandParser;

public class BaseArguments
{
    [HelpArgument]
    protected bool ShowHelp { get; }
}
