using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a string
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewStringArgumentAttribute : NewArgumentAttribute
{
    public NewStringArgumentAttribute(string longName, string shortName, string errorName, string description) : base(longName, shortName, errorName, description) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            throw new CommandParserException($"{ErrorName} is required");

        return parameter;
    }
}
