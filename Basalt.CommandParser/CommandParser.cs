using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Tokens;

namespace Basalt.CommandParser;

public static class CommandParser
{
    public static TArgs Parse<TArgs>(string[] args) where TArgs : BaseArguments, new()
    {
        var command = new TArgs();

        var tempAttributes = command.GetType().GetProperties()
            .Where(p => p.IsDefined(typeof(NewArgumentAttribute), false))
            .ToDictionary(p => (NewArgumentAttribute)p.GetCustomAttributes(typeof(NewArgumentAttribute), false)[0], p => p);

        var tokens = new List<Token>();

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"{i}: \"{args[i]}\"");
            string curr = args[i];

            if (curr.Length > 0 && curr.All(c => c == '-'))
                continue;

            if (curr.StartsWith("--"))
            {
                // Make sure long name exists as an attribute
                tokens.Add(new Operator(curr[2..]));
            }
            else if (curr.StartsWith("-"))
            {
                // Make sure short name exists as an attribute
                tokens.Add(new Operator(curr[1..]));
            }
            else
            {
                tokens.Add(new Variable(curr));
            }
        }

        Console.WriteLine();
        foreach (var token in tokens)
        {
            Console.WriteLine(token.GetType().Name + ": " + token.Text);
        }

        if (tokens.Any(x => x is Operator && x.Text == "help" || x.Text == "h"))
        {
            string assembly = command.GetType().Assembly.GetName().Name ?? "unndefined";
            DisplayHelp(assembly, tempAttributes.Select(x => x.Key));
            Environment.Exit(0);
        }

        return command;
    }

    private static void DisplayHelp(string assembly, IEnumerable<NewArgumentAttribute> attributes)
    {
        Console.WriteLine($"Usage: {assembly} [arguments]");
        Console.WriteLine();
        Console.WriteLine("Arguments:");

        // TODO: clean this up, its pretty nasty
        var lines = attributes.ToDictionary(x => x, x => $"  {("-" + x.ShortName).PadLeft(3, ' ')}|--{x.LongName}");
        int maxLength = lines.Max(x => x.Value.Length);

        foreach (var line in lines)
        {
            Console.WriteLine($"{line.Value.PadRight(maxLength + 2, ' ')} {line.Key.Description}");
        }
    }
}
