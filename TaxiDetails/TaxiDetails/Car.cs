namespace TaxiDetails;
/// <summary>
/// class about car
/// </summary>
public class Car(int id, string plate, string model, string color, Driver assignedDriver)
{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; } = id;
    /// <summary>
    /// number of car
    /// </summary>
    public string Plate { get; set; } = plate;
    /// <summary>
    /// model of car
    /// </summary>
    public string Model { get; set; } = model;
    /// <summary>
    /// color
    /// </summary>
    public string Color { get; set; } = color;
    /// <summary>
    /// relationship of driver
    /// </summary>
    public Driver AssignedDriver { get; set; } = assignedDriver;
}