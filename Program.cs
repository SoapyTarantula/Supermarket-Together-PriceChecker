// Here's a dumb little program to calculate item prices for a co-op supermarket game.
// If an item is priced 2x or more than its current market price, shoppers won't buy it.
// We round to the next highest $0.10 below x2 market price to make change counting easier.

string userInput = string.Empty;
Start();

 void Start(){
    Console.Clear();
    Console.WriteLine("Please enter the market price of the item, without periods or commas.");
    Console.Write("Or you can press "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("C"); Console.ResetColor(); Console.Write(" to close the program.");
    Console.WriteLine();
    userInput = Console.ReadLine();
    HandleInput(userInput.ToLower());
}

void HandleInput(string input)
{
    Console.Clear();
    if (input.Trim() != null)
    {
        bool isNum = int.TryParse(input, out _);
        if (isNum)
        {
            Console.WriteLine("Input seems to be a number.");
            NumberChecker(Convert.ToInt16(input));
        }
        else if (input.Equals("c"))
        {
            Console.WriteLine("Closing...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        else {
            Console.WriteLine("Something went wrong during input handling, starting over.");
            Thread.Sleep(1000);
            Start();
        }
    }
    else
    {
        Console.WriteLine("Input seems to have been null, starting over.");
        Thread.Sleep(1200);
        Start();
    }
}

 void NumberChecker(int originalNumber)
{
    Console.Clear();
    var newNumber = originalNumber * 2;
    // If the new number already ends on a zero after being doubled, we can just remove 10.
    if (newNumber % 10 == 0)
    {
        newNumber -= 10;
        Console.WriteLine($"Market price is: {originalNumber:d}\nThe correct price after our -10 cent adjustment is {newNumber:d}");
        Thread.Sleep(2000);
        Console.ReadLine();
        Start();
    }
    else
    {
        Console.WriteLine($"Market price is: {originalNumber:d}\nThe correct price after our -10 cent adjustment is: {NumberSnipper(newNumber):d}");
        Thread.Sleep(2000);
        Console.ReadLine();
        Start();
    }
    // If the new number doesn't end with a 0, we have to cut off numbers until it does.
    int NumberSnipper(int num)
    {
        while (num % 10 != 0) // Holy shit a while loop that doesn't lock the program up.
        {
            num--;
        }
        return num;
    }
}