
namespace Basalt.CommandParser;

public static class CommandParser
{
    public static TArgs ProcessArguments<TArgs>(string[] args) where TArgs : ProgramArguments, new()
    {
        var data = new TArgs();
        data.Process(args);

        return data;
    }
}
