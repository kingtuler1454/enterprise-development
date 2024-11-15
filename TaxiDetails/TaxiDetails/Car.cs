namespace TaxiDetails;
/// <summary>
/// class about car
/// </summary>
public class Car
{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// number of car
    /// </summary>
    public string? Plate { get; set; }
    /// <summary>
    /// model of car
    /// </summary>
    public string? Model { get; set; }
    /// <summary>
    /// color
    /// </summary>
    public string? Color { get; set; }
    /// <summary>
    /// relationship of driver
    /// </summary>
    public Driver? AssignedDriver { get; set; } 
}