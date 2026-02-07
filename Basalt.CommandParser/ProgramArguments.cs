using Basalt.CommandParser.Attributes;
using Basalt.CommandParser.Exceptions;
using Basalt.CommandParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Basalt.CommandParser;

public class ProgramArguments
{
    [HelpArgument]
    protected bool ShowHelp { get; }

    public void Process(string[] args)
    {
        IEnumerable<Operator> operators = LoadOperators();
        List<Token> tokens = ParseTokens(args, operators);
        EvaluateTokens(tokens);
    }

    private IEnumerable<Operator> LoadOperators()
    {
        Operator[] operators = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.IsDefined(typeof(ArgumentAttribute), false))
            .Select(p => new Operator((ArgumentAttribute)p.GetCustomAttributes(typeof(ArgumentAttribute), false)[0], p))
            .ToArray();

        if (operators.Length == 1)
            throw new ArgumentLoadingException("no arguments for type", GetType().Name);

        if (operators.Length != operators.DistinctBy(o => o.Attribute.LongName).Count())
            throw new ArgumentLoadingException("arguments with identical long names for type", GetType().Name);

        if (operators.Length != operators.DistinctBy(o => o.Attribute.ShortName).Count())
            throw new ArgumentLoadingException("arguments with identical short names for type", GetType().Name);

        return operators;
    }

    private List<Token> ParseTokens(string[] args, IEnumerable<Operator> operators)
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

    private void EvaluateTokens(List<Token> tokens)
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
            op.Property.SetValue(this, result);

            Console.WriteLine($"Result is {result.ToString()}");
        }
    }

    private Token CreateToken(string argument, IEnumerable<Operator> operators)
    {
        if (argument.StartsWith("--"))
        {
            string name = argument[2..].ToLower();
            Operator? op = operators.FirstOrDefault(o => o.Attribute.LongName == name);

            return op is null ? throw new UnknownArgumentException(name) : op;
        }

        if (argument.StartsWith("-"))
        {
            string name = argument[1..].ToLower();
            Operator? op = operators.FirstOrDefault(o => o.Attribute.ShortName == name);

            return op is null ? throw new UnknownArgumentException(name) : op;
        }

        return new Variable(argument);
    }
}
