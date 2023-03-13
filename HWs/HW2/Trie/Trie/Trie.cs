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

        public bool IsTerminal { get; set; }
    }

    public bool Add(string element)
    {
        var currentNode = _root;
        foreach (var character in element)
        {
            if (!currentNode.Next.ContainsKey(character))
            {
                currentNode.Next[character] = new Node();
            }

            currentNode = currentNode.Next[character];
        }

        if (currentNode.IsTerminal)
        {
            return false;
        }

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
}