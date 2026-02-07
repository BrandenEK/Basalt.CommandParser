using System;

namespace Basalt.CommandParser.Exceptions;

internal class ArgumentLoadingException : Exception
{
    public ArgumentLoadingException(string error, string name) : base($"found {error} ({name})") { }
}
