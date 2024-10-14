namespace TaxiDetails;
/// <summary>
/// class User about info of users
/// </summary>
/// <param name="id"></param>
/// <param name="phone"></param>
/// <param name="fullName"></param>
public class User(int id, string phone, string fullName)
{   /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; } = id;
    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; } = phone;
    /// <summary>
    /// Fullname
    /// </summary>
    public string FullName { get; set; } = fullName;
}