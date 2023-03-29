namespace ParseTree;

internal class Operand : IParseTreeElement
{
    public Operand(double value)
    {
        this.Value = value;
    }

    public double Value { get; }

    public double Calculate() => Value;

    public void Print() => Console.Write($"{Value} ");
}