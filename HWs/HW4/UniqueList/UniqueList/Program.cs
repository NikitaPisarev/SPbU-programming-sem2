using static System.Console;

using Lists;

static void PrintActions()
{
    WriteLine("""
    --------------------------------------
    0 - Exit
    1 - Add element
    2 - Remove element
    3 - Change element by position
    4 - Print list
    5 - View the list of commands
    --------------------------------------
    """);
}

WriteLine("Hi, I am a List data structure that does not store duplicate value, here's what I can do:");
PrintActions();

int action = 0;
var isContinue = true;
var uniqueList = new UniqueList();
int value = 0;
int index = 0;

while (isContinue)
{
    Write("Enter the command number: ");
    while (!int.TryParse(ReadLine(), out action) || action < 0 || action > 5)
    {
        WriteLine("Incorrect input! Enter only the number 0-5.");
        Write("Try again: ");
    }

    switch (action)
    {
        case 0:
            WriteLine("Good luck!");
            isContinue = false;
            break;

        case 1:
            Write("Enter a value: ");
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Incorrect input! Element can only be an integer.");
                Console.Write("Try again: ");
            }

            try
            {
                uniqueList.Add(value);
            }
            catch (ElementAlreadyExistException)
            {
                WriteLine("Error! This element is already in the list.");
                break;
            }
            WriteLine("The element was successfully added to the list.");
            break;

        case 2:
            Write("Enter a value: ");
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Incorrect input! Element can only be an integer.");
                Console.Write("Try again: ");
            }

            try
            {
                uniqueList.Remove(value);
            }
            catch (RemoveNonexistentElementException)
            {
                WriteLine("Error! There is no such item in the list.");
                break;
            }
            WriteLine("The element was successfully removed from the list.");
            break;

        case 3:
            Write("Enter the index of the element you want to replace: ");
            while (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Incorrect input! Index can only be an integer.");
                Console.Write("Try again: ");
            }

            Write($"Enter the value to which you want to change the element number {index}: ");
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Incorrect input! Element can only be an integer.");
                Console.Write("Try again: ");
            }

            try
            {
                if (uniqueList.Replace(value, index))
                {
                    WriteLine("The element was successfully replaced.");
                }
                else
                {
                    WriteLine("This index is not in the list.");
                }
            }
            catch (ElementAlreadyExistException)
            {
                WriteLine("Error! This element is already in the list.");
                break;
            }
            break;

        case 4:
            Write("[ ");
            foreach (var i in uniqueList.GetList())
            {
                Write($"{i} ");
            }
            WriteLine("]");
            break;

        case 5:
            PrintActions();
            break;
    }
}
