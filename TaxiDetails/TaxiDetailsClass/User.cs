namespace TaxiDetailsClass.Domain;
public class User
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }

    public User(int id,string phone, string fullName)
    {
        id = id;
        Phone = phone;
        FullName = fullName;
    }
}