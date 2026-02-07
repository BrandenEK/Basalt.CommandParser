using System;

namespace Basalt.CommandParser.Exceptions;

public class UnknownArgumentException(string name) : Exception
{
    public string Name { get; } = name;
}
