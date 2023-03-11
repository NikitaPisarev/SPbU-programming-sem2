namespace StackCalculator;

using System;
using System.Diagnostics;

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
        double result = 0;
        var time = new Stopwatch();

        time.Start();
        result = stackCalculator.CalculateExpression(expression);
        time.Stop();
        Console.WriteLine($"\nResponse received on stack based on ARRAY: {result}");
        Console.WriteLine($"Time: {time.ElapsedMilliseconds} milliseconds");

        var stackList = new StackList();
        stackCalculator = new StackCalculator(stackList);

        time.Restart();
        result = stackCalculator.CalculateExpression(expression);
        time.Stop();
        Console.WriteLine($"\nResponse received on stack based on LIST: {result}");
        Console.WriteLine($"Time: {time.ElapsedMilliseconds} milliseconds\n\nGood luck!");
    }
}