
namespace CommandParser;

public abstract class ArgumentData
{
    //public ArgumentData()
    //{
    //    _validArgs = new();
    //}

    //public ArgumentData(params Argument[] validArgs)
    //{
    //    _validArgs = new(validArgs);
    //}

    public void Evaluate(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (ProcessArg(args[i], i < args.Length - 1 ? args[i + 1] : null))
                i++;
        }
    }

    // Return whether to skip an arg
    private bool ProcessArg(string curr, string? next)
    {
        Console.WriteLine(curr);
        foreach (var command in _validArgs)
        {
            int result = command.Accept(curr, next);

            if (result == -1)
                continue;

            return result == 1;
        }

        throw new CommandParserException($"Invalid argument: {curr}");
    }

    private readonly List<Argument> _validArgs = new();

    public void AddValidArgument(Argument argument) => _validArgs.Add(argument);
}

public class Argument
{
    private readonly string _cmdInitial;
    private readonly string _cmdFull;

    private readonly Action<string> _result;

    public Argument(string cmdInitial, string cmdFull, Action<string> result)
    {
        _cmdInitial = cmdInitial;
        _cmdFull = cmdFull;
        _result = result;
    }

    // Return whether to skip an arg
    // 0 = valid normal, -1 = na, 1 = skip extra
    public int Accept(string curr, string? next)
    {
        if (curr != "-" + _cmdInitial && curr != "-" + _cmdFull)
            return -1;

        _result(curr);
        return 0;
    }
}
