using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Core.AbstractFactory.RepositoriesFactory
{
    public abstract class RepositoryAbstractFactory
    {
        protected readonly IGenericRepository<Catalog<EBook>> _eBookRepository;
        protected readonly IGenericRepository<Catalog<PaperBook>> _paperBookRepository;

        protected RepositoryAbstractFactory(IGenericRepository<Catalog<EBook>> eBookRepository, IGenericRepository<Catalog<PaperBook>> paperBookRepository)
        {
            _eBookRepository = eBookRepository;
            _paperBookRepository = paperBookRepository;
        }

        public abstract Task SaveEBooks(Library<EBook> eBookLibrary);
        public abstract Task SavePaperBooks(Library<PaperBook> paperBookLibrary);
    }
}
