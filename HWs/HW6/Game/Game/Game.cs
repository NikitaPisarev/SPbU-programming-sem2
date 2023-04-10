namespace Game;

using static System.Console;
using System.Text;

internal class Player
{
    public Player((int, int) coordinates, int health)
    {
        this.Coordinates = coordinates;
        this.Health = health;
    }

    public Player(int health)
        : this((0, 0), 100)
    {
        this.Health = health;
    }

    public Player((int, int) coordinates)
        : this((0, 0), 100)
    {
        this.Coordinates = coordinates;
    }

    public Player()
        : this((0, 0), 100)
    {
    }

    public (int X, int Y) Coordinates { get; set; }

    public int Health { get; set; }
}

public class Game
{
    public Game(string filePath)
    {
        string[] storage;
        try
        {
            storage = File.ReadAllLines(filePath);
            if (storage.Count() == 0 || storage[0].Count() == 0)
            {
                throw new ArgumentException("File empty.");
            }
        }
        catch (Exception e) when (e is ArgumentException || e is ArgumentNullException
                                  || e is IOException || e is DirectoryNotFoundException)
        {
            throw;
        }

        for (int i = 0; i < storage.Count(); ++i)
        {
            _map.Add(new StringBuilder(storage[i]));
        }

        this._player = new Player(_findTheStartingPoint());

        if (_player.Coordinates == (0, 0))
        {
            throw new ArgumentException("Inccorect map.");
        }

        _drawTheMap();
    }

    public string[] GetMapAndPlayer()
    {
        _map[_player.Coordinates.Y][_player.Coordinates.X] = '@';
        var result = new string[_map.Count + 1];
        for (int i = 0; i < _map.Count; i++)
        {
            result[i] = _map[i].ToString();
        }
        result[_map.Count] = $"Health: {_player.Health}";
        _map[_player.Coordinates.Y][_player.Coordinates.X] = ' ';
        return result;
    }

    private List<StringBuilder> _map = new List<StringBuilder>();

    private Player _player;

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
    }

    private (int, int) _findTheStartingPoint()
    {
        var result = (0, 0);
        var isFreePoint = false;
        for (int i = 1; i < _map.Count(); ++i)
        {
            for (int j = 1; j < _map[0].Length; ++j)
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
        WriteLine(string.Join("\n", _map));
        ForegroundColor = ConsoleColor.Green;
        Write($"Health: {this._player.Health}");
        _setPlayer((_player.Coordinates.X, _player.Coordinates.Y));
    }

    private void _useHilling()
    {
        this._player.Health += 10;

        if (this._player.Health > 25 && this._player.Health <= 75)
        {
            ForegroundColor = ConsoleColor.Yellow;
        }

        if (this._player.Health > 75)
        {
            ForegroundColor = ConsoleColor.Green;
        }
        _changeHealthPoints();
    }

    private void _takeDamage()
    {
        this._player.Health -= 25;

        if (this._player.Health <= 25)
        {
            ForegroundColor = ConsoleColor.Red;
        }

        if (this._player.Health > 25 && this._player.Health <= 75)
        {
            ForegroundColor = ConsoleColor.Yellow;
        }

        _changeHealthPoints();
    }

    private void _changeHealthPoints()
    {
        SetCursorPosition(_map[0].Length, _map.Count());
        WriteLine($"\rHealth: {this._player.Health}     ");
        SetCursorPosition(_player.Coordinates.X, _player.Coordinates.Y);
    }

    private void _move(Direction direction)
    {
        Write(' ');
        switch (direction)
        {
            case Direction.Left:
                _setPlayer((_player.Coordinates.X - 1, _player.Coordinates.Y));
                break;
            case Direction.Right:
                _setPlayer((_player.Coordinates.X + 1, _player.Coordinates.Y));
                break;
            case Direction.Up:
                _setPlayer((_player.Coordinates.X, _player.Coordinates.Y - 1));
                break;
            case Direction.Down:
                _setPlayer((_player.Coordinates.X, _player.Coordinates.Y + 1));
                break;
        }
    }

    private void _setPlayer((int, int) newPosition)
    {
        SetCursorPosition(newPosition.Item1, newPosition.Item2);
        _map[newPosition.Item2][newPosition.Item1] = ' ';
        Write("@");
        SetCursorPosition(newPosition.Item1, newPosition.Item2);
        this._player.Coordinates = newPosition;
    }

    private void _gameOver()
    {
        Console.Clear();
        WriteLine("YOU DIED");
    }

    private bool _chooseAction(Direction direction)
    {
        char point = direction switch
        {
            Direction.Left => _map[_player.Coordinates.Y][_player.Coordinates.X - 1],
            Direction.Right => _map[_player.Coordinates.Y][_player.Coordinates.X + 1],
            Direction.Up => _map[_player.Coordinates.Y - 1][_player.Coordinates.X],
            Direction.Down => _map[_player.Coordinates.Y + 1][_player.Coordinates.X],
            _ => throw new ArgumentException(),
        };

        switch (point)
        {
            case 'h':
                _useHilling();
                _move(direction);
                break;

            case '!':
                _takeDamage();
                if (_player.Health <= 0)
                {
                    _gameOver();
                    return false;
                }
                _move(direction);
                break;

            case ' ':
                _move(direction);
                break;
        }
        return true;
    }

    public bool OnLeft(object? sender, EventArgs args)
    {
        return _chooseAction(Direction.Left);
    }

    public bool OnRight(object? sender, EventArgs args)
    {
        return _chooseAction(Direction.Right);
    }

    public bool OnUp(object? sender, EventArgs args)
    {
        return _chooseAction(Direction.Up);
    }

    public bool OnDown(object? sender, EventArgs args)
    {
        return _chooseAction(Direction.Down);
    }

    public bool Exit(object? sender, EventArgs args)
    {
        Console.Clear();
        Console.ResetColor();
        Write("Good luck!");
        return false;
    }
}