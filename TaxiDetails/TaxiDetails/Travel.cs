using System;
namespace TaxiDetails;
/// <summary>
/// class Travel about info of trips
/// </summary>
public class Travel(int id, string departurePoint, string destinationPoint, DateTime tripDate, TimeSpan travelTime, decimal cost, Car assignedCar, User client)
{
    /// <summary>
    /// identificator
    /// </summary>
    public int Id { get; set; } = id;
    /// <summary>
    /// from
    /// </summary>
    public string DeparturePoint { get; set; } = departurePoint;
    /// <summary>
    /// to
    /// </summary>
    public string DestinationPoint { get; set; } = destinationPoint;
    /// <summary>
    /// date of trip
    /// </summary>
    public DateTime TripDate { get; set; } = tripDate;
    /// <summary>
    /// time of trip
    /// </summary>
    public TimeSpan TravelTime { get; set; } = travelTime;
    /// <summary>
    /// cost
    /// </summary>
    public decimal Cost { get; set; } = cost;
    /// <summary>
    /// Relationship with car
    /// </summary>
    public Car AssignedCar { get; set; } = assignedCar;
    /// <summary>
    /// Relationship with user
    /// </summary>
    public User Client { get; set; } = client;
}