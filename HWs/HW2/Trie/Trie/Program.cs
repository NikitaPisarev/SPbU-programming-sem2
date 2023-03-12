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
        var isContinue = true;
        while (isContinue)
        {
            Console.Write("Enter the command number: ");
            while (!int.TryParse(Console.ReadLine(), out action) || action < 0 || action > 6)
            {
                Console.WriteLine("Incorrect input! Enter only the number 0-6.");
                Console.Write("Try again: ");
            }

            switch (action)
            {
                case 0:
                    Console.WriteLine("Good luck!");
                    isContinue = false;
                    break;

                case 6:
                    PrintActions();
                    break;
            }
        }
    }
}