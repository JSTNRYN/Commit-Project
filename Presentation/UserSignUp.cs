static class UserSignUp
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the signup page");
        Console.WriteLine("Please enter your first name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Please enter your last name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Please enter your email");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your phone number");
        string phone = Console.ReadLine();
        string password = AskForPassword();
        while (!AccountsLogic.ValidatePassword(password))
        {
            Console.WriteLine("Your password does not match the criteria\nPress enter to try again!");
            password = AskForPassword();
        }
        
        if (accountsLogic.CheckIfAccountExists(email))
        {
            Console.WriteLine("Sorry, there is already an account with that email!\nPress enter to try again.");
            Console.Read();
            Start();
        }

        accountsLogic.CheckSignUp(firstName, lastName, email, phone, password, "Customer");
    }
    public static string AskForPassword()
    {
        Console.WriteLine("Please enter your password:");
        var pass = new System.Text.StringBuilder();
        for (ConsoleKeyInfo k; (k = Console.ReadKey(true)).Key != ConsoleKey.Enter;)
        {
            if (k.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                pass.Remove(pass.Length - 1, 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(k.KeyChar))
            {
                pass.Append(k.KeyChar);
                Console.Write("*");
            }
        }
        Console.WriteLine();
        string password = pass.ToString();
        return password;
    }
}