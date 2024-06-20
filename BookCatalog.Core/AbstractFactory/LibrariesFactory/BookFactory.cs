using BookCatalog.Core.Interfaces;

namespace BookCatalog.Core.AbstractFactory.LibrariesFactory
{
    public abstract class BookFactory
    {
        protected readonly ICsvRepository _repository;

        protected BookFactory(ICsvRepository repository)
        {
            _repository = repository;
        }

        public abstract Task<ICatalog> CreateCatalogAsync();
        public abstract List<string> CreatePressReleaseItems(ICatalog catalog);
    }
}
