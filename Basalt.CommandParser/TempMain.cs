
namespace Basalt.CommandParser;

public class TempMain
{
    static void Main(string[] args)
    {
        CommandParser.Parse<BaseArguments>(args);
        Console.ReadKey(true);
    }
}
