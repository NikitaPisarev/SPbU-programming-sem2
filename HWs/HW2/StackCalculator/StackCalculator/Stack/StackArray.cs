namespace StackCalculator;

/// <summary>
/// Stack realization by using array.
/// </summary>
public class StackArray : IStack
{
    public StackArray()
    {
        this.stack = new List<int>();
    }

    private List<int> stack;

    /// <inheritdoc/>
    public void Push(int value)
    {
        stack.Add(value);
    }

    /// <inheritdoc/>
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack.");
        }

        var upElement = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return upElement;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return stack.Count == 0;
    }
}