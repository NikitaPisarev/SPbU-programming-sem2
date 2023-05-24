namespace ParseTree;

/// <summary>
/// Parse tree element - operand.
/// </summary>
internal class Operand : IParseTreeElement
{
    /// <summary>
    /// Operand value initialization.
    /// </summary>
    /// <param name="value"> The value. </param>
    public Operand(double value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Operand value.
    /// </summary>
    public double Value { get; }

    /// <summary>
    /// Returns operand.
    /// </summary>
    public double Calculate() => Value;

    /// <summary>
    /// Operand output.
    /// </summary>
    public void Print() => Console.Write($"{Value} ");
}