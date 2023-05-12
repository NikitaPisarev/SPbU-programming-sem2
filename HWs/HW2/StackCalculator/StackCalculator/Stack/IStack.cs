namespace StackCalculator;

/// <summary>
/// Stack, a last in — first out container for real values.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Add element in stack.
    /// </summary>
    /// <param name="value"> Value to add.</param>
    public void Push(int value);

    /// <summary>
    /// Returns and removes an element from the top of the stack.
    /// </summary>
    /// <returns> Top element of the stack. </returns>
    /// <exception cref="InvalidOperationException"> Can't to Pop() from empty stack. </exception>
    public int Pop();

    /// <summary>
    /// Checking for stack empty.
    /// </summary>
    /// <returns> True - the stack is empty, False - the stack is not empty. </returns>
    public bool IsEmpty();
}
