namespace Calculator;

using System.ComponentModel;

public class Calculator : INotifyPropertyChanged
{
    private string _display = "0";

    public string Display
    {
        get
        {
            return _display;
        }

        private set
        {
            _display = value;
            _notifyPropertyChanged();
        }
    }

    private string _intermediateValue = "0";

    private char _currentOperation = ' ';

    private _states _currentState = _states.NumberTyping;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void _notifyPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private enum _states
    {
        NumberTyping,
        Operation,
        Error,
    }

    public void AddNumberInCalcultor(char number)
    {
        switch (_currentState)
        {
            case _states.Error:
            case _states.NumberTyping:
                if (Display == "0" || Display == "Error")
                {
                    Display = number.ToString();
                }
                else
                {
                    Display += number;
                }

                _currentState = _states.NumberTyping;
                break;

            case _states.Operation:
                _intermediateValue = Display;
                Display = number.ToString();
                _currentState = _states.NumberTyping;
                break;
        }
    }

    public void AddOperationInCalcultor(char operation)
    {
        switch (_currentState)
        {
            case _states.NumberTyping:
                if (_currentOperation == ' ')
                {
                    _intermediateValue = Display;
                    _currentOperation = operation;
                    _currentState = _states.Operation;
                }
                else
                {
                    try
                    {
                        Display = _calculation().ToString();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        _currentState = _states.Error;
                        return;
                    }

                    _intermediateValue = Display;
                    _currentOperation = operation;
                    _currentState = _states.Operation;
                }
                break;

            case _states.Operation:
                _currentOperation = operation;
                break;

            case _states.Error:
                break;
        }
    }

    public void Calculate()
    {
        double result = 0;

        switch (_currentState)
        {
            case _states.Error:
            case _states.NumberTyping:
                if (_currentOperation != ' ')
                {
                    try
                    {
                        result = _calculation();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        _currentState = _states.Error;
                        return;
                    }

                    Display = result.ToString();
                    _currentOperation = ' ';
                    _currentState = _states.NumberTyping;
                }
                break;

            case _states.Operation:
                try
                {
                    result = _calculation();
                }
                catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                {
                    ClearCalculator();
                    Display = "Error";
                    _currentState = _states.Error;
                    return;
                }

                Display = result.ToString();
                break;
        }
    }

    public void ChangeSign()
    {
        if (_currentState != _states.Error && Display != "0")
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

    public void ClearCalculator()
    {
        Display = "0";
        _intermediateValue = "0";
        _currentOperation = ' ';
        _currentState = _states.NumberTyping;
    }

    private double _calculation()
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
