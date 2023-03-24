namespace LZW;

internal class ByteBuffer
{
    public List<byte> ResultBytes { get; private set; } = new();

    public byte Buffer { get; private set; } = 0;

    public int CurrentBitLength { get; set; } = 9;

    public int LentghOfBitsInBuffer = 0;

    private const int _byteSize = 8;

    public void Add(int phrase)
    {
        var bits = _convertToBits(phrase);

        foreach (var i in bits)
        {
            Buffer = (byte)((Buffer << 1) + i);
            ++LentghOfBitsInBuffer;
            if (LentghOfBitsInBuffer == _byteSize)
            {
                AddInResultBytes();
            }
        }
    }

    public void AddInResultBytes()
    {
        ResultBytes.Add(Buffer);
        Buffer = 0;
        LentghOfBitsInBuffer = 0;
    }

    private byte[] _convertToBits(int phrase)
    {
        var bits = new byte[CurrentBitLength];
        for (int i = CurrentBitLength - 1; i >= 0; --i)
        {
            bits[i] = (byte)(phrase % 2);
            phrase /= 2;
        }

        return bits;
    }
}