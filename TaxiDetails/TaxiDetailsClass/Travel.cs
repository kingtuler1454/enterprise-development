using System;
namespace TaxiDetailsClass.Domain;
public class Travel
{ public int Id { get; set; }
    public string DeparturePoint { get; set; }
    public string DestinationPoint { get; set; }
    public DateTime TripDate { get; set; }
    public TimeSpan TravelTime { get; set; }
    public decimal Cost { get; set; }
    public Car AssignedCar { get; set; }
    
    public User Client { get; set; }

    public Travel(int id, string departurePoint, string destinationPoint, DateTime tripDate, TimeSpan travelTime, decimal cost, Car assignedCar, User client)
    {
        Id = id;
        DeparturePoint = departurePoint;
        DestinationPoint = destinationPoint;
        TripDate = tripDate;
        TravelTime = travelTime;
        Cost = cost;
        AssignedCar = assignedCar;
        Client = client;
    }
}