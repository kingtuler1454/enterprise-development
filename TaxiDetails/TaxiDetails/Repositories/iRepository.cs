namespace TaxiDetails.Domain.Repositories
{
    public interface IRepository<T, TKey>
    {
        /// <summary>
        /// Получить коллекцию всех объектов типа T.
        /// </summary>
        /// <returns>Список объектов типа T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получить объект типа T по заданному индексу.
        /// </summary>
        /// <param name="id">Идентификатор нужного объекта типа T.</param>
        /// <returns>Объект типа T или null, если объект не найден.</returns>
        T? Get(TKey id);

        /// <summary>
        /// Добавить объект типа T в коллекцию.
        /// </summary>
        /// <param name="obj">Экземпляр объекта типа T, который необходимо добавить в коллекцию.</param>
        void Post(T obj);

        /// <summary>
        /// Заменить объект типа T с заданным индексом в коллекции.
        /// </summary>
        /// <param name="obj">Новый экземпляр объекта типа T, которым мы заменяем старый.</param>
        /// <param name="id">Идентификатор заменяемого объекта типа T.</param>
        /// <returns>True, если замена прошла успешно; иначе, false.</returns>
        bool Put(T obj, TKey id);

        /// <summary>
        /// Удалить объект типа T с заданным индексом из коллекции.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого объекта типа T.</param>
        /// <returns>True, если удаление прошло успешно; иначе, false.</returns>
        bool Delete(TKey id);
    }
}
