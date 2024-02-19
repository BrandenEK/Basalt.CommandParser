
using System.Reflection;

namespace CommandParser;

public abstract class CommandData
{
    private readonly Dictionary<ArgumentAttribute, PropertyInfo> _commands = new();

    public CommandData()
    {
        _commands = GetType().GetProperties()
            .Where(p => p.IsDefined(typeof(ArgumentAttribute), false))
            .ToDictionary(p => p.GetCustomAttributes(typeof(ArgumentAttribute), false)[0] as ArgumentAttribute, p => p);
    }

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
            if (!command.Key.CanProcess(curr))
                continue;

            command.Value.SetValue(this, command.Key.Process(curr, next));
            return false;
        }

        throw new CommandParserException($"Invalid argument: {curr}");
    }
}
