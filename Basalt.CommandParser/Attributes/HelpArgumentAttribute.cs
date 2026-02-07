using Basalt.CommandParser.Exceptions;
using System;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that displays a help message
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class HelpArgumentAttribute : ArgumentAttribute
{
    public HelpArgumentAttribute() : base("help", "h", "Show help", typeof(bool)) { }

    internal override object Process(string? parameter)
    {
        throw new HelpArgumentException();
    }
}
