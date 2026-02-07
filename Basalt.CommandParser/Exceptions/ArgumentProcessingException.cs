using System;

namespace Basalt.CommandParser.Exceptions;

internal class ArgumentProcessingException : Exception
{
    public bool ShowHelp { get; }

    public string? DisplayMessage { get; }

    public ArgumentProcessingException(string? message, bool showHelp)
    {
        ShowHelp = showHelp;
        DisplayMessage = message;
    }
}
