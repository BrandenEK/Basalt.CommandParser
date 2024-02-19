namespace CommandParser;

internal class Program
{
    static void Main(string[] args)
    {
        var arguments = new TestArgument();
        arguments.Evaluate(args);

        Console.WriteLine();
        Console.WriteLine($"Name: {arguments.Name}");
        Console.WriteLine($"Token: {arguments.Token}");
        Console.WriteLine($"Encrypt: {arguments.UseEncryption}");
        Console.WriteLine($"Autoadd: {arguments.AutomaticallyAdd}");
        Console.WriteLine($"Delay: {arguments.SearchDelay}");
    }
}
