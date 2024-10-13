namespace TaxiDetails.Domain;
/// <summary>
/// class driver about info of driver
/// </summary>
/// <param name="id"></param>
/// <param name="name"></param>
/// <param name="surname"></param>
/// <param name="patronymic"></param>
/// <param name="passport"></param>
/// <param name="address"></param>
/// <param name="phone"></param>
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