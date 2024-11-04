namespace TaxiDetails.Domain.Repositories
{
    public class TravelRepository : IRepository<Travel, int>
    {
        private readonly List<Travel> _travels = new();
        private int _id = 1;

        /// <summary>
        /// Удаляет поездку по идентификатору.
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
        /// Находит и возвращает поездку по идентификатору.
        /// </summary>
        public Travel? Get(int id) => _travels.Find(travel => travel.Id == id);

        /// <summary>
        /// Возвращает все поездки.
        /// </summary>
        public IEnumerable<Travel> GetAll() => _travels;

        /// <summary>
        /// Добавляет новую поездку в репозиторий.
        /// </summary>
        public void Post(Travel travel)
        {
            travel.Id = _id++;
            _travels.Add(travel);
        }

        /// <summary>
        /// Обновляет существующую поездку по идентификатору.
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
}
