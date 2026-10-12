static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.Clear();
        if (AccountsLogic.LoggedIn())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You are currently logged in as: {AccountsLogic.CurrentAccount.FirstName} {AccountsLogic.CurrentAccount.LastName}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You are currently not logged in.");
            Console.ResetColor();
        }
        Console.WriteLine("Enter 1 to login");
        Console.WriteLine("Enter 2 to sign up");
        Console.WriteLine("Enter 3 to do something else in the future");

        string input = Console.ReadLine();
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
            UserSignUp.Start();
        }
        else if (input == "3")
        {
            Console.WriteLine("This feature is not yet implemented");
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}