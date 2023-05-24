namespace ParseTree;

/// <summary>
/// Implementation of the "subtraction" operation.
/// </summary>
internal class Subtraction : Operation
{
    /// <summary>
    /// The constructor of the Subtraction, with the addition of two operands.
    /// </summary>
    /// <param name="leftChild"> Left operand. </param>
    /// <param name="rightChild"> Right operand </param>
    public Subtraction(IParseTreeElement leftChild, IParseTreeElement rightChild)
        : base(leftChild, rightChild)
    {
    }

    /// <summary>
    /// Computing the subtraction operation.
    /// </summary>
    public override double Calculate() => LeftChild.Calculate() - RightChild.Calculate();

    /// <summary>
    /// Output like: "(- [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( - ");
        base.Print();
    }
}