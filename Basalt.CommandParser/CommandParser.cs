using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Exceptions;
using Basalt.CommandParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Basalt.CommandParser;

public static class CommandParser
{
    public static TArgs Parse<TArgs>(string[] args) where TArgs : BaseArguments, new()
    {
        var command = new TArgs();

        var operators = command.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.IsDefined(typeof(NewArgumentAttribute), false))
            .Select(p => new Operator((NewArgumentAttribute)p.GetCustomAttributes(typeof(NewArgumentAttribute), false)[0], p));

        // TODO: improve help method selection
        try
        {
            List<Token> tokens = ParseTokens(args, operators);
            EvaluateTokens(tokens);
        }
        catch (UnknownArgumentException ex)
        {
            Console.WriteLine($"error: unknown argument '{ex.Name}'");
            string assembly = command.GetType().Assembly.GetName().Name ?? "unndefined";
            DisplayHelp(assembly, operators.Select(x => x.Attribute));
            Environment.Exit(0);
        }
        catch (HelpArgumentException ex)
        {
            string assembly = command.GetType().Assembly.GetName().Name ?? "unndefined";
            DisplayHelp(assembly, operators.Select(x => x.Attribute));
            Environment.Exit(0);
        }
        catch (MissingParameterException ex)
        {
            Console.WriteLine($"error: {ex.Parameter} is required");
            Environment.Exit(0);
        }
        catch (InvalidParameterException ex)
        {
            Console.WriteLine($"error: {ex.Parameter} must be {ex.Condition}");
            Environment.Exit(0);
        }

        return command;
    }

    private static List<Token> ParseTokens(string[] args, IEnumerable<Operator> operators)
    {
        var tokens = new List<Token>();

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"{i}: \"{args[i]}\"");
            string curr = args[i];

            if (curr.Length > 0 && curr.All(c => c == '-'))
                continue;

            Token token = CreateToken(curr, operators);
            tokens.Add(token);
        }

        return tokens;
    }

    private static void EvaluateTokens(List<Token> tokens)
    {
        // Temp display
        Console.WriteLine();

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is not Operator op)
                continue;

            Console.WriteLine($"Processing op {op.Attribute.LongName}");
            string? param = i < tokens.Count - 1 && tokens[i + 1] is Variable var ? var.Content : null;
            object result = op.Attribute.Process(param);

            Console.WriteLine($"Result is {result.ToString()}");
            // Write result into the property
        }
    }

    private static Token CreateToken(string argument, IEnumerable<Operator> operators)
    {
        if (argument.StartsWith("--"))
        {
            string name = argument[2..];
            Operator? op = operators.FirstOrDefault(o => o.Attribute.LongName == name);

            return op is null ? throw new UnknownArgumentException(name) : op;
        }

        if (argument.StartsWith("-"))
        {
            string name = argument[1..];
            Operator? op = operators.FirstOrDefault(o => o.Attribute.ShortName == name);

            return op is null ? throw new UnknownArgumentException(name) : op;
        }

        return new Variable(argument);
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
        Console.WriteLine();
    }
}
