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

        foreach (var token in tokens)
        {
            Console.WriteLine(token.GetType() + ": " + token.Text);
        }

        return command;
    }

    private static void DisplayHelp(IEnumerable<NewArgumentAttribute> attributes)
    {

    }
}
