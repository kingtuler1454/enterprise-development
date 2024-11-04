namespace TaxiDetails.Domain.Repositories
{
    public class CarRepository : IRepository<Car, int>
    {
        private readonly List<Car> _cars = new();
        private int _id = 1;

        /// <summary>
        /// Удаляет автомобиль по идентификатору.
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
        /// Находит и возвращает автомобиль по идентификатору.
        /// </summary>
        public Car? Get(int id) => _cars.Find(car => car.Id == id);

        /// <summary>
        /// Возвращает все автомобили.
        /// </summary>
        public IEnumerable<Car> GetAll() => _cars;

        /// <summary>
        /// Добавляет новый автомобиль в репозиторий.
        /// </summary>
        public void Post(Car car)
        {
            car.Id = _id++;
            _cars.Add(car);
        }

        /// <summary>
        /// Обновляет существующий автомобиль по идентификатору.
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
}
