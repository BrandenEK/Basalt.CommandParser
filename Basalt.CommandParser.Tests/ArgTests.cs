namespace Basalt.CommandParser.Tests;

[TestClass]
public class ArgTests
{
    private void VerifyEquality(string[] args, TestCommand expected)
    {
        TestCommand cmd = new();
        cmd.Process(args);

        Assert.AreEqual(cmd, expected);
    }

    private void VerifyException(string[] args)
    {
        TestCommand cmd = new();

        Assert.ThrowsException<CommandParserException>(() => cmd.Process(args));
    }

    [TestMethod]
    public void NoArgs()
    {
        string[] args = Array.Empty<string>();

        VerifyEquality(args, new TestCommand());
    }

    [TestMethod]
    public void InvalidArg()
    {
        string[] args = new string[] { "-u" };

        VerifyException(args);
    }

    [TestMethod]
    public void NameArg_Initial()
    {
        string[] args = new string[] { "-n", "Test name" };

        VerifyEquality(args, new TestCommand()
        {
            Name = "Test name"
        });
    }

    [TestMethod]
    public void NameArg_Full()
    {
        string[] args = new string[] { "-name", "Test name" };

        VerifyEquality(args, new TestCommand()
        {
            Name = "Test name"
        });
    }

    [TestMethod]
    public void NameArg_Missing()
    {
        string[] args = new string[] { "-n" };

        VerifyException(args);
    }

    [TestMethod]
    public void EncryptArg_Empty()
    {
        string[] args = Array.Empty<string>();

        VerifyEquality(args, new TestCommand()
        {
            UseEncryption = false
        });
    }

    [TestMethod]
    public void EncryptArg_Implicit()
    {
        string[] args = new string[] { "-e" };

        VerifyEquality(args, new TestCommand()
        {
            UseEncryption = true
        });
    }

    [TestMethod]
    public void EncryptArg_Explicit()
    {
        string[] args = new string[] { "-e", "true" };

        VerifyEquality(args, new TestCommand()
        {
            UseEncryption = true
        });
    }

    [TestMethod]
    public void DelayArg_Empty()
    {
        string[] args = Array.Empty<string>();

        VerifyEquality(args, new TestCommand()
        {
            SearchDelay = 100
        });
    }

    [TestMethod]
    public void DelayArg_Present()
    {
        string[] args = new string[] { "-d", "300" };

        VerifyEquality(args, new TestCommand()
        {
            SearchDelay = 300
        });
    }

    [TestMethod]
    public void AllArgs()
    {
        string[] args = new string[] { "-e", "-auto-add", "false", "-n", "Test name", "-d", "300", "-t", "fhdsjkkfjre" };

        VerifyEquality(args, new TestCommand()
        {
            Name = "Test name",
            Token = "fhdsjkkfjre",
            UseEncryption = true,
            AutomaticallyAdd = false,
            SearchDelay = 300
        });
    }
}