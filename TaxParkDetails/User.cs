namespace TaxParkDetails.Domain;
public class User
{
    public string Phone { get; set; }
    public string FullName { get; set; }

    public User(string phone, string fullName)
    {
        Phone = phone;
        FullName = fullName;
    }
}