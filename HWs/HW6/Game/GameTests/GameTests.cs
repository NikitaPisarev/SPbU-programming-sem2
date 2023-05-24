namespace GameTests;

using Game;

public class Tests
{
    private Game? _game;

    [TestCase("../../../TestFilesResults/TestFileMove.txt", "../../../TestFiles/TestFile.txt")]
    public void Move_CorrectInputMap_CorrectOutputMap(string fileResultPath, string fileTestPath)
    {
        _game = new(fileTestPath);
        var expected = File.ReadAllLines(fileResultPath);

        _game!.OnRight(this, EventArgs.Empty);
        _game.OnRight(this, EventArgs.Empty);
        _game.OnDown(this, EventArgs.Empty);
        var actual = _game.GetMapAndPlayer();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("../../../TestFilesResults/TestFileHealing.txt", "../../../TestFiles/TestFile.txt")]
    public void Healing_CorrectMap_CorrectOutputMap(string fileResultPath, string fileTestPath)
    {
        _game = new(fileTestPath);
        var expected = File.ReadAllLines(fileResultPath);

        _game.OnDown(this, EventArgs.Empty);
        var actual = _game.GetMapAndPlayer();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("../../../TestFilesResults/TestFileDamage.txt", "../../../TestFiles/TestFile.txt")]
    public void Damage_CorrectMap_CorrectOutputMap(string fileResultPath, string fileTestPath)
    {
        _game = new(fileTestPath);
        var expected = File.ReadAllLines(fileResultPath);

        _game.OnRight(this, EventArgs.Empty);
        _game.OnDown(this, EventArgs.Empty);

        var actual = _game.GetMapAndPlayer();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("../../../TestFilesResults/TestFileWithOneFreePointResult.txt", "../../../TestFiles/TestFileWithOneFreePoint.txt")]
    public void Move_MapFithOneFreePoint_CorrectOutpuMap(string fileResultPath, string fileTestPath)
    {
        _game = new(fileTestPath);
        var expected = File.ReadAllLines(fileResultPath);

        _game.OnRight(this, EventArgs.Empty);
        var actual = _game.GetMapAndPlayer();
        Assert.That(actual, Is.EqualTo(expected));

        _game.OnLeft(this, EventArgs.Empty);
        actual = _game.GetMapAndPlayer();
        Assert.That(actual, Is.EqualTo(expected));

        _game.OnDown(this, EventArgs.Empty);
        actual = _game.GetMapAndPlayer();
        Assert.That(actual, Is.EqualTo(expected));

        _game.OnUp(this, EventArgs.Empty);
        actual = _game.GetMapAndPlayer();
        Assert.That(actual, Is.EqualTo(expected));
    }
}