using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a boolean
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewBooleanArgumentAttribute : NewArgumentAttribute
{
    public NewBooleanArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description, typeof(bool)) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            return true;

        if (!bool.TryParse(parameter, out bool value))
            throw new InvalidParameterException(LongName, "true or false");

        return value;
    }
}
