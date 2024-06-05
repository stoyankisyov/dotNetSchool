namespace BookCatalog.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T item);
    }
}
