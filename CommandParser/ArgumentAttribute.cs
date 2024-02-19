
namespace CommandParser;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public abstract class ArgumentAttribute : Attribute
{
    private readonly string _initial;
    private readonly string _name;

    public ArgumentAttribute(char initial, string name)
    {
        _initial = '-' + initial.ToString();
        _name = '-' + name;
    }

    public abstract object Process(string curr, string? next);

    public bool CanProcess(string arg)
    {
        return arg == _initial || arg == _name;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringArgumentAttribute : ArgumentAttribute
{
    public StringArgumentAttribute(char initial, string name) : base(initial, name) { }

    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        return next;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class BooleanArgumentAttribute : ArgumentAttribute
{
    public BooleanArgumentAttribute(char initial, string name) : base(initial, name) { }

    public override object Process(string curr, string? next)
    {
        if (next is null)
            return true;

        if (!bool.TryParse(next, out bool value))
            throw new CommandParserException($"Command {curr} needs to be in boolean format");

        return value;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class IntegerArgumentAttribute : ArgumentAttribute
{
    public IntegerArgumentAttribute(char initial, string name) : base(initial, name) { }

    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        if (!int.TryParse(next, out int value))
            throw new CommandParserException($"Command {curr} needs to be in integer format");

        return value;
    }
}
