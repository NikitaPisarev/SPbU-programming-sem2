namespace LZW;

internal static class DecompressUtils
{
    internal static List<int> GetAllCodes(byte[] bytes)
    {
        var buffer = new SequenceCodesBuffer();

        var dictionarySize = 256;
        var currentMaximumSizeOfNumberOfCodes = 512;

        for (int i = 4; i < bytes.Length - 1; ++i)
        {
            if (dictionarySize == LZW.MaximumSizeOfNumberOfCodes)
            {
                dictionarySize = 256;
                currentMaximumSizeOfNumberOfCodes = 512;
                buffer.CurrentBitLength = 9;
            }

            if (dictionarySize == currentMaximumSizeOfNumberOfCodes)
            {
                ++buffer.CurrentBitLength;
                currentMaximumSizeOfNumberOfCodes *= 2;
            }

            if (buffer.Add(bytes[i]))
            {
                ++dictionarySize;
            }
        }

        if (buffer.LentghOfBitsInBuffer + SequenceCodesBuffer.ByteSize == buffer.CurrentBitLength)
        {
            buffer.Add(bytes[^1]);
        }
        else
        {
            buffer.AddLastByteInCodes(bytes[^1]);
        }

        return buffer.Codes;
    }

    internal static Dictionary<int, List<byte>> InitializationOfDictionary()
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256; ++i)
        {
            dictionary[i] = new List<byte>();
            dictionary[i].Add((byte)i);
        }

        return dictionary;
    }
}