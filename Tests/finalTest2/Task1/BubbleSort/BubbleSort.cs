namespace BubbleSort;

/// <summary>
/// Static class, for implementing bubble sorting with generic type.
/// </summary>
/// <typeparam name="T"> Type of element in the list. </typeparam>
public static class BubbleSortGeneric<T>
{
    private static void Swap(List<T> list, int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }

    /// <summary>
    /// Bubble Sorting.
    /// </summary>
    /// <param name="list"> List of elements. </param>
    /// <param name="comparer"> Сomparer for comparing list elements. </param>
    public static void BubbleSort(List<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (comparer.Compare(list[i], list[j]) > 0)
                {
                    Swap(list, j, i);
                }
            }
        }
    }
}