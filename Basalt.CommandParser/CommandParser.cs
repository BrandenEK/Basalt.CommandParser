using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Exceptions;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Basalt.CommandParser;

public static class CommandParser
{
    public static TArgs ProcessArguments<TArgs>(string[] args) where TArgs : ProgramArguments, new()
    {
        var data = new TArgs();

        try
        {
            data.Process(args);
        }
        catch (ArgumentLoadingException ex)
        {
            Console.WriteLine($"fatal: {ex.Message}");

            Console.WriteLine();
            Environment.Exit(1);
        }
        catch (ArgumentProcessingException ex)
        {
            if (ex.DisplayMessage is not null)
                Console.WriteLine($"error: {ex.DisplayMessage}");

            if (ex.ShowHelp)
                HelpArguments(data);

            Console.WriteLine();
            Environment.Exit(0);
        }

        return data;
    }

    private static void HelpArguments(ProgramArguments data)
    {
        string assembly = data.GetType().Assembly.GetName().Name ?? "unndefined";
        var attributes = data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.IsDefined(typeof(NewArgumentAttribute), false))
            .Select(p => (NewArgumentAttribute)p.GetCustomAttributes(typeof(NewArgumentAttribute), false)[0])
            .ToArray();

        Console.WriteLine($"Usage: {assembly} [arguments]");
        Console.WriteLine();
        Console.WriteLine("Arguments:");

        int maxLength = attributes.Max(x => x.LongName.Length);

        foreach (var attribute in attributes)
        {
            var sb = new StringBuilder();

            sb.Append("  ");
            sb.Append($"-{attribute.ShortName}".PadLeft(3, ' '));
            sb.Append("|--");
            sb.Append(attribute.LongName.PadRight(maxLength + 2));
            sb.Append(attribute.Description);

            Console.WriteLine(sb);
        }
    }
}
