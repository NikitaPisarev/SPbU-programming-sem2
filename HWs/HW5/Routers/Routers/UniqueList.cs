namespace UniqueList;

/// <summary>
/// List, a data structure consisting of elements containing, in addition to their own data,
/// links to the next list element, and the elements are unique.
/// </summary>
public class UniqueList
{
    /// <summary>
    /// Starting node of the list.
    /// </summary>
    protected Node? Head = null;

    /// <summary>
    /// List size.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// List node.
    /// </summary>
    protected class Node
    {
        public Node(int value, Node? next)
        {
            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Pointer to the next node.
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Node Value.
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// Checks if the value is in the list.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <returns> True - if value in the list, otherwise False. </returns>
    public bool Contains(int value)
    {
        if (Head is null)
        {
            return false;
        }

        var currentNode = Head;
        while (currentNode.Value != value && currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value == value;
    }

    /// <summary>
    /// Method of adding an element to the list.
    /// </summary>
    /// <param name="value"> The value. </param>
    public void Add(int value)
    {
        if (!Contains(value))
        {
            Head = new Node(value, Head);
            ++Count;
        }
    }
}