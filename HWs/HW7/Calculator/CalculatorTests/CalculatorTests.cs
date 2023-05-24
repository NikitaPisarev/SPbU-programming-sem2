namespace CalculatorTests;

using Calculator;

public class Tests
{
    private Calculator _calculator = new();

    [TearDown]
    public void Teardown()
    {
        _calculator.ClearCalculator();
    }

    private void AddMathExpressionInCalculator(string expression)
    {
        foreach (var i in expression)
        {
            if (char.IsDigit(i))
            {
                _calculator.AddNumberInCalculator(i);
            }
            if ("+-*/".Contains(i))
            {
                _calculator.AddOperationInCalcultor(i);
            }
            if (i == '=')
            {
                _calculator.Calculate();
            }
        }
    }

    [TestCase("2 + 2 +", "4")]
    [TestCase("3 * 9 + 18 =", "45")]
    [TestCase("3 - 66 =", "-63")]
    public void Calculate_BasicExpression_CorrectAnswerReturned(string expression, string expected)
    {
        AddMathExpressionInCalculator(expression);
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("14 / 2 * 9 + 0 - 14 / 7 + 3 =", "10")]
    [TestCase("100 * 141 - 3 + 12 / 3 - 4115 + 14 =", "602")]
    public void Calculate_LongExpression_CorrectAnswerReturned(string expression, string expected)
    {
        AddMathExpressionInCalculator(expression);
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Calculate_ChooseOperation_CorrectAnswer()
    {
        var expected = "5";

        AddMathExpressionInCalculator("10 +*/- 5 =");
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Calculate_ManyEquals_CorrectAnswer()
    {
        var expected = "3";

        AddMathExpressionInCalculator("10 - 7 ====");
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Calculate_DivisionByZero_ErrorReturned()
    {
        var expected = "Error";

        AddMathExpressionInCalculator("1 / 0 =");
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("2 + 2 +", "-4")]
    [TestCase("3", "-3")]
    [TestCase("-66 =", "66")]
    public void ChangeSign_Number_CorrectAnswer(string expression, string expected)
    {
        AddMathExpressionInCalculator(expression);
        _calculator.ChangeSign();
        var actual = _calculator.Display;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AddNumber_IncorrectNumber_ArgumentExceptionReturned()
    {
        Assert.Throws<ArgumentException>(() => _calculator.AddNumberInCalculator('A'));
    }

    [Test]
    public void AddOperation_IncorrectOperation_ArgumentExceptionReturned()
    {
        Assert.Throws<ArgumentException>(() => _calculator.AddOperationInCalcultor('5'));
    }
}