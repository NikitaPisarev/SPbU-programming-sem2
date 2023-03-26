namespace StackTests;

using StackCalculator;

public class StackTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
    {
        new TestCaseData(new StackArray()),
        new TestCaseData(new StackList()),
    };

    [TestCaseSource(nameof(Stacks))]
    public void Push_Number_NotEmptyStack(IStack stack)
    {
        stack.Push(3);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPop_Number_EmptyStack(IStack stack)
    {
        stack.Push(3);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPop_Numbers_CorrectNumbersReturn(IStack stack)
    {
        var expected = new double[] { 10, 20, 30 };

        stack.Push(30);
        stack.Push(20);
        stack.Push(10);
        var actual = new double[3];
        for (int i = 0; i < 3; ++i)
        {
            actual[i] = stack.Pop();
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(Stacks))]
    public void Pop_EmptyStack_ExceptionReturn(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}