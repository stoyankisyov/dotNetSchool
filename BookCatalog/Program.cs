using BookCatalog.Core.AbstractFactory.LibrariesFactory;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Repositories;
using BookCatalog.Infrastructure.Services;
using BookCatalog.Service.Services;

namespace BookCatalog
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var csvRepository = new CsvRepository();
            var eBookFactory = new EBookFactory(csvRepository);
            var paperBookFactory = new PaperBookFactory(csvRepository);
            var libraryPageNumberService = new LibraryPageNumberService(new PageRetrievalService());
            var xmlEBookRepository = new XmlEBookCatalogRepository();
            var xmlPaperBookRepository = new XmlPaperBookCatalogRepository();
            var jsonEBookRepository = new JsonEBookCatalogRepository();
            var jsonPaperBookRepository = new JsonPaperBookCatalogRepository();

            // Libraries initializaiton
            var eBookLibrary = await Library.CreateAsync(eBookFactory);
            var paperBookLibrary = await Library.CreateAsync(paperBookFactory);

            // Enriches the eBookLibrary objects with their page count
            await libraryPageNumberService.AddPageNumbersAsync(eBookLibrary);

            // Converts from ICatalog to typed catalog
            var paperBookcatalog = paperBookLibrary.Catalog.ToTypedCatalog<PaperBook>();
            var eBookCatalog = eBookLibrary.Catalog.ToTypedCatalog<EBook>();

            // Saves the libraries to files
            await xmlEBookRepository.SaveAsync(eBookCatalog);
            await xmlPaperBookRepository.SaveAsync(paperBookcatalog);
            await jsonEBookRepository.SaveAsync(eBookCatalog);
            await jsonPaperBookRepository.SaveAsync(paperBookcatalog);
        }
    }
}
