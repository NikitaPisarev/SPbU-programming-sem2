namespace LZWTests;

using static LZW.LZW;
using static BWT.BWT;

public class LZWTests
{
    private static IEnumerable<TestCaseData> Files
        => new TestCaseData[]
    {
        new TestCaseData("../../../Files/txt.txt"),
        new TestCaseData("../../../Files/mp4.mp4"),
        new TestCaseData("../../../Files/exe.exe"),
    };

    [TestCaseSource(nameof(Files))]
    public void CompressAndDecompressWithoutBWT_CorrectFile_CorrectDecompressedFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);
        var compressFile = Compress(expected);
        (var actual, var _) = Decompress(compressFile);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(Files))]
    public void CompressAndDecompressWithBWT_CorrectFile_CorrectDecompressedFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);

        (var afterBWT, var matrixIndexEncode) = Encode(expected);
        var compressFile = Compress(afterBWT, matrixIndexEncode);
        (var afterDecompression, var matrixIndexDecode) = Decompress(compressFile);

        var actual = Decode(afterDecompression, matrixIndexDecode);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Compress_EmptyFile_ArgumentExceptionReturned()
    {
        var filePath = File.ReadAllBytes("../../../Files/empty.txt");
        Assert.Throws<ArgumentException>(() => Compress(filePath));
    }

    [Test]
    public void Decompress_EmptyFile_ArgumentExceptionReturned()
    {
        var filePath = File.ReadAllBytes("../../../Files/empty.txt");
        Assert.Throws<ArgumentException>(() => Decompress(filePath));
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