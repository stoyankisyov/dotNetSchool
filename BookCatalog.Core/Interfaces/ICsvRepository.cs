using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces
{
    public interface ICsvRepository
    {
        Task<Library<EBook>> LoadEBooks();
        Task<Library<PaperBook>> LoadPaperBooks();

    }
}
