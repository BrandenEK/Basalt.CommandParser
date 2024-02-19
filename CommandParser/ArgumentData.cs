
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

    public bool Accept(string arg)
    {
        return false;
    }
}
