namespace TaxiDetails;
/// <summary>
/// class Travel about info of trips
/// </summary>
public class Travel{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// from
    /// </summary>
    public string? DeparturePoint { get; set; }
    /// <summary>
    /// to
    /// </summary>
    public string? DestinationPoint { get; set; }
    /// <summary>
    /// date of trip
    /// </summary>
    public DateTime? TripDate { get; set; }
    /// <summary>
    /// time of trip
    /// </summary>
    public TimeSpan? TravelTime { get; set; }
    /// <summary>
    /// cost
    /// </summary>
    public decimal? Cost { get; set; } 
    /// <summary>
    /// Relationship with car
    /// </summary>
    public Car? AssignedCar { get; set; } 
    /// <summary>
    /// Relationship with user
    /// </summary>
    public User? Client { get; set; }
}