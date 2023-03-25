namespace LZW;

/// <summary>
/// A class for a bit buffer for receiving codes from bytes converted using LZW.
/// </summary>
public class SequenceCodesBuffer
{
    /// <summary>
    /// The resulting set of codes.
    /// </summary>
    public List<int> Codes { get; private set; } = new();

    /// <summary>
    /// The current length of the bits for the code.
    /// </summary>
    public int CurrentBitLength { get; set; } = 9;

    /// <summary>
    /// Code buffer.
    /// </summary>
    public int Buffer { get; set; } = 0;

    /// <summary>
    /// Buffer Length.
    /// </summary>
    public int LentghOfBitsInBuffer = 0;

    /// <summary>
    /// Byte size.
    /// </summary>
    public const int ByteSize = 8;

    /// <summary>
    /// Adding a byte in code buffer.
    /// </summary>
    /// <param name="oneByte"> Byte. </param>
    /// <returns> True - if a new code has been added, otherwise False. </returns>
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

    /// <summary>
    /// Adding a buffer in result codes.
    /// </summary>
    public void AddInCodes()
    {
        Codes.Add(Buffer);
        Buffer = 0;
        LentghOfBitsInBuffer = 0;
    }


    /// <summary>
    /// Adding the last "incomplete" byte.
    /// </summary>
    /// <param name="oneByte"> Byte. </param>
    public void AddLastByteInCodes(byte oneByte)
    {
        var bits = _representationLastByteInCodes(oneByte);

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

    private byte[] _representationLastByteInCodes(byte oneByte)
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