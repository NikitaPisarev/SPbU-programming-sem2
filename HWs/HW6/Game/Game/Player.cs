namespace Game;

/// <summary>
/// Player Type.
/// </summary>
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

    /// <summary>
    /// Current coordinates of the player on the map.
    /// </summary>
    public (int X, int Y) Coordinates { get; set; }

    /// <summary>
    /// Current Player Health Points.
    /// </summary>
    public int Health { get; set; }
}