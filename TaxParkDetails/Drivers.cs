namespace TaxParkDetails.Domain;
public class Driver
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Passport { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public Driver(string name,string surname, string patronymic, string passport, string address, string phone)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Passport = passport;
        Address = address;
        Phone = phone;
    }
}