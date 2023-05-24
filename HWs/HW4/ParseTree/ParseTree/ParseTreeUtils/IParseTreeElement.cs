namespace ParseTree;

/// <summary>
/// Parse tree element interface.
/// </summary>
internal interface IParseTreeElement
{
    /// <summary>
    /// Calculate tree element.
    /// </summary>
    public double Calculate();

    /// <summary>
    /// Print tree element.
    /// </summary>
    public void Print();
}