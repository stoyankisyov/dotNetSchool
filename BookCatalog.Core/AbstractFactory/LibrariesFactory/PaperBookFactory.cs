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
            => catalog.Books.Values.Cast<PaperBook>().Select(x => x.Publisher).Distinct().ToList();
    }
}
