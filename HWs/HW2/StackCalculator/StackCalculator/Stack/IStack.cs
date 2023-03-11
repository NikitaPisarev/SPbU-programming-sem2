namespace StackCalculator;

public interface IStack
{
    public void Push(double value);

    public double Pop();

    public bool IsEmpty();
}
