namespace TicTacToe;

using System.ComponentModel;

public class TicTacToe : INotifyPropertyChanged
{
    private string _display = "Ход первого игрока (X)";

    public string Display
    {
        get
        {
            return _display;
        }

        private set
        {
            _display = value;
            _notifyPropertyChanged(nameof(Display));
        }
    }

    private _states _currentState = _states.firstPlayerMove;

    private string[] _cells = new string[9];

    private int _currentCellsSize = 0;

    /// <summary>
    /// A data binding event that synchronizes the linked data at the time of the change.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void _notifyPropertyChanged(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private enum _states
    {
        firstPlayerMove,
        secondPlayerMove,
    }

    public string AddNewElementInCells(int numberCell)
    {
        switch (_currentState)
        {
            case _states.firstPlayerMove:
                if (_cells[numberCell] is null)
                {
                    _cells[numberCell] = "X";
                    ++_currentCellsSize;
                    Display = "Ход второго игрока (O)";
                    _checkTheEndOfGame();
                    _currentState = _states.secondPlayerMove;
                    return "X";
                }
                else
                {
                    return _cells[numberCell];
                }

            case _states.secondPlayerMove:
                if (_cells[numberCell] is null)
                {
                    _cells[numberCell] = "O";
                    ++_currentCellsSize;
                    Display = "Ход первого игрока (X)";
                    _checkTheEndOfGame();
                    _currentState = _states.firstPlayerMove;
                    return "O";
                }
                else
                {
                    return _cells[numberCell];
                }

            default: throw new ArgumentException();
        }
    }

    private void _checkTheEndOfGame()
    {
        var winCombinations = new HashSet<string> { "OOO", "XXX" };

        if (winCombinations.Contains(_cells[0] + _cells[1] + _cells[2]) ||
            winCombinations.Contains(_cells[3] + _cells[4] + _cells[5]) ||
            winCombinations.Contains(_cells[6] + _cells[7] + _cells[8]) ||
            winCombinations.Contains(_cells[0] + _cells[3] + _cells[6]) ||
            winCombinations.Contains(_cells[1] + _cells[4] + _cells[7]) ||
            winCombinations.Contains(_cells[2] + _cells[5] + _cells[8]) ||
            winCombinations.Contains(_cells[0] + _cells[4] + _cells[8]) ||
            winCombinations.Contains(_cells[2] + _cells[4] + _cells[6]))
        {
            Display = _currentState == _states.firstPlayerMove ? "Победил первый игрок! (X)" : "Победил второй игрок! (O)";
        }
        else if (_currentCellsSize == _cells.Length)
        {
            Display = "Ничья!";
        }
    }
}
