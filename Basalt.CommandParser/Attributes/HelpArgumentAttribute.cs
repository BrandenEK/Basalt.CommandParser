using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that displays a help message
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class HelpArgumentAttribute : NewArgumentAttribute
{
    public HelpArgumentAttribute() : base("help", "h", "help", "Show help") { }

    public override object Process(string? parameter)
    {
        throw new HelpArgumentException();
    }
}
