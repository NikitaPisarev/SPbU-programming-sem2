﻿namespace BWT;

using System;
using System.Text;

internal class RotationsComparer : IComparer<int>
{
    public RotationsComparer(string str)
    {
        this._string = str;
    }

    private string _string;

    int IComparer<int>.Compare(int firstElement, int secondElement)
    {
        for (int i = 0; i < _string.Length; ++i)
        {
            if (_string[(firstElement + i) % _string.Length] > _string[(secondElement + i) % _string.Length])
            {
                return 1;
            }
            else if (_string[(firstElement + i) % _string.Length] < _string[(secondElement + i) % _string.Length])
            {
                return -1;
            }
        }
        return 0;
    }
}

public class Program
{
    private const int _alphabetSize = 65536;

    public static (string, int) Encode(string text)
    {
        var rotations = new int[text.Length];
        for (int i = 0; i < rotations.Length; ++i)
        {
            rotations[i] = i;
        }

        Array.Sort(rotations, new RotationsComparer(text));

        var result = new StringBuilder();
        int lineEndNumber = 0;
        for (int i = 0; i < text.Length; ++i)
        {
            result.Append(text[(rotations[i] + text.Length - 1) % text.Length]);

            if (rotations[i] == 0)
            {
                lineEndNumber = i;
            }
        }

        return (result.ToString(), lineEndNumber);
    }

    public static string Decode(string text, int matrixIndex)
    {
        if (text.Length == 0)
        {
            throw new ArgumentException("Text cannot be empty.");
        }

        var characterFrequencies = new int[_alphabetSize];
        for (int i = 0; i < text.Length; ++i)
        {
            ++characterFrequencies[text[i]];
        }

        int sum = 0;
        for (int i = 0; i < _alphabetSize; ++i)
        {
            sum += characterFrequencies[i];
            characterFrequencies[i] = sum - characterFrequencies[i];
        }

        var nextSymbolsIndexes = new int[text.Length];
        for (int i = 0; i < text.Length; ++i)
        {
            nextSymbolsIndexes[characterFrequencies[text[i]]] = i;
            ++characterFrequencies[text[i]];
        }

        var nextSymbol = nextSymbolsIndexes[matrixIndex];
        var result = new StringBuilder();
        for (int i = 0; i < text.Length; ++i)
        {
            result.Append(text[nextSymbol]);
            nextSymbol = nextSymbolsIndexes[nextSymbol];
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Hi, I can encode and decode a text using the Burrows-Wheeler transform.");
        Console.Write("Choose what you need [encode/decode]: ");

        string? action = "";

        while (action != "0")
        {
            action = Console.ReadLine();
            if (action == null)
            {
                throw new ArgumentNullException("Text cannot be null.");
            }
            action = action.ToLower();

            switch (action)
            {
                case "encode":
                    Console.Write("Good! Enter your text: ");
                    string? textForEncode = Console.ReadLine();
                    while (textForEncode == null)
                    {
                        textForEncode = Console.ReadLine();
                    }

                    (string encodedText, int index) resultEncode = Encode(textForEncode);
                    Console.WriteLine($"Converted text: {resultEncode.encodedText}\nLine end number: {resultEncode.index}");
                    Console.Write("Don't want to see the reverse transformation? (Enter DECODE): ");
                    break;

                case "decode":
                    Console.Write("Good! Enter your text: ");
                    string? textForDecode = Console.ReadLine();
                    while (string.IsNullOrEmpty(textForDecode))
                    {
                        Console.WriteLine("Incorrect input!");
                        Console.WriteLine("The text cannot be empty.");
                        Console.Write("Try again: ");
                        textForDecode = Console.ReadLine();
                    }

                    Console.Write("Good! Enter the number of the original row in the sorted matrix: ");
                    int indexMatrix = -1;
                    while (!int.TryParse(Console.ReadLine(), out indexMatrix) ||
                           indexMatrix < 0 || indexMatrix >= textForDecode.Length)
                    {
                        Console.WriteLine("Incorrect input!");
                        Console.WriteLine("The number of the original row is a non-negative number and less than the length of the text.");
                        Console.Write("Try again: ");
                    }

                    string resultDecode = Decode(textForDecode, indexMatrix);

                    Console.WriteLine($"The original line looked like this: {resultDecode}");
                    Console.Write("Do you want to encode a text? (Enter ENCODE): ");
                    break;

                case "0":
                    Console.WriteLine("Bye!");
                    break;

                default:
                    Console.Write("Enter ENCODE/DECODE (or 0 to exit): ");
                    break;
            }
        }
    }
}