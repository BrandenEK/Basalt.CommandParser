
namespace CommandParser;

public abstract class ArgumentData
{
    public void Evaluate(string[] args)
    {
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
}

public abstract class Command
{
    private readonly string _initial;
    private readonly string _name;

    public Command(string initial, string name)
    {
        _initial = '-' + initial;
        _name = '-' + name;
    }

    internal int Accept(string curr, string? next)
    {
        if (curr != _initial && curr != _name)
            return -1;

        return Process(curr, next) ? 1 : 0;
    }

    // return whether to skip ( Change this to recognize if the next arg doesnt have a dash use that ) !!!
    protected abstract bool Process(string curr, string? next);
}

public class StringCommand : Command
{
    private readonly Action<string> _result;

    public StringCommand(string initial, string name, Action<string> result) : base(initial, name)
    {
        _result = result;
    }

    protected override bool Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        _result(next);
        return true;
    }
}

public class BoolCommand : Command
{
    private readonly Action<bool> _result;

    public BoolCommand(string initial, string name, Action<bool> result) : base(initial, name)
    {
        _result = result;
    }

    protected override bool Process(string curr, string? next)
    {
        _result(true);
        return false;
    }
}

public class IntCommand : Command
{
    private readonly Action<int> _result;

    public IntCommand(string initial, string name, Action<int> result) : base(initial, name)
    {
        _result = result;
    }

    protected override bool Process(string curr, string? next)
    {
        if (next is null)
            throw new CommandParserException($"Command {curr} needs a following argument");

        if (!int.TryParse(next, out int value))
            throw new CommandParserException($"Command {curr} needs to be in integer format");

        _result(value);
        return true;
    }
}
