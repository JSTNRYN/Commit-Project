public class AccountModel
{

    public Int64 Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    
    public AccountModel() { }

    public AccountModel(Int64 id, string email, string password, string firstname, string lastname, string phone, string role)
    {
        Id = id;
        Email = email;
        Password = password;
        FirstName = firstname;
        LastName = lastname;
        Phone = phone;
        Role = role;
    }
}



