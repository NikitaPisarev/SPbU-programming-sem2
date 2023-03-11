namespace StackCalculator;

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hi, I'm a stack calculator, I can calculate an expression written in reverse Polish notation!");
        Console.Write("Enter your expression: ");
        string? expression = Console.ReadLine();

        while (expression == null || expression == "")
        {
            Console.Write("Error! The expression can't be empty.\nTry again: ");
            expression = Console.ReadLine();
        }

        var stackArray = new StackArray();
        var stackCalculator = new StackCalculator(stackArray);

        var result = stackCalculator.CalculateExpression(expression);

        Console.WriteLine($"Answer: {result}\nGood luck!");
    }
}