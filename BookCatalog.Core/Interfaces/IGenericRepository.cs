namespace BookCatalog.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T item);
        T Get();
    }
}
