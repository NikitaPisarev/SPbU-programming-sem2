namespace ParseTree;

/// <summary>
/// Implementation of the "multiplication" operation.
/// </summary>
internal class Multiplication : Operation
{
    /// <summary>
    /// The constructor of the Multiplication, with the addition of two operands.
    /// </summary>
    /// <param name="leftChild"> Left operand. </param>
    /// <param name="rightChild"> Right operand </param>
    public Multiplication(IParseTreeElement leftChild, IParseTreeElement rightChild)
        : base(leftChild, rightChild)
    {
    }

    /// <summary>
    /// Computing the multiplication operation.
    /// </summary>
    public override double Calculate() => LeftChild.Calculate() * RightChild.Calculate();

    /// <summary>
    /// Output like: "(* [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( * ");
        base.Print();
    }
}