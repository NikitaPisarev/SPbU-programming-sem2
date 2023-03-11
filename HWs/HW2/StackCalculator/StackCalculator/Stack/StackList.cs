namespace StackCalculator;

internal class StackList : IStack
{
    public StackList()
    {
        this.stack = new LinkedList<double>();
    }

    private LinkedList<double> stack;

    public void Push(double value)
    {
        stack.AddFirst(value);
    }

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

    public bool IsEmpty()
    {
        return stack.First == null;
    }
}
