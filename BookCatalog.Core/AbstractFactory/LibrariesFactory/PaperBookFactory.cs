using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Core.AbstractFactory.LibrariesFactory
{
    public class PaperBookFactory : BookFactory
    {
        public PaperBookFactory(ICsvRepository repository)
            : base(repository) { }

        public override async Task<ICatalog> CreateCatalogAsync()
        {
            var result = await _repository.LoadPaperBooks();

            return result;
        }

        public override List<string> CreatePressReleaseItems(ICatalog catalog)
        {
            var pressReleaseItems = new List<string>();
            var paperBooks = catalog.Books.Values.Cast<PaperBook>().ToList();

            foreach (var book in paperBooks)
            {
                if (!pressReleaseItems.Contains(book.Publisher))
                {
                    pressReleaseItems.Add(book.Publisher);
                }
            }

            return pressReleaseItems;
        }
    }
}
