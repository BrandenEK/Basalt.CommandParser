using Basalt.CommandParser.Exceptions;
using System;
using System.Linq;

namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public abstract class NewArgumentAttribute : Attribute
{
    public string LongName { get; }

    public string ShortName { get; }

    public string Description { get; }

    public Type DataType { get; }

    public NewArgumentAttribute(string longName, string shortName, string description, Type dataType)
    {
        bool validLongName = !string.IsNullOrEmpty(longName)
            && longName.All(c => char.IsLetter(c) && char.IsLower(c) || c == '-')
            && longName.Any(c => c != '-')
            && longName.Length > 2;

        if (!validLongName)
            throw new ImproperSetupException(longName, nameof(longName));

        bool validShortName = !string.IsNullOrEmpty(shortName)
            && shortName.All(c => char.IsLetter(c) && char.IsLower(c) || c == '-')
            && shortName.Any(c => c != '-')
            && shortName.Length <= 2;

        if (!validShortName)
            throw new ImproperSetupException(shortName, nameof(shortName));

        bool validDescription = !string.IsNullOrEmpty(description);

        if (!validDescription)
            throw new ImproperSetupException(description, nameof(description));

        LongName = longName;
        ShortName = shortName;
        Description = description;
        DataType = dataType;
    }

    public abstract object Process(string? parameter);
}
