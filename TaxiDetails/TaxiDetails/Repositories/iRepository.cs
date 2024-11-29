namespace TaxiDetails.Repositories;
public interface IRepository<T, TKey>
{
    /// <summary>
    /// get colletiocn
    /// </summary>
    /// <returns>list of T.</returns>
    Task<IEnumerable<T>> GetAll();

    /// <summary>
    /// get T of indentificator
    /// </summary>
    /// <param name="id">identificator of id.</param>
    /// <returns>Object T</returns>
    Task<T?> Get(TKey id);

    /// <summary>
    /// Add object T
    /// </summary>
    /// <param name="obj">Object of collection</param>
    Task<T> Post(T obj);

    /// <summary>
    /// refresh object
    /// </summary>
    /// <param name="obj">New object of collection</param>
    /// <param name="id">identificator of object</param>
    /// <returns>True of False about operation</returns>
    Task<bool> Put(T obj, TKey id);

    /// <summary>
    /// delete object T
    /// </summary>
    /// <param name="id">Identificator of delete</param>
    /// <returns>True of False about operation</returns>
    Task<bool> Delete(TKey id);
}
