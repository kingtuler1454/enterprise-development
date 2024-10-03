using System;

namespace TaxParkDetails.Domain;
public class Tavels
{
    public string DeparturePoint { get; set; }
    public string DestinationPoint { get; set; }
    public DateTime TripDate { get; set; }
    public TimeSpan TravelTime { get; set; }
    public decimal Cost { get; set; }
    public Car AssignedCar { get; set; }

    public Travels(string departurePoint, string destinationPoint, DateTime tripDate, TimeSpan travelTime, decimal cost, Car assignedCar)
    {
        DeparturePoint = departurePoint;
        DestinationPoint = destinationPoint;
        TripDate = tripDate;
        TravelTime = travelTime;
        Cost = cost;
        AssignedCar = assignedCar;
    }
}