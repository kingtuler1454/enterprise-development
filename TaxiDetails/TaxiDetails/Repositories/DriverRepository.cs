using Microsoft.EntityFrameworkCore;
using TaxiDetails.Context; 
namespace TaxiDetails.Repositories;
public class DriverRepository(TaxiDetailsDbContext context) : IRepository<Driver, int>
{
    /// <summary>
    /// delete driver of identificator.
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var driver = await Get(id);

        if (driver == null)
        {
            return false;
        }
        context.Drivers.Remove(driver);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// search and return driver on identificator
    /// </summary>
    public async Task<Driver?> Get(int id) => await context.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);

    /// <summary>
    /// return all drivers.
    /// </summary>
    public async Task<IEnumerable<Driver>> GetAll() => await context.Drivers.ToListAsync();

    /// <summary>
    /// add new driver.
    /// </summary>
    public async Task<Driver> Post(Driver driver)
    {
        context.Drivers.Add(driver);
        await context.SaveChangesAsync();
        return driver;
    }

    /// <summary>
    ///update driver of identificator
    /// </summary>
    public async Task<bool> Put(Driver driver, int id)
    {
        var existingDriver = await Get(id);
        if (existingDriver == null)
        {
            return false;
        }
        existingDriver.Name = driver.Name;
        existingDriver.Surname = driver.Surname;
        existingDriver.Patronymic = driver.Patronymic;
        existingDriver.Passport = driver.Passport;
        existingDriver.Address = driver.Address;
        existingDriver.Phone = driver.Phone;
        await context.SaveChangesAsync();
        return true;
    }
}

