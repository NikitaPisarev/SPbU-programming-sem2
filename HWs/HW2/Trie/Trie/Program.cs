namespace Trie;

using static System.Console;

class Program
{
    static void PrintActions()
    {
        WriteLine("""
        --------------------------------------
        0 - Exit
        1 - Add element
        2 - Remove element
        3 - Check if the element contains
        4 - Get number of strings
        5 - Get number of elements with prefix
        6 - View the list of commands
        --------------------------------------
        """);
    }

    static void Main()
    {
        WriteLine("Hi, I'm a data structure for storing a set of strings, Trie, here's what I can do:");
        PrintActions();

        int action = 0;
        var trie = new Trie();
        var isContinue = true;
        while (isContinue)
        {
            Write("Enter the command number: ");
            while (!int.TryParse(ReadLine(), out action) || action < 0 || action > 6)
            {
                WriteLine("Incorrect input! Enter only the number 0-6.");
                Write("Try again: ");
            }
            string? str = "";

            switch (action)
            {
                case 0:
                    WriteLine("Good luck!");
                    isContinue = false;
                    break;

                case 1:
                    Write("Enter a string: ");
                    str = ReadLine();

                    WriteLine(trie.Add(str) ? "String added successfully!" : "This string is already in Trie.");
                    break;

                case 2:
                    Write("Enter a string: ");
                    str = ReadLine();

                    WriteLine(trie.Remove(str) ? "String removes successfully!" : "This string is not in Trie.");
                    break;

                case 3:
                    Write("Enter a string: ");
                    str = ReadLine();

                    WriteLine(trie.Contains(str) ? "Yes, this string is in Trie!" : "No, this string is not in Trie.");
                    break;

                case 4:
                    WriteLine($"Number of strings: {trie.Size}");
                    break;

                case 5:
                    Write("Enter a prefix: ");
                    str = ReadLine();

                    WriteLine($"Number of lines, prefixed with \"{str}\": {trie.HowManyStartsWithPrefix(str)}");
                    break;

                case 6:
                    PrintActions();
                    break;
            }
        }
    }
}