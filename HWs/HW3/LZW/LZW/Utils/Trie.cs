namespace LZW;

/// <summary>
/// Data structure, which is a suspended tree with bytes on the edges, Trie.
/// </summary>
internal class Trie
{
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    public Trie()
    {
        this._root = new();
        Size = 0;
    }

    private Node _root;

    /// <summary>
    /// Gets the size of the Trie, the number of elements in the Trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Trie node.
    /// </summary>
    private class Node
    {
        public Node(int value)
        {
            this.Next = new();
            this.Value = value;
        }

        public Node()
        {
            this.Next = new();
        }

        /// <summary>
        /// Gets collection of next nodes.
        /// </summary>
        public Dictionary<byte, Node> Next { get; set; }

        /// <summary>
        /// Node Value
        /// </summary>
        public int Value { get; set; } = 0;

        /// <summary>
        /// Gets information whether this node is a terminal
        /// </summary>
        public bool IsTerminal { get; set; }
    }

    /// <summary>
    /// Method for adding a element to Trie.
    /// </summary>
    /// <param name="element"> Byte array. </param>
    /// <returns> True - element added successfully, False - this element is already in Trie. </returns>
    /// <exception cref="ArgumentNullException"> Element can't be null. </exception>
    public bool Add(List<byte> element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null.");
        }

        if (!element.Any())
        {
            return false;
        }

        if (Contains(element))
        {
            return false;
        }

        var currentNode = _root;
        foreach (var currentByte in element)
        {
            if (!currentNode.Next.ContainsKey(currentByte))
            {
                currentNode.Next[currentByte] = new Node(Size++);
            }

            currentNode = currentNode.Next[currentByte];
        }

        return currentNode.IsTerminal = true;
    }

    /// <summary>
    /// Method to check if a element exists in a Trie.
    /// </summary>
    /// <param name="element"> Byte array. </param>
    /// <returns> True - this element is in Trie, False - this element is not in Trie. </returns>
    /// <exception cref="ArgumentNullException"> Element can't be null. </exception>
    public bool Contains(List<byte> element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null.");
        }

        if (!element.Any())
        {
            return true;
        }

        var currentNode = _root;
        foreach (var currentByte in element)
        {
            if (!currentNode.Next.ContainsKey(currentByte))
            {
                return false;
            }

            currentNode = currentNode.Next[currentByte];
        }

        return currentNode.IsTerminal;
    }


    /// <summary>
    /// A method that returns the value of an element.
    /// </summary>
    /// <param name="element"> Byte array. </param>
    /// <returns> Value or -1 if there is no such element. </returns>
    /// <exception cref="ArgumentNullException"> Element can't be null. </exception>
    public int GetValueOfElement(List<byte> element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element), "Can't be null.");
        }

        if (!Contains(element))
        {
            return -1;
        }

        var currentNode = _root;
        foreach (var bytes in element)
        {
            currentNode = currentNode.Next[bytes];
        }

        return currentNode.Value;
    }

    public void InitializationOfTrie()
    {
        for (int i = 0; i < 256; ++i)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            this.Add(newElement);
        }
    }
}