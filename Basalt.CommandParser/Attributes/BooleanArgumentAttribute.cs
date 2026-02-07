
namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a boolean
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewBooleanArgumentAttribute : NewArgumentAttribute
{
    public NewBooleanArgumentAttribute(string longName, string shortName) : base(longName, shortName) { }
}
