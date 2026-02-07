using System;

namespace Basalt.CommandParser.Exceptions;

public class MissingParameterException(string parameter) : Exception
{
    public string Parameter { get; } = parameter;
}
