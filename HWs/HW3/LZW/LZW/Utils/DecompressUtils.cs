namespace LZW;

internal static class DecompressUtils
{
    internal static List<int> GetAllCodes(byte[] bytes)
    {
        var buffer = new DictionaryCodesBuffer();

        var dictionarySize = 256;
        var currentMaximumSizeOfNumberOfCodes = 512;

        var isLastByteAdded = false;
        for (int i = 0; i < bytes.Length; ++i)
        {
            if (dictionarySize == LZW.maximumSizeOfNumberOfCodes)
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
                isLastByteAdded = true;
            }
            else
            {
                isLastByteAdded = false;
            }
        }

        if (!isLastByteAdded)
        {
            buffer.AddInCodes();
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