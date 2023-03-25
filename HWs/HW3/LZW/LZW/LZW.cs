namespace LZW;

public static class LZW
{
    public static int MaximumSizeOfNumberOfCodes = 65536;

    public static byte[] Compress(byte[] bytes, int matrixIndex = -1)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var buffer = new ByteBuffer();
        buffer.SetMatrixIndex(matrixIndex);
        var trie = new Trie();
        trie.InitializationOfTrie();

        var currentMaximumSizeOfNumberOfCodes = 512;
        var input = new List<byte>();
        for (int i = 0; i < bytes.Length; ++i)
        {
            var newElement = new List<byte>();
            newElement.AddRange(input);
            newElement.Add(bytes[i]);

            if (trie.Contains(newElement))
            {
                input = newElement;
            }
            else
            {
                buffer.Add(trie.GetValueOfElement(input));
                trie.Add(newElement);

                if (trie.Size == MaximumSizeOfNumberOfCodes)
                {
                    currentMaximumSizeOfNumberOfCodes = 512;
                    buffer.CurrentBitLength = 9;
                    trie = new Trie();
                    trie.InitializationOfTrie();
                }

                if (trie.Size == currentMaximumSizeOfNumberOfCodes)
                {
                    ++buffer.CurrentBitLength;
                    currentMaximumSizeOfNumberOfCodes *= 2;
                }

                input.Clear();
                input.Add(bytes[i]);
            }
        }
        buffer.Add(trie.GetValueOfElement(input));

        if (buffer.LentghOfBitsInBuffer != 0)
        {
            buffer.AddInResultBytes();
        }

        return buffer.ResultBytes.ToArray();
    }

    public static (byte[], int matrixIndex) Decompress(byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var matrixIndex = BitConverter.ToInt32(new byte[] { bytes[0], bytes[1], bytes[2], bytes[3] });
        var result = new List<byte>();
        var dictionary = DecompressUtils.InitializationOfDictionary();
        var codes = DecompressUtils.GetAllCodes(bytes);
        var dictionarySize = 256;
        var dictionaryCounter = 256;
        var newPhrase = new List<byte>();

        for (int i = 0; i < codes.Count; ++i)
        {
            if (dictionarySize == MaximumSizeOfNumberOfCodes)
            {
                dictionary = DecompressUtils.InitializationOfDictionary();
                dictionarySize = 256;
                dictionaryCounter = 256;
            }

            if (dictionary.ContainsKey(codes[i]))
            {
                if (dictionarySize != 256)
                {
                    while (dictionary.ContainsKey(dictionaryCounter))
                    {
                        ++dictionaryCounter;
                    }

                    newPhrase = new List<byte>(dictionary[codes[i - 1]]);
                    newPhrase.Add(dictionary[codes[i]][0]);

                    dictionary.Add(dictionaryCounter++, newPhrase);
                }

                result.AddRange(dictionary[codes[i]]);
            }
            else
            {
                newPhrase = new List<byte>(dictionary[codes[i - 1]]);
                newPhrase.Add(dictionary[codes[i - 1]][0]);

                dictionary.Add(codes[i], newPhrase);
                result.AddRange(newPhrase);
            }
            ++dictionarySize;
        }

        return (result.ToArray(), matrixIndex);
    }
}