
namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public abstract class NewArgumentAttribute : Attribute
{
    private readonly string _long;
    private readonly string _short;

    public string LongName { get; }

    public string ShortName { get; }

    public NewArgumentAttribute(string longName, string shortName)
    {
        bool validLongName = !string.IsNullOrEmpty(longName)
            && longName.All(c => char.IsLetter(c) && char.IsLower(c) || c == '-')
            && longName.Any(c => c != '-')
            && longName.Length > 2;

        if (!validLongName)
            throw new ArgumentException($"Invalid long name ({longName})", nameof(longName));

        bool validShortName = !string.IsNullOrEmpty(shortName)
            && shortName.All(c => char.IsLetter(c) && char.IsLower(c) || c == '-')
            && shortName.Any(c => c != '-')
            && shortName.Length <= 2;

        if (!validShortName)
            throw new ArgumentException($"Invalid short name ({shortName})", nameof(shortName));

        _long = longName;
        _short = shortName;

        LongName = longName;
        ShortName = shortName;
    }
}
