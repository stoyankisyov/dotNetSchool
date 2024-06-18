using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Core.AbstractFactory.LibrariesFactory
{
    public class EBookFactory : BookFactory
    {
        public EBookFactory(ICsvRepository repository)
            : base(repository) { }

        public override async Task<ICatalog> CreateCatalogAsync()
        {
            var catalog = await _repository.LoadEBooks();

            return catalog;
        }

        public override List<string> CreatePressReleaseItems(ICatalog catalog)
            => catalog.Books.Values.Cast<EBook>().SelectMany(x => x.AvailableFormats).Distinct().ToList();
    }
}
