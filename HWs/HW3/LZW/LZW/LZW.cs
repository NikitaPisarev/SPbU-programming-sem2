namespace LZW;

public class LZW
{
    private int _maximumSizeOfNumberOfCodes = 65536;

    public byte[] Compress(byte[] bytes)
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

                if (trie.Size == _maximumSizeOfNumberOfCodes)
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

    public byte[] Decompress(byte[] bytes)
    {
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File empty.");
        }

        var result = new List<byte>();
        var dictionary = InitializationOfDictionary();
        var phrases = GetAllPhrases(bytes);
        var dictionarySize = 256;
        var dictionaryCounter = 256;
        var newPhrase = new List<byte>();

        for (int i = 0; i < phrases.Count; ++i)
        {
            if (dictionarySize == _maximumSizeOfNumberOfCodes)
            {
                dictionary = InitializationOfDictionary();
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

    private List<int> GetAllPhrases(byte[] bytes)
    {
        var buffer = new DictionaryPhrasesBuffer();

        var dictionarySize = 256;
        var currentMaximumSizeOfNumberOfCodes = 512;

        var isLastByteAdded = false;
        for (int i = 0; i < bytes.Length; ++i)
        {
            if (dictionarySize == _maximumSizeOfNumberOfCodes)
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
            buffer.AddInPhrases();
        }

        return buffer.Phrases;
    }

    public Dictionary<int, List<byte>> InitializationOfDictionary()
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