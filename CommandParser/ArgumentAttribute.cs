
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

    public abstract object GetDefault();

    public bool CanProcess(string arg)
    {
        return arg == _initial || arg == _name;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringArgumentAttribute : ArgumentAttribute
{
    private readonly string _default;

    public StringArgumentAttribute(char initial, string name, string defaultValue = "") : base(initial, name)
    {
        _default = defaultValue;
    }

    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        return next;
    }

    public override object GetDefault() => _default;
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class BooleanArgumentAttribute : ArgumentAttribute
{
    private readonly bool _default;

    public BooleanArgumentAttribute(char initial, string name, bool defaultValue = false) : base(initial, name)
    {
        _default = defaultValue;
    }
    public override object Process(string curr, string? next)
    {
        if (next is null)
            return true;

        if (!bool.TryParse(next, out bool value))
            throw new CommandParserException($"Command {curr} needs to be in boolean format");

        return value;
    }

    public override object GetDefault() => _default;
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class IntegerArgumentAttribute : ArgumentAttribute
{
    private readonly int _default;

    public IntegerArgumentAttribute(char initial, string name, int defaultValue = 0) : base(initial, name)
    {
        _default = defaultValue;
    }
    public override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        if (!int.TryParse(next, out int value))
            throw new CommandParserException($"Command {curr} needs to be in integer format");

        return value;
    }

    public override object GetDefault() => _default;
}
