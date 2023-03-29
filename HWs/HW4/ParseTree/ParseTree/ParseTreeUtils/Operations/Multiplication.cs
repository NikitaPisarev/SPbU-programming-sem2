namespace ParseTree;

/// <summary>
/// Implementation of the "multiplication" operation.
/// </summary>
internal class Multiplication : Operation
{
    /// <summary>
    /// Computing the multiplication operation.
    /// </summary>
    public override double Calculate() => LeftChild!.Calculate() * RightChild!.Calculate();

    /// <summary>
    /// Output like: "(* [left_value] [right_value])"
    /// </summary>
    public override void Print()
    {
        Console.Write("( * ");
        base.Print();
    }
}