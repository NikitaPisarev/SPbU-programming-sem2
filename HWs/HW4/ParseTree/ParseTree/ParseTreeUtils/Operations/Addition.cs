namespace ParseTree;

/// <summary>
/// Implementation of the "addition" operation.
/// </summary>
internal class Addition : Operation
{
    /// <summary>
    /// Computing the addition operation.
    /// </summary>
    public override double Calculate() => LeftChild!.Calculate() + RightChild!.Calculate();

    /// <summary>
    /// Output like: "(+ [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( + ");
        base.Print();
    }
}