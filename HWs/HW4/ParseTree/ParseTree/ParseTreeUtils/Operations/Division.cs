namespace ParseTree;

/// <summary>
/// Implementation of the "division" operation.
/// </summary>
internal class Division : Operation
{
    /// <summary>
    /// Computing the division operation.
    /// </summary>
    /// <exception cref="DivideByZeroException" > Divisor cannot be zero. </exception>
    public override double Calculate()
    {
        if (Math.Abs(RightChild!.Calculate()) < 0.001)
        {
            throw new DivideByZeroException();
        }

        return LeftChild!.Calculate() / RightChild!.Calculate();
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