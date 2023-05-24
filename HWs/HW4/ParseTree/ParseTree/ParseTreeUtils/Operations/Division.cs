namespace ParseTree;

/// <summary>
/// Implementation of the "division" operation.
/// </summary>
internal class Division : Operation
{
    /// <summary>
    /// The constructor of the Division, with the addition of two operands.
    /// </summary>
    /// <param name="leftChild"> Left operand. </param>
    /// <param name="rightChild"> Right operand </param>
    public Division(IParseTreeElement leftChild, IParseTreeElement rightChild)
        : base(leftChild, rightChild)
    {
    }

    private const double _delta = 0.001;

    /// <summary>
    /// Computing the division operation.
    /// </summary>
    /// <exception cref="DivideByZeroException" > Divisor cannot be zero. </exception>
    public override double Calculate()
    {
        if (Math.Abs(RightChild!.Calculate()) < _delta)
        {
            throw new DivideByZeroException();
        }

        return LeftChild.Calculate() / RightChild.Calculate();
    }

    /// <summary>
    /// Output like: "(/ [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( / ");
        base.Print();
    }
}