using System;
using System.Text;

static class UserSignUp
{
    private static AccountsLogic accountsLogic = new AccountsLogic();

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Account Registration\n");

        string firstName = PromptInput("First name");
        string lastName = PromptInput("Last name");
        string email = PromptInput("Email");
        string phone = PromptInput("Phone number");

        string password = AskForPassword();

        while (!AccountsLogic.ValidatePassword(password))
        {
            ShowError("Password must be at least 6 characters with 1 number and 1 special character.");
            Console.WriteLine("Press Enter to try again.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Account Registration\n");
            DisplayValue("First name", firstName);
            DisplayValue("Last name", lastName);
            DisplayValue("Email", email);
            DisplayValue("Phone number", phone);

            password = AskForPassword();
        }

        if (accountsLogic.CheckIfAccountExists(email))
        {
            ShowError("An account with this email already exists.");
            Console.WriteLine("Press Enter to restart.");
            Console.ReadLine();
            Start();
            return;
        }

        accountsLogic.CheckSignUp(firstName, lastName, email, phone, password, "Customer");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAccount created successfully!");
        Console.ResetColor();

        Console.WriteLine("Press Enter to return to the main menu");
        Console.ReadLine();
        Menu.Start();
    }

    private static string PromptInput(string label)
    {
        Console.Write($"{label}: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    private static void DisplayValue(string label, string value)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{label}: {value}");
        Console.ResetColor();
    }

    public static string AskForPassword()
    {
        Console.Write("Password ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("(min 6 chars, 1 number, 1 special character)");
        Console.ResetColor();
        Console.Write(": ");

        StringBuilder pass = new StringBuilder();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (pass.Length > 0)
                {
                    pass.Remove(pass.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                pass.Append(keyInfo.KeyChar);
                Console.Write("*");
            }
        }

        Console.WriteLine();
        return pass.ToString();
    }

    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }
}