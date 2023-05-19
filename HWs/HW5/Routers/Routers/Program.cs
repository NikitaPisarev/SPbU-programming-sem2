using static System.Console;

if (args.Length == 0 || (args.Length == 1 && args[0] != "help"))
{
    Write("Argument error. Use \"dotnet run help\".");
    return 0;
}

if (args[0] == "help")
{
    WriteLine(""""""
    Hello, this program is designed to generate the optimal network configuration.

    Usage:
    -------------------------------------------
    dotnet run <FilePath1> <FilePath2>
    -------------------------------------------
    where, <FilePath1> is the path of the file where the initial configuration lies,
    <FilePath2> is the path of the file where the optimal configuration will be located.
    
    """"""
    );

    return 0;
}

if (!File.Exists(args[0]))
{
    Write("File not found.");
    return 0;
}

var network = File.ReadAllText(args[0]);

WriteLine("Proccesing...");
var configuration = "";
try
{
    configuration = ConfigurationGenerator.ConfigurationGenerator.CreateOptimalConfiguration(network);
}
catch (ArgumentException e)
{
    WriteLine(e.Message);
    return -1;
}

File.WriteAllText(args[1], configuration);
WriteLine("Done.");

return 0;