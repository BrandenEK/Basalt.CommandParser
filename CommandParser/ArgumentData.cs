
using System.Reflection;

namespace CommandParser;

public abstract class ArgumentData
{
    public void Evaluate(string[] args)
    {
        DoReflection();

        for (int i = 0; i < args.Length; i++)
        {
            if (ProcessArg(args[i], i < args.Length - 1 ? args[i + 1] : null))
                i++;
        }
    }

    // Return whether to skip an arg
    private bool ProcessArg(string curr, string? next)
    {
        Console.WriteLine(curr);
        foreach (var command in _commands)
        {
            int result = command.Accept(curr, next);

            if (result == -1)
                continue;

            return result == 1;
        }

        throw new CommandParserException($"Invalid argument: {curr}");
    }

    private readonly List<Command> _commands = new();

    public void AddCommand(Command cmd) => _commands.Add(cmd);

    private void DoReflection()
    {
        Type type = GetType();

        var properties = type.GetProperties().Where(prop => prop.IsDefined(typeof(ArgumentAttribute), false));
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttributes(typeof(ArgumentAttribute), false)[0] as ArgumentAttribute;
            AddCommand(new BoolCommand(attribute.Initial.ToString(), attribute.Name, this, property));
        }
    }
}

public abstract class Command
{
    private readonly string _initial;
    private readonly string _name;

    private readonly object _object;
    private readonly PropertyInfo _property;

    public Command(string initial, string name, object obj, PropertyInfo property)
    {
        _initial = '-' + initial;
        _name = '-' + name;
        _object = obj;
        _property = property;
    }

    internal int Accept(string curr, string? next)
    {
        if (curr != _initial && curr != _name)
            return -1;

        _property.SetValue(_object, Process(curr, next));
        return 0;
    }

    // return whether to skip ( Change this to recognize if the next arg doesnt have a dash use that ) !!!
    protected abstract object Process(string curr, string? next);
}

public class StringCommand : Command
{
    public StringCommand(string initial, string name, object obj, PropertyInfo property) : base(initial, name, obj, property) { }

    protected override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        return next;
    }
}

public class BoolCommand : Command
{
    public BoolCommand(string initial, string name, object obj, PropertyInfo property) : base(initial, name, obj, property) { }

    protected override object Process(string curr, string? next)
    {
        return true;
    }
}

public class IntCommand : Command
{
    public IntCommand(string initial, string name, object obj, PropertyInfo property) : base(initial, name, obj, property) { }

    protected override object Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        if (!int.TryParse(next, out int value))
            throw new CommandParserException($"Command {curr} needs to be in integer format");

        return value;
    }
}
