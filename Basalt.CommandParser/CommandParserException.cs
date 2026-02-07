using System;

namespace Basalt.CommandParser;

/// <summary>
/// Exception thrown when processing command line arguments
/// </summary>
public class CommandParserException : Exception
{
    /// <summary>
    /// Creates a new cmd exception
    /// </summary>
    public CommandParserException(string message) : base(message) { }
}
