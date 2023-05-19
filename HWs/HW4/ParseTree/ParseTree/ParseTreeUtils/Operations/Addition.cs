namespace ParseTree;

/// <summary>
/// Implementation of the "addition" operation.
/// </summary>
internal class Addition : Operation
{
    /// <summary>
    /// The constructor of the Addition, with the addition of two operands.
    /// </summary>
    /// <param name="leftChild"> Left operand. </param>
    /// <param name="rightChild"> Right operand </param>
    public Addition(IParseTreeElement leftChild, IParseTreeElement rightChild)
        : base(leftChild, rightChild)
    {
    }

    /// <summary>
    /// Computing the addition operation.
    /// </summary>
    public override double Calculate() => LeftChild.Calculate() + RightChild.Calculate();

    /// <summary>
    /// Output like: "(+ [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( + ");
        base.Print();
    }
}