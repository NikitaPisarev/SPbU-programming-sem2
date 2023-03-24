namespace LZW;

public class DictionaryCodesBuffer
{
    public List<int> Codes { get; private set; } = new();

    public int CurrentBitLength { get; set; } = 9;

    public int Buffer { get; set; } = 0;

    public int LentghOfBitsInBuffer = 0;

    public const int ByteSize = 8;

    public bool Add(byte oneByte)
    {
        var isNewPhrase = false;
        var bits = _convertToBits(oneByte);

        foreach (var i in bits)
        {
            Buffer = ((Buffer << 1) + i);
            ++LentghOfBitsInBuffer;
            if (LentghOfBitsInBuffer == CurrentBitLength)
            {
                AddInCodes();
                isNewPhrase = true;
            }
        }
        return isNewPhrase;
    }

    public void AddInCodes()
    {
        Codes.Add(Buffer);
        Buffer = 0;
        LentghOfBitsInBuffer = 0;
    }

    public void AddLastByteInCodes(byte oneByte)
    {
        var bits = RepresentationLastByteInCodes(oneByte);

        foreach (var i in bits)
        {
            Buffer = ((Buffer << 1) + i);
            ++LentghOfBitsInBuffer;
            if (LentghOfBitsInBuffer == CurrentBitLength)
            {
                AddInCodes();
            }
        }
    }

    private byte[] RepresentationLastByteInCodes(byte oneByte)
    {
        var bits = new List<byte>();
        while (oneByte > 0)
        {
            bits.Add((byte)(oneByte % 2));
            oneByte >>= 1;
        }

        while (bits.Count + LentghOfBitsInBuffer < CurrentBitLength)
        {
            bits.Add(0);
        }

        bits.Reverse();
        return bits.ToArray();
    }

    private byte[] _convertToBits(byte oneByte)
    {
        var bits = new byte[ByteSize];
        for (int i = ByteSize - 1; i >= 0; --i)
        {
            bits[i] = (byte)(oneByte % 2);
            oneByte /= 2;
        }

        return bits;
    }
}