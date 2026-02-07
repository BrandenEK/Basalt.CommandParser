using System;

namespace Basalt.CommandParser.Exceptions;

public class ImproperSetupException : Exception
{
    public ImproperSetupException (string name, string region) : base($"Invalid {region} ({name})") { }
}
