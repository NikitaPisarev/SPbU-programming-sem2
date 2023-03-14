namespace StackCalculator;

/// <summary>
///  Class for polish postfix expression calculation.
/// </summary>
public class StackCalculator
{
    public StackCalculator(IStack stack)
    {
        this._stack = stack;
    }

    private readonly IStack _stack;

    private static bool IsZero(double number)
    {
        return Math.Abs(number) < 0.0001;
    }

    private void Operations(string sign)
    {
        double firstElement = 0;
        double secondElement = 0;

        try
        {
            firstElement = _stack.Pop();
            secondElement = _stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        switch (sign)
        {
            case "+":
                _stack.Push(firstElement + secondElement);
                break;

            case "-":
                _stack.Push(secondElement - firstElement);
                break;

            case "*":
                _stack.Push(firstElement * secondElement);
                break;

            case "/":
                if (IsZero(firstElement))
                {
                    throw new DivideByZeroException();
                }

                _stack.Push(secondElement / firstElement);
                break;
        }
    }

    /// <summary>
    /// A method for calculating the Polish postfix expression.
    /// </summary>
    /// <param name="expression"> Expression in reverse Polish notation. </param>
    /// <returns> Value of expression. </returns>
    public double CalculateExpression(string? expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression), "can't be null.");
        }

        if (expression == string.Empty)
        {
            throw new ArgumentException(nameof(expression), "can't be empty.");
        }

        string operations = "+-*/";
        foreach (var element in expression.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            if (operations.Contains(element))
            {
                Operations(element);
            }
            else
            {
                double number = 0;
                if (!double.TryParse(element, out number))
                {
                    throw new ArgumentException("Incorrect expression.");
                }
                _stack.Push(number);
            }
        }

        double result = 0;
        try
        {
            result = _stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        if (!_stack.IsEmpty())
        {
            throw new ArgumentException("Incorrect expression.");
        }

        return result;
    }
}