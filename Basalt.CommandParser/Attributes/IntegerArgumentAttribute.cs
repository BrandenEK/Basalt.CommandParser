using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts an integer
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class IntegerArgumentAttribute : ArgumentAttribute
{
    public IntegerArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description, typeof(int)) { }

    internal override object Process(string? parameter)
    {
        if (parameter is null)
            throw new MissingParameterException(LongName);

        if (!int.TryParse(parameter, out int value))
            throw new InvalidParameterException(LongName, "an integer");

        return value;
    }
}
