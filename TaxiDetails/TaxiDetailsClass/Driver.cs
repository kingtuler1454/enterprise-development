namespace TaxiDetailsClass.Domain;
public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Passport { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public Driver(int id,string name,string surname, string patronymic, string passport, string address, string phone)
    {
        Id= id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Passport = passport;
        Address = address;
        Phone = phone;
    }
}