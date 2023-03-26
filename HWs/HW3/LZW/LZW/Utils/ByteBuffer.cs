namespace LZW;

/// <summary>
/// A class for a bit buffer for receiving codes and filling them in LZW.
/// </summary>
public class ByteBuffer
{
    /// <summary>
    /// The resulting set of compressed bytes.
    /// </summary>
    public List<byte> ResultBytes { get; private set; } = new();

    /// <summary>
    /// Byte buffer.
    /// </summary>
    public byte Buffer { get; private set; } = 0;

    /// <summary>
    /// The current length of the bits for the code.
    /// </summary>
    public int CurrentBitLength { get; set; } = 9;

    /// <summary>
    /// Buffer Length.
    /// </summary>
    public int LentghOfBitsInBuffer = 0;

    private const int _byteSize = 8;

    /// <summary>
    /// Adding a phrase in byte buffer.
    /// </summary>
    /// <param name="phrase"> Phrase.</param>
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

    /// <summary>
    /// Adding a buffer in result bytes.
    /// </summary>
    public void AddInResultBytes()
    {
        ResultBytes.Add(Buffer);
        Buffer = 0;
        LentghOfBitsInBuffer = 0;
    }

    /// <summary>
    /// Adding a number of the end of the set in result 
    /// </summary>
    /// <param name="matrixIndex"> The number of the end of the set. </param>
    public void SetMatrixIndex(int matrixIndex)
    {
        ResultBytes.AddRange(BitConverter.GetBytes(matrixIndex));
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