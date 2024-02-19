# Command Line Argument Parser

Allows you to define properties that are automatically set upon processing the arguments

```cs
internal class Program
{
    static void Main(string[] args)
    {
        var cmd = new TestCommand();
        cmd.Process(args);

        Console.WriteLine();
        Console.WriteLine($"Name: {cmd.Name}");
        Console.WriteLine($"Token: {cmd.Token}");
        Console.WriteLine($"Encrypt: {cmd.UseEncryption}");
        Console.WriteLine($"Autoadd: {cmd.AutomaticallyAdd}");
        Console.WriteLine($"Delay: {cmd.SearchDelay}");
    }
}
```

```cs
namespace CommandParser;

public class TestCommand : CommandData
{
    [StringArgument('n', "name")]
    public string Name { get; set; } = "Default name";

    [StringArgument('t', "token")]
    public string Token { get; set; } = string.Empty;

    [BooleanArgument('e', "encrypt")]
    public bool UseEncryption { get; set; }

    [BooleanArgument('a', "auto-add")]
    public bool AutomaticallyAdd { get; set; } = true;

    [IntegerArgument('d', "delay")]
    public int SearchDelay { get; set; }
}
```
