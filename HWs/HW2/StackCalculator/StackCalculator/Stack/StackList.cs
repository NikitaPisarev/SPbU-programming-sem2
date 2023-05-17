namespace StackCalculator;

/// <summary>
/// Stack realization by using linked list.
/// </summary>
public class StackList : IStack
{
    public StackList()
    {
        this.stack = new LinkedList<int>();
    }

    private LinkedList<int> stack;

    /// <inheritdoc/>
    public void Push(int value)
    {
        stack.AddFirst(value);
    }

    /// <inheritdoc/>
    public int Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack.");
        }

        int result = stack.First();
        stack.RemoveFirst();

        return result;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return stack.First == null;
    }
}
