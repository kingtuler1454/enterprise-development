using Microsoft.EntityFrameworkCore;
using TaxiDetails.Context;
namespace TaxiDetails.Repositories;
public class CarRepository(TaxiDetailsDbContext context) : IRepository<Car, int>
{
    /// <summary>
    /// delete auto of identificator
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var car = await Get(id);

        if (car == null)
        {
            return false;
        }
        context.Cars.Remove(car);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///search and return of identificator
    /// </summary>
    public async Task<Car?> Get(int id) => await context.Cars.Include(c => c.AssignedDriver).FirstOrDefaultAsync(car => car.Id == id);

    /// <summary>
    /// return all cars
    /// </summary>
    public async Task<IEnumerable<Car>> GetAll() => await context.Cars.Include(c => c.AssignedDriver).ToListAsync();

    /// <summary>
    /// add new car
    /// </summary>
    public async Task<Car> Post(Car car)
    {
        context.Cars.Add(car);
        await context.SaveChangesAsync();
        return car;
    }

    /// <summary>
    /// update auto
    /// </summary>
    public async Task<bool> Put(Car car, int id)
    {
        var existingCar = await Get(id);
        if (existingCar == null)
        {
            return false;
        }
        existingCar.Plate = car.Plate;
        existingCar.Model = car.Model;
        existingCar.Color = car.Color;
        existingCar.AssignedDriver = car.AssignedDriver;
        await context.SaveChangesAsync();
        return true;
    }
}

