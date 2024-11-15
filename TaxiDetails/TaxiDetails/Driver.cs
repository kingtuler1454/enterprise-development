namespace TaxiDetails;
/// <summary>
/// class driver about info of driver
/// </summary>
public class Driver
{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// name of driver
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// surname of driver
    /// </summary>
    public string? Surname { get; set; } 
    /// <summary>
    /// patronymic of driver
    /// </summary>
    public string? Patronymic { get; set; }
    /// <summary>
    /// passport of driver
    /// </summary>
    public string? Passport { get; set; }
    /// <summary>
    /// address of driver
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// phone of driver
    /// </summary>
    public string? Phone { get; set; }
    
}