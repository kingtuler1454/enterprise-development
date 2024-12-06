using Microsoft.EntityFrameworkCore;
using TaxiDetails.Context;
namespace TaxiDetails.Repositories;
public class TravelRepository(TaxiDetailsDbContext context) : IRepository<Travel, int>
{
    /// <summary>
    /// delete travel of identificator.
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var travel = await Get(id);

        if (travel == null)
        {
            return false;
        }
        context.Travels.Remove(travel);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// search and return of identificator
    /// </summary>
    public async Task<Travel?> Get(int id) => await context.Travels.Include(t => t.AssignedCar).ThenInclude(t => t.AssignedDriver).Include(t => t.Client).FirstOrDefaultAsync(travel => travel.Id == id);

    /// <summary>
    /// return all travels
    /// </summary>
    public async Task<IEnumerable<Travel>> GetAll() => await context.Travels.Include(t => t.AssignedCar).ThenInclude(t => t.AssignedDriver).Include(t => t.Client).ToListAsync();

    /// <summary>
    /// add new travel
    /// </summary>
    public async Task<Travel> Post(Travel travel)
    {
        context.Travels.Add(travel);
        await context.SaveChangesAsync();
        return travel;
    }

    /// <summary>
    /// update travel of identification
    /// </summary>
    public async Task<bool> Put(Travel travel, int id)
    {
        var existingTravel = await Get(id);
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
        await context.SaveChangesAsync();
        return true;
    }
}

