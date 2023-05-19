using static System.Console;
using static Archiver.Archiver;

if (args[0] == "help")
{
    WriteLine("""
        This program is designed to compress and decompress files.

        Usage:
        To compress the file, use the "--c" key:
        -------------------------------------------
        dotnet run <File path> --c
        -------------------------------------------

        To decompress the file, use the "--u" key:
        -------------------------------------------
        dotnet run <File path> --u
        -------------------------------------------
        """);
}
else
{
    if (args.Length != 2)
    {
        Write("Argument(s) error. Use \"dotnet help\".");
        return;
    }

    switch (args[1])
    {
        case "--c":
            if (!File.Exists(args[0]))
            {
                WriteLine("File not found.");
                return;
            }
            var inputBytesForCompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputCompressionBytes = Compress(inputBytesForCompression);
            File.WriteAllBytes(args[0] + ".zipped", outputCompressionBytes);
            WriteLine("Done.");

            WriteLine($"Compression ratio: {((double)inputBytesForCompression.Length / outputCompressionBytes.Length)}");
            break;

        case "--u":
            if (!File.Exists(args[0]))
            {
                WriteLine("File not found.");
                return;
            }

            if (!args[0].Contains(".zipped"))
            {
                WriteLine("This is not a compressed file.");
                return;
            }

            var inputBytesForDecompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputDecompressionBytes = Decompress(inputBytesForDecompression);
            File.WriteAllBytes(args[0].Substring(0, args[0].Length - 7), outputDecompressionBytes);
            WriteLine("Done.");
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}