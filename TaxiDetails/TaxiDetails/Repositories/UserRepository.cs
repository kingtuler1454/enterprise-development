namespace TaxiDetails.Domain.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly List<User> _users = new();
        private int _id = 1;

        /// <summary>
        /// Удаляет пользователя по идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            var user = Get(id);

            if (user == null)
            {
                return false;
            }
            _users.Remove(user);
            return true;
        }

        /// <summary>
        /// Находит и возвращает пользователя по идентификатору.
        /// </summary>
        public User? Get(int id) => _users.Find(user => user.Id == id);

        /// <summary>
        /// Возвращает всех пользователей.
        /// </summary>
        public IEnumerable<User> GetAll() => _users;

        /// <summary>
        /// Добавляет нового пользователя в репозиторий.
        /// </summary>
        public void Post(User user)
        {
            user.Id = _id++;
            _users.Add(user);
        }

        /// <summary>
        /// Обновляет существующего пользователя по идентификатору.
        /// </summary>
        public bool Put(User user, int id)
        {
            var existingUser = Get(id);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.Phone = user.Phone;
            existingUser.FullName = user.FullName;
            return true;
        }
    }
}
