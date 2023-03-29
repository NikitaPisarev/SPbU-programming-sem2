namespace ParseTree;

public class ParseTree
{
    private IParseTreeElement? _root;

    public void FillTree(string? expression)
    {
        if (expression is null)
        {
            throw new ArgumentNullException();
        }

        if (expression == string.Empty)
        {
            throw new ArgumentException("File empty.");
        }

        if (!_bracketsBalance(expression))
        {
            throw new ArgumentException("Incorrect expression.");
        }

        var tokens = expression.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var currentIndex = -1;
        double value = 0;

        IParseTreeElement AddTreeElement()
        {
            currentIndex++;

            if (currentIndex == tokens.Length)
            {
                throw new ArgumentException("Incorrect expression.");
            }

            if (double.TryParse(tokens[currentIndex], out value))
            {
                return new Operand(value);
            }

            Operation newTreeElement;
            switch (tokens[currentIndex])
            {
                case "*":
                    newTreeElement = new Multiplication();
                    break;

                case "/":
                    newTreeElement = new Division();

                    break;
                case "+":
                    newTreeElement = new Addition();

                    break;
                case "-":
                    newTreeElement = new Subtraction();
                    break;

                default:
                    throw new ArgumentException("Incorrect expression.");
            }

            newTreeElement.LeftChild = AddTreeElement();
            newTreeElement.RightChild = AddTreeElement();
            return newTreeElement;
        }

        _root = AddTreeElement();

        if (currentIndex != tokens.Length - 1)
        {
            throw new ArgumentException("Incorrect expression.");
        }
    }

    public double Calculate() => _root!.Calculate();

    public void Print() => _root!.Print();

    private bool _bracketsBalance(string expression)
    {
        var result = 0;
        foreach (var i in expression)
        {
            if (i == '(')
            {
                ++result;
            }

            if (i == ')')
            {
                --result;
            }

            if (result < 0)
            {
                return false;
            }
        }

        return result == 0;
    }
}