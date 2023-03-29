namespace ParseTree;

internal class Addition : Operation
{
    public override double Calculate() => LeftChild!.Calculate() + RightChild!.Calculate();

    public override void Print()
    {
        Console.Write("( + ");
        base.Print();
    }
}