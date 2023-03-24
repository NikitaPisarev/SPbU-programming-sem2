using static System.Console;
using LZW;

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
        throw new IOException("Argument(s) omitted. Use \"dotnet LZW.dll help\".");
    }

    switch (args[1])
    {
        case "--c":
            var inpuBytesForCompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputCompressionBytes = LZW.LZW.Compress(inpuBytesForCompression);
            File.WriteAllBytes(args[0] + ".zipped", outputCompressionBytes);

            WriteLine("Done.");

            WriteLine($"Compression ratio: {((double)inpuBytesForCompression.Length / outputCompressionBytes.Length)}");
            break;

        case "-u":
            var inputBytesForDecompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputDecompressionBytes = LZW.LZW.Decompress(inputBytesForDecompression);
            File.WriteAllBytes(args[0].Replace(".zipped", ""), outputDecompressionBytes);
            WriteLine("Done.");
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}