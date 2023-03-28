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
        dotnet run "<expression>"
        -------------------------------------------

        For example:

        dotnet run "(* (+ 1 1) 2)"
        -------------------------------------------
        Output:
        ( * ( + 1 1 ) 2 ) = 4

        """);
}
else
{
    Write(args[0]);
}