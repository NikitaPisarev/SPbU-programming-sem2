namespace LZW;

public static class LZW
{
    internal static int maximumSizeOfNumberOfCodes = 65536;

    public static byte[] Compress(byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var buffer = new ByteBuffer();
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

                if (trie.Size == maximumSizeOfNumberOfCodes)
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

        if (buffer.Buffer != 0)
        {
            buffer.AddInResultBytes();
        }

        return buffer.ResultBytes.ToArray();
    }

    public static byte[] Decompress(byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var result = new List<byte>();
        var dictionary = DecompressUtils.InitializationOfDictionary();
        var phrases = DecompressUtils.GetAllPhrases(bytes);
        var dictionarySize = 256;
        var dictionaryCounter = 256;
        var newPhrase = new List<byte>();

        for (int i = 0; i < phrases.Count; ++i)
        {
            if (dictionarySize == maximumSizeOfNumberOfCodes)
            {
                dictionary = DecompressUtils.InitializationOfDictionary();
                dictionarySize = 256;
                dictionaryCounter = 256;
            }

            if (dictionary.ContainsKey(phrases[i]))
            {
                if (dictionarySize != 256)
                {
                    while (dictionary.ContainsKey(dictionaryCounter))
                    {
                        ++dictionaryCounter;
                    }

                    newPhrase = new List<byte>(dictionary[phrases[i - 1]]);
                    newPhrase.Add(dictionary[phrases[i]][0]);

                    dictionary.Add(dictionaryCounter++, newPhrase);
                }

                result.AddRange(dictionary[phrases[i]]);
            }
            else
            {
                newPhrase = new List<byte>(dictionary[phrases[i - 1]]);
                newPhrase.Add(dictionary[phrases[i - 1]][0]);

                dictionary.Add(phrases[i], newPhrase);
                result.AddRange(newPhrase);
            }
            ++dictionarySize;
        }

        return result.ToArray();
    }
}