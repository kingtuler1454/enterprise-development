namespace TaxiDetails.Repositories;
public class DriverRepository : IRepository<Driver, int>
{
    private readonly List<Driver> _drivers = [];
    private int _id = 1;

    /// <summary>
    /// delete driver of identificator.
    /// </summary>
    public bool Delete(int id)
    {
        var driver = Get(id);

        if (driver == null)
        {
            return false;
        }
        _drivers.Remove(driver);
        return true;
    }

    /// <summary>
    /// search and return driver on identificator
    /// </summary>
    public Driver? Get(int id) => _drivers.Find(driver => driver.Id == id);

    /// <summary>
    /// return all drivers.
    /// </summary>
    public IEnumerable<Driver> GetAll() => _drivers;

    /// <summary>
    /// add new driver.
    /// </summary>
    public void Post(Driver driver)
    {
        driver.Id = _id++;
        _drivers.Add(driver);
    }

    /// <summary>
    ///update driver of identificator
    /// </summary>
    public bool Put(Driver driver, int id)
    {
        var existingDriver = Get(id);
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
        return true;
    }
}

