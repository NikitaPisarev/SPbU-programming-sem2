using static System.Console;
using LZW;


void CreateCompressedFile(string filePath, byte[] bytes)
{
    var compressedFilePath = filePath + ".zipped";
    var file = new FileInfo(compressedFilePath);
    var compressedFile = file.Create();
    compressedFile.Close();
    File.WriteAllBytes(compressedFilePath, bytes);
}

var LZW = new LZW.LZW();


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
        case "--c":
            var inputBytes = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputBytes = LZW.Compress(inputBytes);
            CreateCompressedFile(args[0], outputBytes);
            WriteLine("Done.");

            WriteLine($"Compression ratio: {((double)inputBytes.Length / outputBytes.Length)}");
            break;

        case "-u":
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}