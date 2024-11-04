namespace TaxiDetails.Domain.Repositories
{
    public class DriverRepository : IRepository<Driver, int>
    {
        private readonly List<Driver> _drivers = new();
        private int _id = 1;

        /// <summary>
        /// Удаляет водителя по идентификатору.
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
        /// Находит и возвращает водителя по идентификатору.
        /// </summary>
        public Driver? Get(int id) => _drivers.Find(driver => driver.Id == id);

        /// <summary>
        /// Возвращает всех водителей.
        /// </summary>
        public IEnumerable<Driver> GetAll() => _drivers;

        /// <summary>
        /// Добавляет нового водителя в репозиторий.
        /// </summary>
        public void Post(Driver driver)
        {
            driver.Id = _id++;
            _drivers.Add(driver);
        }

        /// <summary>
        /// Обновляет существующего водителя по идентификатору.
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
}
