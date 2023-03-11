namespace StackCalculator;

/// <summary>
/// Stack realization by using linked list.
/// </summary>
internal class StackList : IStack
{
    public StackList()
    {
        this.stack = new LinkedList<double>();
    }

    private LinkedList<double> stack;

    /// <inheritdoc/>
    public void Push(double value)
    {
        stack.AddFirst(value);
    }

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack.");
        }

        double result = stack.First();
        stack.RemoveFirst();

        return result;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return stack.First == null;
    }
}
