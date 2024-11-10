namespace TaxiDetails.Domain;
public class TravelRepository : IRepository<Travel, int>
{
    private readonly List<Travel> _travels = [];
    private int _id = 1;

    /// <summary>
    /// delete travel of identificator.
    /// </summary>
    public bool Delete(int id)
    {
        var travel = Get(id);

        if (travel == null)
        {
            return false;
        }
        _travels.Remove(travel);
        return true;
    }

    /// <summary>
    /// search and return of identificator
    /// </summary>
    public Travel? Get(int id) => _travels.Find(travel => travel.Id == id);

    /// <summary>
    /// return all travels
    /// </summary>
    public IEnumerable<Travel> GetAll() => _travels;

    /// <summary>
    /// add new travel
    /// </summary>
    public void Post(Travel travel)
    {
        travel.Id = _id++;
        _travels.Add(travel);
    }

    /// <summary>
    /// update travel of identification
    /// </summary>
    public bool Put(Travel travel, int id)
    {
        var existingTravel = Get(id);
        if (existingTravel == null)
        {
            return false;
        }
        existingTravel.DeparturePoint = travel.DeparturePoint;
        existingTravel.DestinationPoint = travel.DestinationPoint;
        existingTravel.TripDate = travel.TripDate;
        existingTravel.TravelTime = travel.TravelTime;
        existingTravel.Cost = travel.Cost;
        existingTravel.AssignedCar = travel.AssignedCar;
        existingTravel.Client = travel.Client;
        return true;
    }
}

