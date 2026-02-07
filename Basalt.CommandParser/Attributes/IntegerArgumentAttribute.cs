using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts an integer
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewIntegerArgumentAttribute : NewArgumentAttribute
{
    public NewIntegerArgumentAttribute(string longName, string shortName, string errorName, string description) : base(longName, shortName, errorName, description) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            throw new MissingParameterException(ErrorName);

        if (!int.TryParse(parameter, out int value))
            throw new InvalidParameterException(ErrorName, "an integer");

        return value;
    }
}
