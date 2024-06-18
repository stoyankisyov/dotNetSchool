using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces
{
    public interface ICatalog
    {
        Dictionary<string, Book> Books { get; }
        void Add(Book book);
        void AddRange(IEnumerable<Book> books);
    }
}
