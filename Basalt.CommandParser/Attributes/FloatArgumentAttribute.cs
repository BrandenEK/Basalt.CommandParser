using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a float
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class FloatArgumentAttribute : NewArgumentAttribute
{
    public FloatArgumentAttribute(string longName, string shortName, string errorName, string description) : base(longName, shortName, errorName, description) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            throw new MissingParameterException(ErrorName);

        if (!float.TryParse(parameter, out float value))
            throw new InvalidParameterException(ErrorName, "a number");

        return value;
    }
}
