using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a float
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class FloatArgumentAttribute : NewArgumentAttribute
{
    public FloatArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description, typeof(float)) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            throw new MissingParameterException(LongName);

        if (!float.TryParse(parameter, out float value))
            throw new InvalidParameterException(LongName, "a number");

        return value;
    }
}
