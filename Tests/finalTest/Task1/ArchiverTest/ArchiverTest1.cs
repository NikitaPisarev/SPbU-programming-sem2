namespace ArchiverTests;

using static Archiver.Archiver;

public class ArchiverTests
{
    private static IEnumerable<TestCaseData> Files
        => new TestCaseData[]
    {
        new TestCaseData("../../../TestFiles/File1.txt"),
        new TestCaseData("../../../TestFiles/File2.txt"),
    };

    [TestCaseSource(nameof(Files))]
    public void CompressAndDecompress_CorrectFile_CorrectDecompressedFile(string filePath)
    {
        var expected = File.ReadAllBytes(filePath);
        var compressFile = Compress(expected);
        var actual = Decompress(compressFile);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Compress_EmptyFile_ArgumentExceptionReturned()
    {
        var filePath = File.ReadAllBytes("../../../TestFiles/empty.txt");
        Assert.Throws<ArgumentException>(() => Compress(filePath));
    }

    [Test]
    public void Decompress_EmptyFile_ArgumentExceptionReturned()
    {
        var filePath = File.ReadAllBytes("../../../TestFiles/empty.txt");
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