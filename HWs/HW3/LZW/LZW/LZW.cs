using static System.Console;

if (args[0] == "help")
{
    WriteLine("""
        This program is designed to compress and decompress files using the Lempel—Ziv—Welch algorithm. 

        Usage:
        To compress the file, use the "-c" key:
        -------------------------------------------
        dotnet run <File path> -with
        -------------------------------------------

        To decompress the file, use the "-u" key:
        -------------------------------------------
        dotnet run <File path> -u
        -------------------------------------------
        """);
}
else
{
    if (args.Length < 2)
    {
        throw new IOException("Argument(s) omitted. Use \"dotnet run help\".");
    }

    switch (args[1])
    {
        case "-c":
            break;

        case "-u":
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}