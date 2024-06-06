namespace BookCatalog.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task SaveAsync(T item);
    }
}
