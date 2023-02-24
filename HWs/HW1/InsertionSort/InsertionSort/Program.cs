namespace InsertionSort;

using System;

class Program
{
    static void PrintArray(int[] array)
    {
        Console.Write("[ ");
        int sizeArray = array.Length;
        for (int i = 0; i < sizeArray; ++i)
        {
            Console.Write($"{array[i]} ");
        }
        Console.Write("]");
    }

    static void Swap(ref int firstElement, ref int secondElement)
    {
        int temp = firstElement;
        firstElement = secondElement;
        secondElement = temp;
    }

    static void SortByInsertionSort(int[] array)
    {
        int sizeArray = array.Length;
        for (int i = 1; i < sizeArray; ++i)
        {
            int j = i;
            while (j != 0 && array[j] < array[j - 1])
            {
                Swap(ref array[j], ref array[j - 1]);
                --j;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Hi, I'm sorting an array!");
        Console.Write("Enter the size of the array: ");
        int sizeArray = 0;
        while (!int.TryParse(Console.ReadLine(), out sizeArray) || sizeArray <= 0)
        {
            Console.WriteLine("Incorrect input! The size of the array must be a positive number");
            Console.Write("Try again: ");
        }

        var array = new int[sizeArray];

        Console.WriteLine("Enter the array elements:");
        for (int i = 0; i < sizeArray; ++i)
        {
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Incorrect input! The array element must be an integer");
                Console.Write("Try again: ");
            }
        }

        SortByInsertionSort(array);

        Console.WriteLine("Sorted array:");
        PrintArray(array);
    }
}