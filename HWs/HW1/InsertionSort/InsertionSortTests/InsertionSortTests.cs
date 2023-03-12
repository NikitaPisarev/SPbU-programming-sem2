namespace InsertionSortTests;

using InsertionSort;

public class Tests
{
    [Test]
    public void InsertionSort_BasicArray_BasicArrayReturned()
    {
        var originalArray = new int[] { 4, 1, 3, 2 };
        var expectedArray = new int[] { 1, 2, 3, 4 };

        InsertionSort.Program.SortByInsertionSort(originalArray);

        Assert.That(originalArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void InsertionSort_EmptyArray_EmptyArrayReturned()
    {
        var originalArray = new int[] { };
        var expectedArray = new int[] { };

        InsertionSort.Program.SortByInsertionSort(originalArray);

        Assert.That(originalArray, Is.EqualTo(expectedArray));
    }

    [Test]
    public void InsertionSort_SortArray_SortArrayReturned()
    {
        var originalArray = new int[] { 0, 2, 2, 9 };
        var expectedArray = new int[] { 0, 2, 2, 9 };

        InsertionSort.Program.SortByInsertionSort(originalArray);

        Assert.That(originalArray, Is.EqualTo(expectedArray));
    }
}