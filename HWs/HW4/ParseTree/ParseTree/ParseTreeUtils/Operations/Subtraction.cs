namespace ParseTree;

/// <summary>
/// Implementation of the "subtraction" operation.
/// </summary>
internal class Subtraction : Operation
{
    /// <summary>
    /// Computing the subtraction operation.
    /// </summary>
    public override double Calculate() => LeftChild!.Calculate() - RightChild!.Calculate();

    /// <summary>
    /// Output like: "(- [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( - ");
        base.Print();
    }
}