namespace ParseTreeTests;

using ParseTree;

public class Tests
{
    private ParseTree _parseTree = new();

    [SetUp]
    public void Setup()
    {
        _parseTree = new();
    }

    [Test]
    public void FillTreeAndCalculate_CorrectExpression_CorrectAnswerReturned()
    {
        var expression = "(* (+ 1 1) (* 5 / -10 2))";
        double expected = -50;

        _parseTree.FillTree(expression);
        var actual = _parseTree.Calculate();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FillTreeAndCalculate_CorrectLongExpression_CorrectAnswerReturned()
    {
        var expression = "(/ (+ (* 13 3) 1) (* 2 (/ (- 20 8) 6)))";
        double expected = 10;

        _parseTree.FillTree(expression);
        var actual = _parseTree.Calculate();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FillTreeAndCalculate_DivisionByZero_DivideByZeroException()
    {
        var expression = "( / 1 0 )";

        _parseTree.FillTree(expression);
        Assert.Throws<DivideByZeroException>(() => _parseTree.Calculate()); ;
    }

    [TestCase(")* 5 10(")]
    [TestCase("(* (5 10)))")]
    public void FillTreeAndCalculate_IncorrectBrackets_ArgumentException(string expression)
    {
        Assert.Throws<ArgumentException>(() => _parseTree.FillTree(")* 5 10("));
    }

    [Test]
    public void FillTreeAndCalculate_IncorrectNumber_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _parseTree.FillTree("(+ (* 1A5 2) 2)"));
    }

    [TestCase("2 + 2")]
    [TestCase("2 + ")]
    public void FillTreeAndCalculate_IncorrectExpression_ArgumentException(string expression)
    {
        Assert.Throws<ArgumentException>(() => _parseTree.FillTree(expression));
    }

    [Test]
    public void FillTreeAndCalculate_EmptyExpression_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _parseTree.FillTree(""));
    }

    [Test]
    public void FillTreeAndCalculate_Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _parseTree.FillTree(null));
    }
}