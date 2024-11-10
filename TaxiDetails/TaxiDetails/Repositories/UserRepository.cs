namespace TaxiDetails.Domain;
public class UserRepository : IRepository<User, int>
{
    private readonly List<User> _users = [];
    private int _id = 1;

    /// <summary>
    /// delete user of identificator
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
    /// search and refresh of identificator
    /// </summary>
    public User? Get(int id) => _users.Find(user => user.Id == id);

    /// <summary>
    /// return all users
    /// </summary>
    public IEnumerable<User> GetAll() => _users;

    /// <summary>
    /// add new user
    /// </summary>
    public void Post(User user)
    {
        user.Id = _id++;
        _users.Add(user);
    }

    /// <summary>
    /// update of user
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
