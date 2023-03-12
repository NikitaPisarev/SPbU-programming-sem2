namespace Trie;

using System;

class Program
{
    static void PrintActions()
    {
        Console.WriteLine("""
        --------------------------------------
        0 - Exit
        1 - Add element
        2 - Remove element
        3 - Check if the element contains
        4 - Get size
        5 - Get number of elements with prefix
        6 -  View the list of commands
        --------------------------------------
        """);
    }

    static void Main()
    {
        Console.WriteLine("Hi, I'm a data structure for storing a set of strings, Trie, here's what I can do:");
        PrintActions();

        int action = 0;
        var trie = new Trie();
        var isContinue = true;
        while (isContinue)
        {
            Console.Write("Enter the command number: ");
            while (!int.TryParse(Console.ReadLine(), out action) || action < 0 || action > 6)
            {
                Console.WriteLine("Incorrect input! Enter only the number 0-6.");
                Console.Write("Try again: ");
            }
            string? str = null;

            switch (action)
            {
                case 0:
                    Console.WriteLine("Good luck!");
                    isContinue = false;
                    break;

                case 1:
                    Console.Write("Enter a string: ");
                    str = Console.ReadLine();

                    if (trie.Add(str))
                    {
                        Console.WriteLine("String added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("This string is already in Trie.");
                    }
                    break;

                case 3:
                    Console.Write("Enter a string: ");
                    str = Console.ReadLine();

                    if (trie.Contains(str))
                    {
                        Console.WriteLine("Yes, this string is in Trie!");
                    }
                    else
                    {
                        Console.WriteLine("No, this string is not in Trie.");
                    }
                    break;

                case 6:
                    PrintActions();
                    break;
            }
        }
    }
}