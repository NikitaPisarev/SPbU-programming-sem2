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
                if (trie.Size == _maximumSizeOfNumberOfCodes)
                {
                    currentMaximumSizeOfNumberOfCodes = 512;
                    buffer.CurrentBitLength = 9;
                    trie = new();
                }

                if (trie.Size == currentMaximumSizeOfNumberOfCodes)
                {
                    ++buffer.CurrentBitLength;
                    currentMaximumSizeOfNumberOfCodes *= 2;
                }

                buffer.Add(trie.GetValueOfElement(input));
                trie.Add(newElement, trie.Size);

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
}