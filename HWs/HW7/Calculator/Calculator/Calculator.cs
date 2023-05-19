namespace Calculator;

using System.ComponentModel;

/// <summary>
/// A class that implements a calculator with 5 operations: '+', '-', '*', '/', '+/-'.
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    private string _display = "0";

    /// <summary>
    /// String representation of a number that is displayed somewhere.
    /// </summary>
    public string Display
    {
        get
        {
            return _display;
        }

        private set
        {
            _display = value;
            NotifyPropertyChanged();
        }
    }

    private string _intermediateValue = "0";

    private char _currentOperation = ' ';

    private States _currentState = States.NumberTyping;

    /// <summary>
    /// A data binding event that synchronizes the linked data at the time of the change.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private enum States
    {
        NumberTyping,
        Operation,
        Error,
    }

    /// <summary>
    /// Add an number to the calculator.
    /// </summary>
    /// <param name="operation"> The number must be a digit. </param>
    /// <exception cref="ArgumentException"></exception>
    public void AddNumberInCalcultor(char number)
    {
        if (!char.IsDigit(number))
        {
            throw new ArgumentException();
        }

        switch (_currentState)
        {
            case States.Error:
            case States.NumberTyping:
                if (Display == "0" || Display == "Error")
                {
                    Display = number.ToString();
                }
                else
                {
                    Display += number;
                }

                _currentState = States.NumberTyping;
                break;

            case States.Operation:
                _intermediateValue = Display;
                Display = number.ToString();
                _currentState = States.NumberTyping;
                break;
        }
    }

    /// <summary>
    /// Add an operation to the calculator.
    /// </summary>
    /// <param name="operation"> The operation can be "+ - * / × ÷". </param>
    /// <exception cref="ArgumentException"></exception>
    public void AddOperationInCalcultor(char operation)
    {
        if (!"+-/*×÷".Contains(operation))
        {
            throw new ArgumentException();
        }

        switch (_currentState)
        {
            case States.NumberTyping:
                if (_currentOperation == ' ')
                {
                    _intermediateValue = Display;
                    _currentOperation = operation;
                    _currentState = States.Operation;
                }
                else
                {
                    try
                    {
                        Display = Calculation().ToString();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        _currentState = States.Error;
                        return;
                    }

                    _intermediateValue = Display;
                    _currentOperation = operation;
                    _currentState = States.Operation;
                }
                break;

            case States.Operation:
                _currentOperation = operation;
                break;

            case States.Error:
                break;
        }
    }

    /// <summary>
    /// Calculate the current expression in the calculator.
    /// </summary>
    public void Calculate()
    {
        double result = 0;

        switch (_currentState)
        {
            case States.Error:
            case States.NumberTyping:
                if (_currentOperation != ' ')
                {
                    try
                    {
                        result = Calculation();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        _currentState = States.Error;
                        return;
                    }

                    Display = result.ToString();
                    _currentOperation = ' ';
                    _currentState = States.NumberTyping;
                }
                break;

            case States.Operation:
                try
                {
                    result = Calculation();
                }
                catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                {
                    ClearCalculator();
                    Display = "Error";
                    _currentState = States.Error;
                    return;
                }

                Display = result.ToString();
                break;
        }
    }

    /// <summary>
    /// Change the sign of the current value.
    /// </summary>
    public void ChangeSign()
    {
        if (_currentState != States.Error && Display != "0")
        {
            if (Display[0] == '-')
            {
                Display = Display.Substring(1);
            }
            else
            {
                Display = "-" + Display;
            }
        }
    }

    /// <summary>
    /// Clear the calculator.
    /// </summary>
    public void ClearCalculator()
    {
        Display = "0";
        _intermediateValue = "0";
        _currentOperation = ' ';
        _currentState = States.NumberTyping;
    }

    private double Calculation()
    {
        switch (_currentOperation)
        {
            case '+':
                return double.Parse(_intermediateValue) + double.Parse(Display);

            case '-':
                return double.Parse(_intermediateValue) - double.Parse(Display);

            case '*':
            case '×':
                return double.Parse(_intermediateValue) * double.Parse(Display);

            case '/':
            case '÷':
                if (Math.Abs(double.Parse(Display)) < 0.001)
                {
                    throw new DivideByZeroException();
                }
                return double.Parse(_intermediateValue) / double.Parse(Display);

            default: throw new ArgumentException();
        }
    }
}
