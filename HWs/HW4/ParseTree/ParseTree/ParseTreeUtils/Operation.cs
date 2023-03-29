namespace ParseTree;

internal class Operation : IParseTreeElement
{
    public IParseTreeElement? LeftChild { get; set; }

    public IParseTreeElement? RightChild { get; set; }

    public virtual double Calculate() => -1;

    public virtual void Print()
    {
        LeftChild!.Print();
        RightChild!.Print();
        Console.Write(") ");
    }
}