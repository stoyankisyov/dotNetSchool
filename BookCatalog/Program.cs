using BookCatalog.Core.AbstractFactory.LibrariesFactory;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Repositories;

namespace BookCatalog
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var csvRepository = new CsvRepository();

            BookFactory eBookFactory = new EBookFactory(csvRepository);
            var eBookLibrary = await Library.CreateAsync(eBookFactory);

            BookFactory paperBookFactory = new PaperBookFactory(csvRepository);
            var paperBookLibrary = await Library.CreateAsync(paperBookFactory);

            // Converts from ICatalog to typed catalog
            var paperBookcatalog = paperBookLibrary.Catalog.ToTypedCatalog<PaperBook>();
            var eBookCatalog = eBookLibrary.Catalog.ToTypedCatalog<EBook>();

            var xmlEBookRepository = new XmlEBookCatalogRepository();
            await xmlEBookRepository.SaveAsync(eBookCatalog);

            var xmlPaperBookRepository = new XmlPaperBookCatalogRepository();
            await xmlPaperBookRepository.SaveAsync(paperBookcatalog);

            var jsonEBookRepository = new JsonEBookCatalogRepository();
            await jsonEBookRepository.SaveAsync(eBookCatalog);

            var jsonPaperBookRepository = new JsonPaperBookCatalogRepository();
            await jsonPaperBookRepository.SaveAsync(paperBookcatalog);
        }
    }
}
