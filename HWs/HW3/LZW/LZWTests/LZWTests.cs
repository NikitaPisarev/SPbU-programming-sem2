namespace LZWTests;

using static LZW.LZW;
using static BWT.BWT;

public class Tests
{
    [TestCase("../../../Files/txt.txt")]
    [TestCase("../../../Files/mp4.mp4")]
    [TestCase("../../../Files/exe.exe")]
    public void CompressAndDecompressWithoutBWT_CorrectFile_CorrectDecompressedFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);
        var compressFile = Compress(expected);
        (var actual, var _) = Decompress(compressFile);

        Assert.That(expected, Is.EqualTo(actual));
    }

    [TestCase("../../../Files/txt.txt")]
    [TestCase("../../../Files/mp4.mp4")]
    [TestCase("../../../Files/exe.exe")]
    public void CompressAndDecompressWithBWT_CorrectFile_CorrectDecompressedFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);

        (var afterBWT, var matrixIndexEncode) = Encode(expected);
        var compressFile = Compress(afterBWT, matrixIndexEncode);
        (var afterDecompression, var matrixIndexDecode) = Decompress(compressFile);

        var actual = Decode(afterDecompression, matrixIndexDecode);

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Compress_EmptyFile_ArgumentExceptionReturned()
    {
        var expected = File.ReadAllBytes("../../../Files/empty.txt");
        Assert.Throws<ArgumentException>(() => Compress(expected));
    }

    [Test]
    public void Decompress_EmptyFile_ArgumentExceptionReturned()
    {
        var expected = File.ReadAllBytes("../../../Files/empty.txt");
        Assert.Throws<ArgumentException>(() => Decompress(expected));
    }

    [Test]
    public void Compress_Null_ArgumentNullExceptionReturned()
    {
        Assert.Throws<ArgumentNullException>(() => Compress(null));
    }

    [Test]
    public void Decompress_Null_ArgumentNullExceptionReturned()
    {
        Assert.Throws<ArgumentNullException>(() => Compress(null));
    }
}