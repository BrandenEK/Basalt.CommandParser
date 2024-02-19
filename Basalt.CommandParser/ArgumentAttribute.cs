
namespace Basalt.CommandParser;

/// <summary>
/// An property that accepts an argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public abstract class ArgumentAttribute : Attribute
{
    private readonly string _initial;
    private readonly string _name;

    /// <summary>
    /// Initializes an argument
    /// </summary>
    public ArgumentAttribute(char initial, string name)
    {
        _initial = '-' + initial.ToString();
        _name = '-' + name;
    }

    /// <summary>
    /// Processes a command and returns the value to store in the property
    /// </summary>
    public abstract object Process(string curr, string? next);

    internal bool CanProcess(string arg)
    {
        return arg == _initial || arg == _name;
    }
}

/// <summary>
/// An property that accepts a string argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringArgumentAttribute : ArgumentAttribute
{
    /// <summary>
    /// Initializes a string argument
    /// </summary>
    public StringArgumentAttribute(char initial, string name) : base(initial, name) { }

    /// <summary>
    /// Processes a command and returns the value to store in the property
    /// </summary>
    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        return next;
    }
}

/// <summary>
/// An property that accepts a boolean argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class BooleanArgumentAttribute : ArgumentAttribute
{
    /// <summary>
    /// Initializes a boolean argument
    /// </summary>
    public BooleanArgumentAttribute(char initial, string name) : base(initial, name) { }

    /// <summary>
    /// Processes a command and returns the value to store in the property
    /// </summary>
    public override object Process(string curr, string? next)
    {
        if (next is null)
            return true;

        if (!bool.TryParse(next, out bool value))
            throw new CommandParserException($"Command {curr} needs to be in boolean format");

        return value;
    }
}

/// <summary>
/// An property that accepts an integer argument
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class IntegerArgumentAttribute : ArgumentAttribute
{
    /// <summary>
    /// Initializes an integer argument
    /// </summary>
    public IntegerArgumentAttribute(char initial, string name) : base(initial, name) { }

    /// <summary>
    /// Processes a command and returns the value to store in the property
    /// </summary>
    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        if (!int.TryParse(next, out int value))
            throw new CommandParserException($"Command {curr} needs to be in integer format");

        return value;
    }
}
