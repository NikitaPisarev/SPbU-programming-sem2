namespace LZW;

public class DictionaryCodesBuffer
{
    public List<int> Codes { get; private set; } = new();

    public int CurrentBitLength { get; set; } = 9;

    public int Buffer { get; private set; } = 0;

    private int _lentghOfBitsInBuffer = 0;

    private const int _byteSize = 8;

    public bool Add(byte oneByte)
    {
        var isNewPhrase = false;
        var bits = _convertToBits(oneByte);

        foreach (var i in bits)
        {
            Buffer = (Buffer << 1) + i;
            ++_lentghOfBitsInBuffer;
            if (_lentghOfBitsInBuffer == CurrentBitLength)
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
        _lentghOfBitsInBuffer = 0;
    }

    private byte[] _convertToBits(byte oneByte)
    {
        var bits = new byte[_byteSize];
        for (int i = _byteSize - 1; i >= 0; --i)
        {
            bits[i] = (byte)(oneByte % 2);
            oneByte /= 2;
        }

        return bits;
    }
}