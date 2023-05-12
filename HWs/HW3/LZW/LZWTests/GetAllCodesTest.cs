namespace LZWTests;

using LZW;

public class GetAllCodesTest
{
    [Test]
    public void GetAllCodes_Bytes_CorrectCodesReturned()
    {
        var bytes = new byte[] { 0, 0, 0, 0, 24, 12, 70, 67, 49, 160 };
        var expected = new byte[] { 48, 49, 50, 51, 52 };

        var actual = DecompressUtils.GetAllCodes(bytes).ToArray();

        Assert.That(actual, Is.EqualTo(expected));
    }
}
