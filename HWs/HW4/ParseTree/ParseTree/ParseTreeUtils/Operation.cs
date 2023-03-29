namespace ParseTree;

/// <summary>
/// Parse tree element - operation.
/// </summary>
internal class Operation : IParseTreeElement
{
    /// <summary>
    /// Left subtree.
    /// </summary>
    public IParseTreeElement? LeftChild { get; set; }

    /// <summary>
    /// Right subtree.
    /// </summary>
    public IParseTreeElement? RightChild { get; set; }

    /// <summary>
    /// Virtual method designed to evaluate the operation.
    /// </summary>
    public virtual double Calculate() => -1;

    /// <summary>
    /// Virtual method designed to print the operation.
    /// </summary>
    public virtual void Print()
    {
        LeftChild!.Print();
        RightChild!.Print();
        Console.Write(") ");
    }
}