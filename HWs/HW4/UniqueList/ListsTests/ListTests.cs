namespace ListsTest;

using Lists;

public class ListTests
{
    private List _list = new();

    [SetUp]
    public void Setup()
    {
        _list = new();
    }

    [Test]
    public void Add_Element_NotEmptyList()
    {
        _list.Add(10);

        Assert.IsFalse(_list.IsEmpty());
    }

    [Test]
    public void AddAndRemove_Element_EmptyList()
    {
        _list.Add(10);
        _list.Remove(10);

        Assert.IsTrue(_list.IsEmpty());
    }

    [Test]
    public void AddAndRemove_Elements_CorrectElementsReturned()
    {
        _list.Add(20);
        _list.Add(30);

        Assert.IsTrue(_list.Remove(20));
        Assert.IsFalse(_list.Remove(20));
        Assert.IsTrue(_list.Remove(30));
        Assert.IsTrue(_list.IsEmpty());
    }

    [Test]
    public void Replace_CorrectIndex_CorrectReplaced()
    {
        _list.Add(20);
        Assert.IsTrue(_list.Replace(30, 0));
        Assert.IsTrue(_list.Remove(30));

    }

    [Test]
    public void Replace_IncorrectIndex_CorrectReplaced()
    {
        Assert.IsFalse(_list.Replace(30, 0));
    }
}