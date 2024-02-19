using System.Reflection;

namespace Basalt.CommandParser;

public abstract class CommandData
{
    private readonly Dictionary<ArgumentAttribute, PropertyInfo> _commands = new();

    public CommandData()
    {
        _commands = GetType().GetProperties()
            .Where(p => p.IsDefined(typeof(ArgumentAttribute), false))
            .ToDictionary(p => (ArgumentAttribute)p.GetCustomAttributes(typeof(ArgumentAttribute), false)[0], p => p);
    }

    public void Process(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            string curr = args[i];

            if (!curr.StartsWith('-'))
                continue;

            string? next = GetNextArg(args, i);

            ProcessArg(curr, next);
        }
    }

    private string? GetNextArg(string[] args, int idx)
    {
        if (idx >= args.Length - 1)
            return null;

        string next = args[idx + 1];
        return next.StartsWith('-') ? null : next;
    }

    private void ProcessArg(string curr, string? next)
    {
        Console.WriteLine(curr);
        foreach (var command in _commands)
        {
            if (!command.Key.CanProcess(curr))
                continue;

            command.Value.SetValue(this, command.Key.Process(curr, next));
            return;
        }

        throw new CommandParserException($"Invalid argument: {curr}");
    }
}
