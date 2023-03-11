namespace StackCalculator;

internal class StackCalculator
{
    public StackCalculator(IStack stack)
    {
        this.stack = stack;
    }

    private readonly IStack stack;

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
            firstElement = stack.Pop();
            secondElement = stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        switch (sign)
        {
            case "+":
                stack.Push(firstElement + secondElement);
                break;

            case "-":
                stack.Push(secondElement - firstElement);
                break;

            case "*":
                stack.Push(firstElement * secondElement);
                break;

            case "/":
                if (IsZero(secondElement))
                {
                    throw new DivideByZeroException();
                }

                stack.Push(firstElement / secondElement);
                break;
        }
    }

    public double CalculateExpression(string expression)
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
                stack.Push(number);
            }
        }

        double result = 0;
        try
        {
            result = stack.Pop();
        }
        catch (InvalidOperationException)
        {
            throw new ArgumentException("Incorrect expression.");
        }

        if (!stack.IsEmpty())
        {
            throw new ArgumentException("Incorrect expression.");
        }

        return result;
    }
}