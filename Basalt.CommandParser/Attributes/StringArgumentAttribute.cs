using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a string
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringArgumentAttribute : ArgumentAttribute
{
    public StringArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description, typeof(string)) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            throw new MissingParameterException(LongName);

        return parameter;
    }
}
