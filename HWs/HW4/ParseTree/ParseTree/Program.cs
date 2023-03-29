using static System.Console;

if (args.Length != 1)
{
    throw new IOException("Argument error. Use \"dotnet run help\".");
}

if (args[0] == "help")
{
    WriteLine("""
        This program computes the expression by parsing tree.

        Usage:
        -------------------------------------------
        dotnet run <FilePath>
        -------------------------------------------

        """);
}
else
{
    var parseTree = new ParseTree.ParseTree();

    if (!File.Exists(args[0]))
    {
        Write("File not found.");
        return;
    }

    var expression = File.ReadAllText(args[0]);
    try
    {
        parseTree.FillTree(expression);
    }
    catch (Exception e) when (e is ArgumentException || e is ArgumentNullException)
    {
        Write(e.Message);
        return;
    }

    double result = 0;
    try
    {
        result = parseTree.Calculate();
    }
    catch (DivideByZeroException e)
    {
        Write(e.Message);
        return;
    }

    parseTree.Print();
    Write($"= {result}");
}