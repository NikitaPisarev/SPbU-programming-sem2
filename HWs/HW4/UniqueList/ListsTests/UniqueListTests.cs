namespace ListsTest;
using Lists;

public class UniqueListTests
{
    private UniqueList _list = new();

    [SetUp]
    public void Setup()
    {
        _list = new();
    }

    [Test]
    public void Add_SameElements_ElementAlreadyExistException()
    {
        _list.Add(10);

        Assert.Throws<ElementAlreadyExistException>(() => _list.Add(10));
    }

    [Test]
    public void Replace_SameElements_ElementAlreadyExistException()
    {
        _list.Add(10);
        _list.Add(20);

        Assert.Throws<ElementAlreadyExistException>(() => _list.Replace(10, 1));
    }
}
