namespace LZW;

/// <summary>
/// Utility class for LZW decompression.
/// </summary>
internal static class DecompressUtils
{
    /// <summary>
    /// Getting a set of codes.
    /// </summary>
    /// <param name="bytes"> Compressed bytes. </param>
    /// <returns> A set of codes from compressed bytes. </returns>
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

    /// <summary>
    /// Creating and initializing a dictionary with the first 256 bytes.
    /// </summary>
    /// <returns> Dictionary of the first 256 codes. </returns>
    internal static Dictionary<int, List<byte>> CreateAndInitializationOfDictionary()
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