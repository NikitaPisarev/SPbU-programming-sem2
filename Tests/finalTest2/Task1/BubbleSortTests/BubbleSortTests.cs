namespace BubbleSortTests;

using BubbleSort;

public class BubbleSortTests
{
    [Test]
    public void BubbleSort_ListOfNumbers_CorrectSortListOfNumbers()
    {
        List<int> list = new List<int>() { 5, 3, 4, 2, 1 };
        List<int> expected = new List<int>() { 1, 2, 3, 4, 5 };

        BubbleSortGeneric<int>.BubbleSort(list, Comparer<int>.Default);

        Assert.That(expected, Is.EqualTo(list));
    }

    [Test]
    public void BubbleSort_ListOfStrings_CorrectSortStringOfNumbers()
    {
        List<string> list = new List<string>() { "Bob", "Alice", "Carl", "Brian" };
        List<string> expected = new List<string>() { "Alice", "Bob", "Brian", "Carl" };

        BubbleSortGeneric<string>.BubbleSort(list, Comparer<string>.Default);

        Assert.That(expected, Is.EqualTo(list));
    }

    [Test]
    public void BubbleSort_SortedList_CorrectSort()
    {
        List<int> list = new List<int>() { 1, 1, 2, 2, 3, 3 };
        List<int> expected = new List<int>() { 1, 1, 2, 2, 3, 3 };

        BubbleSortGeneric<int>.BubbleSort(list, Comparer<int>.Default);

        Assert.That(expected, Is.EqualTo(list));
    }

    [Test]
    public void BubbleSort_EmptyList_EmptyList()
    {
        List<int> list = new List<int>();

        BubbleSortGeneric<int>.BubbleSort(list, Comparer<int>.Default);

        Assert.True(list.Count == 0);
    }
}