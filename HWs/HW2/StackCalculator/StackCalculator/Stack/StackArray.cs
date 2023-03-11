namespace StackCalculator;

internal class StackArray : IStack
{
    public StackArray()
    {
        this.stack = new List<double>();
    }

    private List<double> stack;

    private int length = 0;

    public void Push(double value)
    {
        stack.Insert(length, value);
        ++length;
    }

    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't to Pop() from empty stack.");
        }

        --length;
        return stack[length];
    }

    public bool IsEmpty()
    {
        return length == 0;
    }
}