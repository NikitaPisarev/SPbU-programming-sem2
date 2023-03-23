namespace LZW;

public class DictionaryPhrasesBuffer
{
    public DictionaryPhrasesBuffer(int currentBitLength)
    {
        this.Phrases = new();
        this.CurrentBitLength = currentBitLength;
    }

    public DictionaryPhrasesBuffer()
    {
        this.Phrases = new();
    }

    public List<int> Phrases { get; private set; }

    public int CurrentBitLength { get; set; } = 9;

    public int Buffer { get; private set; }

    private int _lentghOfBitsInBuffer = 0;

    private const int _byteSize = 8;

    public bool Add(byte code)
    {
        var isNewPhrase = false;
        var bits = _convertToBits(code);

        foreach (var i in bits)
        {
            Buffer = (Buffer << 1) + i;
            ++_lentghOfBitsInBuffer;
            if (_lentghOfBitsInBuffer == CurrentBitLength)
            {
                AddInPhrases();
                isNewPhrase = true;
            }
        }
        return isNewPhrase;
    }

    public void AddInPhrases()
    {
        Phrases.Add(Buffer);
        Buffer = 0;
        _lentghOfBitsInBuffer = 0;
    }

    private byte[] _convertToBits(byte code)
    {
        var bits = new byte[_byteSize];
        for (int i = _byteSize - 1; i >= 0; --i)
        {
            bits[i] = (byte)(code % 2);
            code /= 2;
        }

        return bits;
    }
}