using static System.Console;

static void PrintActions()
{
    WriteLine("""
    --------------------------------------
    0 - Exit
    1 - Add element
    2 - Remove element
    3 - Change element by position
    4 - View the list of commands
    --------------------------------------
    """);
}

WriteLine("Hi, I am a List data structure that does not store duplicate value, here's what I can do:");
PrintActions();

int action = 0;
var isContinue = true;
while (isContinue)
{
    Write("Enter the command number: ");
    while (!int.TryParse(ReadLine(), out action) || action < 0 || action > 4)
    {
        WriteLine("Incorrect input! Enter only the number 0-4.");
        Write("Try again: ");
    }

    switch (action)
    {
        case 0:
            WriteLine("Good luck!");
            isContinue = false;
            break;

        case 1:
            break;

        case 2:
            break;

        case 3:
            break;

        case 4:
            PrintActions();
            break;
    }
}
