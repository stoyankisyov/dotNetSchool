using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Service.Interfaces;

namespace BookCatalog.Service.Services
{
    public class LibraryPageNumberService : ILibraryPageNumberService
    {
        private readonly IPageRetrievalService _pageRetrievalService;

        public LibraryPageNumberService(IPageRetrievalService pageRetrievalService)
        {
            _pageRetrievalService = pageRetrievalService;
        }

        public async Task AddPageNumbersAsync(Library library)
        {
            foreach (var book in library.Catalog.Books.Values)
            {
                if (book is EBook eBook)
                {
                    eBook.Pages = await _pageRetrievalService.GetPageCountAsync(eBook.Id);
                }
                else
                {
                    throw new Exception("Library does not contain EBooks.");
                }
            }
        }
    }
}
