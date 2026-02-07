
namespace Basalt.CommandParser.Attributes;

/// <summary>
/// A command line argument that accepts a string
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NewStringArgumentAttribute : NewArgumentAttribute
{
    public NewStringArgumentAttribute(string longName, string shortName, string description) : base(longName, shortName, description) { }
}
