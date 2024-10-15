namespace TaxiDetails;
/// <summary>
/// class driver about info of driver
/// </summary>
public class Driver(int id, string name, string surname, string patronymic, string passport, string address, string phone)
{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; } = id;
    /// <summary>
    /// name of driver
    /// </summary>
    public string Name { get; set; } = name;
    /// <summary>
    /// surname of driver
    /// </summary>
    public string Surname { get; set; } = surname;
    /// <summary>
    /// patronymic of driver
    /// </summary>
    public string Patronymic { get; set; } = patronymic;
    /// <summary>
    /// passport of driver
    /// </summary>
    public string Passport { get; set; } = passport;
    /// <summary>
    /// address of driver
    /// </summary>
    public string Address { get; set; } = address;
    /// <summary>
    /// phone of driver
    /// </summary>
    public string Phone { get; set; } = phone;
}