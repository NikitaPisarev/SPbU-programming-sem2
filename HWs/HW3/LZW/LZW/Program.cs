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

void CreateDecompressedFile(string filePath, byte[] bytes)
{
    var decompressedFilePath = filePath.Remove(filePath.Length - 7);
    var file = new FileInfo(decompressedFilePath);
    var decompressedFile = file.Create();
    decompressedFile.Close();
    File.WriteAllBytes(decompressedFilePath, bytes);
}

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
            CreateCompressedFile(args[0], outputCompressionBytes);
            WriteLine("Done.");

            WriteLine($"Compression ratio: {((double)inpuBytesForCompression.Length / outputCompressionBytes.Length)}");
            break;

        case "-u":
            var inputBytesForDecompression = File.ReadAllBytes(args[0]);

            WriteLine("Processing...");
            var outputDecompressionBytes = LZW.LZW.Decompress(inputBytesForDecompression);
            CreateDecompressedFile(args[0], outputDecompressionBytes);
            WriteLine("Done.");
            break;

        default:
            WriteLine("Unknown command.");
            break;
    }
}