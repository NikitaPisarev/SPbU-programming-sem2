namespace StackCalculatorTests;

using StackCalculator;

public class Tests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
    {
        new TestCaseData(new StackCalculator(new StackArray())),
        new TestCaseData(new StackCalculator(new StackList())),
    };

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_CorrectExpression_CorrectAnswerReturned(StackCalculator stackCalculator)
    {
        var expression = "10 20 + 3 *";
        var expected = 90;

        var actual = stackCalculator.CalculateExpression(expression);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_FractionalNumbers_CorrectAnswerReturned(StackCalculator stackCalculator)
    {
        var expression = "10.2 20.4 + 5 * 0 -";
        var expected = 153;
        var delta = 0.001;

        var actual = stackCalculator.CalculateExpression(expression);

        Assert.That(Math.Abs(expected - actual) < delta);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_IncorrectExpression_ExceptionReturned(StackCalculator stackCalculator)
    {
        var expression = "10 A + 3 *";

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_EmptyExpression_ExceptionReturned(StackCalculator stackCalculator)
    {
        var expression = string.Empty;

        Assert.Throws<ArgumentException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_Null_ExceptionReturned(StackCalculator stackCalculator)
    {
        string? expression = null;

        Assert.Throws<ArgumentNullException>(() => stackCalculator.CalculateExpression(expression));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateExpression_DivisionByZero_DivideByZeroExceptionReturned(StackCalculator stackCalculator)
    {
        var expression = "10 2 + 0 /";

        Assert.Throws<DivideByZeroException>(() => stackCalculator.CalculateExpression(expression));
    }
}