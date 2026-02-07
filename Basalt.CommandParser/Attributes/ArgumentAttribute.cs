
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
        if (string.IsNullOrEmpty(longName) || longName.Any(c => !char.IsLetter(c) && c != '-') || longName.Length < 3)
            throw new ArgumentException($"Invalid long name ({longName})", nameof(longName));

        if (string.IsNullOrEmpty(shortName) || shortName.Any(c => !char.IsLetter(c) && c != '-') || shortName.All(c => c == '-') || shortName.Length > 2)
            throw new ArgumentException($"Invalid short name ({shortName})", nameof(shortName));

        _long = longName;
        _short = shortName;

        LongName = longName;
        ShortName = shortName;
    }
}
