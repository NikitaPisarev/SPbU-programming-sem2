namespace Lists;

public class List
{
    protected Node? Head = null;

    protected class Node
    {
        public Node(int value, Node? next)
        {
            this.Value = value;
            this.Next = next;
        }

        public Node? Next { get; set; }

        public int Value { get; set; }
    }

    public virtual void Add(int value) => Head = new Node(value, Head);

    public virtual bool Remove(int value)
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
        return true;
    }

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

    public bool IsEmpty() => Head is null;
}