namespace ParseTree;

internal class Division : Operation
{
    public override double Calculate()
    {
        if (Math.Abs(RightChild!.Calculate()) < 0.001)
        {
            throw new DivideByZeroException();
        }

        return LeftChild!.Calculate() / RightChild!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( / ");
        base.Print();
    }
}