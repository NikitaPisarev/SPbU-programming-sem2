namespace Trie;

internal class Trie
{
    public Trie()
    {
        _root = new();
    }

    private Node _root;

    public int Size { get; private set; }

    private class Node
    {
        public Node()
        {
            this.Next = new();
        }

        public Dictionary<char, Node> Next { get; }

        public int NumberWordsWithSamePrefix { get; set; }

        public bool IsTerminal { get; set; }
    }

    public bool Add(string element)
    {

        if (Contains(element))
        {
            return false;
        }

        var currentNode = _root;
        foreach (var character in element)
        {
            if (!currentNode.Next.ContainsKey(character))
            {
                currentNode.Next[character] = new Node();
            }

            currentNode.NumberWordsWithSamePrefix++;
            currentNode = currentNode.Next[character];
        }

        currentNode.NumberWordsWithSamePrefix++;
        Size++;
        return currentNode.IsTerminal = true;
    }

    public bool Contains(string element)
    {
        var currentNode = _root;
        foreach (var character in element)
        {
            if (!currentNode.Next.ContainsKey(character))
            {
                return false;
            }

            currentNode = currentNode.Next[character];
        }

        return currentNode.IsTerminal;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        var currentNode = _root;
        foreach (var character in prefix)
        {
            if (!currentNode.Next.ContainsKey(character))
            {
                return 0;
            }
            currentNode = currentNode.Next[character];
        }

        return currentNode.NumberWordsWithSamePrefix;
    }
}