using static System.Console;
using static LZW.LZW;
using static BWT.BWT;

if (args[0] == "help")
{
    WriteLine("""
        This program is designed to compress and decompress files using the Lempel—Ziv—Welch algorithm. 

        Usage:
        To compress the file, use the "--c" key:
        -------------------------------------------
        dotnet run <File path> -with
        -------------------------------------------

        To decompress the file, use the "--u" key:
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
            if (!File.Exists(args[0]))
            {
                WriteLine("File not found.");
                return;
            }
            var inputBytesForCompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            (var bytesAfterBWT, var matrixIndexCompress) = Encode(inputBytesForCompression);
            var outputCompressionBytesWithBWT = Compress(bytesAfterBWT, matrixIndexCompress);
            var outputCompressionBytesWithoutBWT = Compress(inputBytesForCompression);
            if (outputCompressionBytesWithBWT.Length < outputCompressionBytesWithoutBWT.Length)
            {
                File.WriteAllBytes(args[0] + ".zipped", outputCompressionBytesWithBWT);
            }
            else
            {
                File.WriteAllBytes(args[0] + ".zipped", outputCompressionBytesWithoutBWT);
            }
            WriteLine("Done.");

            WriteLine($"Compression ratio with BWT: {((double)inputBytesForCompression.Length / outputCompressionBytesWithBWT.Length)}");
            WriteLine($"Compression ratio without BWT: {((double)inputBytesForCompression.Length / outputCompressionBytesWithoutBWT.Length)}");

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
            (var outputDecompressionBytes, var matrixIndexDecompress) = Decompress(inputBytesForDecompression);
            if (matrixIndexDecompress != -1)
            {
                outputDecompressionBytes = Decode(outputDecompressionBytes, matrixIndexDecompress);
            }
            File.WriteAllBytes(args[0].Replace(".zipped", ""), outputDecompressionBytes);
            WriteLine("Done.");
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}