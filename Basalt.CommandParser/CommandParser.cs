
using Basalt.CommandParser.Exceptions;
using Basalt.CommandParser.Tokens;
using System;
using System.Collections.Generic;

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
                DisplayHelp(typeof(TArgs).Assembly.GetName().Name ?? "unndefined", operators.Select(x => x.Attribute));

            Console.WriteLine();
            Environment.Exit(0);
        }

        return data;
    }
}
