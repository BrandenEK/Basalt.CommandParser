
namespace Basalt.CommandParser;

public static class CommandParser
{
    public static TArgs Parse<TArgs>(string[] args) where TArgs : BaseArguments, new()
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"{i}: \"{args[i]}\"");
        }

        return new TArgs();
    }
}
