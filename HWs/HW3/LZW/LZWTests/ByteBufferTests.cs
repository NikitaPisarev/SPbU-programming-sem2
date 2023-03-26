namespace LZWTests;

using LZW;

[TestFixture]
public class ByteBufferTests
{
    [Test]
    public void SetMatrixIndex_15_15Returned()
    {
        var buffer = new ByteBuffer();
        var expected = 15;

        buffer.SetMatrixIndex(15);
        var actual = BitConverter.ToInt32(buffer.ResultBytes.ToArray());

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Add_Pharse_CorrectAddition()
    {
        var buffer = new ByteBuffer();
        var expected = (new byte[] { 7, 133 }, 2, 3);

        buffer.Add(15);
        buffer.Add(23);
        var actual = (buffer.ResultBytes, buffer.LentghOfBitsInBuffer, buffer.Buffer);

        Assert.That(expected, Is.EqualTo(actual));
    }
}