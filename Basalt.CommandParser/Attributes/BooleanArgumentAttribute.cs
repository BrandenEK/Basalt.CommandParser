
namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a boolean
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewBooleanArgumentAttribute : NewArgumentAttribute
{
    public NewBooleanArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description) { }

    public override object Process(string? parameter)
    {
        if (parameter is null)
            return true;

        if (!bool.TryParse(parameter, out bool value))
            throw new CommandParserException($"{ErrorName} must be true or false");

        return value;
    }
}
