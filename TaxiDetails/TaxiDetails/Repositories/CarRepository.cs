namespace TaxiDetails.Domain;
public class CarRepository : IRepository<Car, int>
{
    private readonly List<Car> _cars = [];
    private int _id = 1;

    /// <summary>
    /// delete auto of identificator
    /// </summary>
    public bool Delete(int id)
    {
        var car = Get(id);

        if (car == null)
        {
            return false;
        }
        _cars.Remove(car);
        return true;
    }

    /// <summary>
    ///search and return of identificator
    /// </summary>
    public Car? Get(int id) => _cars.Find(car => car.Id == id);

    /// <summary>
    /// return all cars
    /// </summary>
    public IEnumerable<Car> GetAll() => _cars;

    /// <summary>
    /// add new car
    /// </summary>
    public void Post(Car car)
    {
        car.Id = _id++;
        _cars.Add(car);
    }

    /// <summary>
    /// update auto
    /// </summary>
    public bool Put(Car car, int id)
    {
        var existingCar = Get(id);
        if (existingCar == null)
        {
            return false;
        }
        existingCar.Plate = car.Plate;
        existingCar.Model = car.Model;
        existingCar.Color = car.Color;
        existingCar.AssignedDriver = car.AssignedDriver;
        return true;
    }
}

