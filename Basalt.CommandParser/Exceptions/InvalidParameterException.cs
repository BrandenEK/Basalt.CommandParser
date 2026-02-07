using System;

namespace Basalt.CommandParser.Exceptions;

public class InvalidParameterException(string parameter, string condition) : Exception
{
    public string Parameter { get; } = parameter;

    public string Condition { get; } = condition;
}
