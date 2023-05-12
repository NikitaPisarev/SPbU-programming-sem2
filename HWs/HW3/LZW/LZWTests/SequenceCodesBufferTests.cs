namespace LZWTests;

using LZW;

public class SequenceCodesBufferTests
{
    [Test]
    public void AddLastByteInCodes_Bytes_CorrectCodesReturned()
    {
        var buffer = new SequenceCodesBuffer();
        var expected = (new int[] { 2, 9 }, 0, 0);

        buffer.Add(1);
        buffer.Add(2);
        buffer.AddLastByteInCodes(1);
        var actual = (buffer.Codes.ToArray(), buffer.LentghOfBitsInBuffer, buffer.Buffer);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Add_ThreeBytes_CorrectAddition()
    {
        var buffer = new SequenceCodesBuffer();
        var expected = (new int[] { 30, 92 }, 6, 4);

        buffer.Add(15);
        buffer.Add(23);
        buffer.Add(4);
        var actual = (buffer.Codes.ToArray(), buffer.LentghOfBitsInBuffer, buffer.Buffer);

        Assert.That(actual, Is.EqualTo(expected));
    }
}