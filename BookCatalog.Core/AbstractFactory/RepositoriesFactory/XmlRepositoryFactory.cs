using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Core.AbstractFactory.RepositoriesFactory
{
    public class XmlRepositoryFactory : RepositoryAbstractFactory
    {

        public XmlRepositoryFactory(IGenericRepository<Catalog<EBook>> eBookRepository, IGenericRepository<Catalog<PaperBook>> paperBookRepository) 
            : base(eBookRepository, paperBookRepository)
        {

        }

        public override async Task SaveEBooks(Library<EBook> eBookLibrary)
        {
            await _eBookRepository.SaveAsync(eBookLibrary.Catalog);
        }

        public override async Task SavePaperBooks(Library<PaperBook> paperBookLibrary)
        {
            await _paperBookRepository.SaveAsync(paperBookLibrary.Catalog);
        }
    }
}
