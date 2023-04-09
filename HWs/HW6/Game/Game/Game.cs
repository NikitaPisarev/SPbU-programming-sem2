namespace Game;
using static System.Console;

public class Game
{
    public Game(string filePath)
    {
        try
        {
            _map = File.ReadAllLines(filePath);
            if (_map.Count() == 0 || _map[0].Count() == 0)
            {
                throw new ArgumentException("File empty.");
            }
        }
        catch (Exception e) when (e is ArgumentException || e is ArgumentNullException
                                  || e is IOException || e is DirectoryNotFoundException)
        {
            throw;
        }

        _currentCoordinates = findTheStartingPoint();
        if (_currentCoordinates == (0, 0))
        {
            throw new ArgumentException("Inccorect map.");
        }

        _drawTheMap();
    }

    private (int X, int Y) _currentCoordinates = (0, 0);

    private string[] _map;

    private enum _direction
    {
        Up,
        Left,
        Down,
        Right
    }

    private (int, int) findTheStartingPoint()
    {
        var result = (0, 0);
        var isFreePoint = false;
        for (int i = 1; i < _map.Count(); ++i)
        {
            for (int j = 1; j < _map[0].Count(); ++j)
            {
                if (_map[i][j] == ' ')
                {
                    result = (j, i);
                    isFreePoint = true;
                    break;
                }
            }

            if (isFreePoint)
            {
                break;
            }
        }

        return result;
    }

    private void _drawTheMap()
    {
        Write(string.Join("\n", _map));
        _setPlayer((_currentCoordinates.X, _currentCoordinates.Y));
    }

    private void _move(_direction direction)
    {
        Write(' ');
        switch (direction)
        {
            case _direction.Left:
                _setPlayer((_currentCoordinates.X - 1, _currentCoordinates.Y));
                break;
            case _direction.Right:
                _setPlayer((_currentCoordinates.X + 1, _currentCoordinates.Y));
                break;
            case _direction.Up:
                _setPlayer((_currentCoordinates.X, _currentCoordinates.Y - 1));
                break;
            case _direction.Down:
                _setPlayer((_currentCoordinates.X, _currentCoordinates.Y + 1));
                break;
        }
    }
    private void _setPlayer((int, int) newPosition)
    {
        SetCursorPosition(newPosition.Item1, newPosition.Item2);
        Write("@");
        SetCursorPosition(newPosition.Item1, newPosition.Item2);
        this._currentCoordinates = newPosition;
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        if (_map[_currentCoordinates.Y][_currentCoordinates.X - 1] == ' ')
        {
            _move(_direction.Left);
        }
    }

    public void OnRight(object? sender, EventArgs args)
    {
        if (_map[_currentCoordinates.Y][_currentCoordinates.X + 1] == ' ')
        {
            _move(_direction.Right);
        }
    }

    public void OnUp(object? sender, EventArgs args)
    {
        if (_map[_currentCoordinates.Y - 1][_currentCoordinates.X] == ' ')
        {
            _move(_direction.Up);
        }
    }

    public void OnDown(object? sender, EventArgs args)
    {
        if (_map[_currentCoordinates.Y + 1][_currentCoordinates.X] == ' ')
        {
            _move(_direction.Down);
        }
    }

    public void Exit(object? sender, EventArgs args)
    {
        SetCursorPosition(_map[0].Count(), _map.Count());
    }
}
