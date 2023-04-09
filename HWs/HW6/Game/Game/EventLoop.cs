namespace Game;

public delegate bool EventHandler<EventArgs>(object sender, EventArgs e);

public class EventLoop
{
    public event EventHandler<EventArgs>? LeftHandler;

    public event EventHandler<EventArgs>? RightHandler;

    public event EventHandler<EventArgs>? UpHandler;

    public event EventHandler<EventArgs>? DownHandler;

    public event EventHandler<EventArgs>? ExitHandler;

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
