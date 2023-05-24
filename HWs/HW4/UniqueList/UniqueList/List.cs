namespace Lists;

/// <summary>
/// List, a data structure consisting of elements containing, in addition to their own data, links to the next list element.
/// </summary>
public class List
{
    /// <summary>
    /// Starting node of the list.
    /// </summary>
    protected Node? Head = null;

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
    /// Method of adding an element to the list.
    /// </summary>
    /// <param name="value"> The value. </param>
    public virtual void Add(int value) => Head = new Node(value, Head);

    /// <summary>
    /// Method of deleting an element by value.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <exception cref="RemoveNonexistentElementException"> This element is not in the list. </exception>
    public virtual void Remove(int value)
    {
        if (Head is null)
        {
            throw new RemoveNonexistentElementException("This element is not in the list.");
        }

        Node? previousNode = null;
        var currentNode = Head;
        while (currentNode.Value != value && currentNode.Next != null)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        if (currentNode.Value != value)
        {
            throw new RemoveNonexistentElementException("This element is not in the list.");
        }

        /// The case when one node
        if (previousNode == null)
        {
            Head = Head.Next;
        }
        else
        {
            previousNode.Next = currentNode.Next;
        }
    }

    /// <summary>
    /// The method replaces the element under the index "index" with the value "value".
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <param name="index"> The index. </param>
    /// <returns> If the replacement is successful, it returns True, otherwise False. </returns>
    public virtual bool Replace(int value, int index)
    {
        var currentNode = Head;
        for (int i = 0; i <= index; ++i)
        {
            if (currentNode is null)
            {
                return false;
            }

            if (i == index)
            {
                currentNode.Value = value;
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    /// <summary>
    /// The method checks if the list is empty.
    /// </summary>
    /// <returns> If the list is empty returns True, otherwise False. </returns>
    public bool IsEmpty() => Head is null;
}