

//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    public static AccountModel? CurrentAccount { get; private set; }
    private AccountsAccess _access = new();

    public AccountsLogic()
    {
        // Could do something here

    }

    public AccountModel CheckLogin(string email, string password)
    {
        AccountModel acc = _access.GetByEmail(email);

        if (acc != null && BCrypt.Net.BCrypt.Verify(password, acc.Password))
        {
            CurrentAccount = acc;
            return acc;
        }

        return null;
    }

    public void CheckSignUp(string firstname, string lastname, string email, string phone, string password, string role)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        _access.Write(new AccountModel
        {
            Email = email,
            Password = hashedPassword,
            FirstName = firstname,
            LastName = lastname,
            Phone = phone,
            Role = role
        });
    }
    

    public bool CheckIfAccountExists(string email)
    {
        AccountModel acc = _access.GetByEmail(email);
        return acc != null;
    }
}




