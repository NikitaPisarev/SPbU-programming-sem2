namespace StackCalculator;

/// <summary>
/// Stack realization by using array.
/// </summary>
public class StackArray : IStack
{
    public StackArray()
    {
        this.stack = new List<double>();
    }

    private List<double> stack;

    private int length = 0;

    /// <inheritdoc/>
    public void Push(double value)
    {
        if (length == stack.Count)
        {
            stack.Add(value);
        }
        else
        {
            stack[length] = value;
        }
        ++length;
    }

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack.");
        }

        --length;
        return stack[length];
    }

    /// <inheritdoc/>
    public bool IsEmpty()
    {
        return length == 0;
    }
}