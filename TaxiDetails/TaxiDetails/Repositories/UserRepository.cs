using Microsoft.EntityFrameworkCore;
using TaxiDetails.Context;
namespace TaxiDetails.Repositories;
public class UserRepository(TaxiDetailsDbContext context) : IRepository<User, int>
{
    /// <summary>
    /// delete user of identificator
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var user = await Get(id);

        if (user == null)
        {
            return false;
        }
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// search and refresh of identificator
    /// </summary>
    public async Task<User?> Get(int id) => await context.Users.FirstOrDefaultAsync(user => user.Id == id);

    /// <summary>
    /// return all users
    /// </summary>
    public async Task<IEnumerable<User>> GetAll() => await context.Users.ToListAsync();

    /// <summary>
    /// add new user
    /// </summary>
    public async Task<User> Post(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    /// <summary>
    /// update of user
    /// </summary>
    public async Task<bool> Put(User user, int id)
    {
        var existingUser = await Get(id);
        if (existingUser == null)
        {
            return false;
        }
        existingUser.Phone = user.Phone;
        existingUser.FullName = user.FullName;
        await context.SaveChangesAsync();
        return true;
    }
}
