namespace Game;

/// <summary>
/// Instantiation of the EventHandler template, allowing to return True or False.
/// </summary>
/// <param name="sender"> The sender. </param>
/// <param name="e"> Event parameters. </param>
/// <returns> True if the game continues, otherwise False. </returns>
public delegate bool EventHandler<EventArgs>(object sender, EventArgs e);

/// <summary>
/// The processing loop of user actions.
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Subject of left arrow press.
    /// </summary>
    public event EventHandler<EventArgs>? LeftHandler;

    /// <summary>
    /// Subject of right arrow press.
    /// </summary>
    public event EventHandler<EventArgs>? RightHandler;

    /// <summary>
    /// Subject of up arrow press.
    /// </summary>
    public event EventHandler<EventArgs>? UpHandler;

    /// <summary>
    /// Subject of down arrow press.
    /// </summary>
    public event EventHandler<EventArgs>? DownHandler;

    /// <summary>
    /// Subject of pressing the other buttons. Exit from the game.
    /// </summary>
    public event EventHandler<EventArgs>? ExitHandler;

    /// <summary>
    /// Method to run observing actions of user.
    /// </summary>
    public void Run()
    {
        var isContinue = true;
        while (isContinue)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (LeftHandler is not null)
                    {
                        isContinue = LeftHandler(this, EventArgs.Empty);
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (RightHandler is not null)
                    {
                        isContinue = RightHandler(this, EventArgs.Empty);
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (UpHandler is not null)
                    {
                        isContinue = UpHandler(this, EventArgs.Empty);
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (DownHandler is not null)
                    {
                        isContinue = DownHandler(this, EventArgs.Empty);
                    }
                    break;

                default:
                    if (ExitHandler is not null)
                    {
                        isContinue = ExitHandler(this, EventArgs.Empty);
                    }
                    break;
            }
        }
    }
}
