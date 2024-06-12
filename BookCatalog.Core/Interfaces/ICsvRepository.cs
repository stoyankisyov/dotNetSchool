using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces
{
    public interface ICsvRepository
    {
        Task<Catalog<EBook>> LoadEBooks();
        Task<Catalog<PaperBook>> LoadPaperBooks();
    }
}
