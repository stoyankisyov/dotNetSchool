using BookCatalog.Core.AbstractFactory;
using BookCatalog.Core.AbstractFactory.LibrariesFactory;
using BookCatalog.Core.AbstractFactory.RepositoriesFactory;
using BookCatalog.Infrastructure.Repositories;

namespace BookCatalog
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            LibraryAbstractFactory factory = new LibraryFactory(new CsvRepository());
            var eBookLibrary = await factory.LoadEBookLibrary();
            var paperBookLibrary = await factory.LoadPaperBookLibrary();

            RepositoryAbstractFactory jsonRepositoryFactory = new JsonRepositoryFactory(new JsonEBookCatalogRepository(), new JsonPaperBookCatalogRepository());
            RepositoryAbstractFactory xmlRepositoryFactory = new XmlRepositoryFactory(new XmlEBookCatalogRepository(), new XmlPaperBookCatalogRepository());

            await jsonRepositoryFactory.SaveEBooks(eBookLibrary);
            await jsonRepositoryFactory.SavePaperBooks(paperBookLibrary);

            await xmlRepositoryFactory.SaveEBooks(eBookLibrary);
            await xmlRepositoryFactory.SavePaperBooks(paperBookLibrary);
        }
    }
}
