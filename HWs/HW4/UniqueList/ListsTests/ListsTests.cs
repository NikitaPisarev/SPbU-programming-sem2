namespace ListsTest;

using Lists;

public class ListTests
{
    private static IEnumerable<TestCaseData> Lists
        => new TestCaseData[]
    {
        new(new List()),
        new(new UniqueList()),
    };

    [TestCaseSource(nameof(Lists))]
    public void Add_Element_NotEmptyList(List list)
    {
        list.Add(10);

        Assert.IsFalse(list.IsEmpty());
    }

    [TestCaseSource(nameof(Lists))]
    public void AddAndRemove_Element_EmptyList(List list)
    {
        list.Add(10);
        list.Remove(10);

        Assert.IsTrue(list.IsEmpty());
    }

    [TestCaseSource(nameof(Lists))]
    public void Remove_NonexistentElement_RemoveNonexistentElementExceptionReturned(List list)
    {
        Assert.Throws<RemoveNonexistentElementException>(() => list.Remove(1));
    }

    [TestCaseSource(nameof(Lists))]
    public void AddAndRemove_Elements_CorrectElementsReturned(List list)
    {
        list.Add(20);
        list.Add(30);

        Assert.IsTrue(list.Remove(20));
        Assert.IsTrue(list.Remove(30));
        Assert.IsTrue(list.IsEmpty());
    }

    [TestCaseSource(nameof(Lists))]
    public void Replace_CorrectIndex_CorrectReplaced(List list)
    {
        list.Add(20);
        Assert.IsTrue(list.Replace(30, 0));
        Assert.IsTrue(list.Remove(30));
    }

    [TestCaseSource(nameof(Lists))]
    public void Replace_IncorrectIndex_CorrectReplaced(List list)
    {
        Assert.IsFalse(list.Replace(30, 0));
    }
}