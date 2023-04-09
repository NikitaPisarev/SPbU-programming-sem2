using Game;
using static System.Console;

Game.Game game;
try
{
    game = new Game.Game("map.txt");
}
catch (Exception e) when (e is ArgumentException || e is ArgumentNullException
                          || e is IOException || e is DirectoryNotFoundException)
{
    WriteLine(e.Message);
    return;
}
var eventLoop = new EventLoop();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.UpHandler += game.OnUp;
eventLoop.DownHandler += game.OnDown;
eventLoop.ExitHandler += game.Exit;

eventLoop.Run();
Console.ReadKey();