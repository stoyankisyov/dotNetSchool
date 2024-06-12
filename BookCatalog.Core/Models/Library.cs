using BookCatalog.Core.AbstractFactory.LibrariesFactory;
using BookCatalog.Core.Interfaces;

namespace BookCatalog.Core.Models
{
    public class Library
    {
        public ICatalog Catalog { get; set; }

        public List<string> PressReleaseItems { get; set; }

        private Library(ICatalog catalog, List<string> pressReleaseItems)
        {
            Catalog = catalog;
            PressReleaseItems = pressReleaseItems;
        }

        public static async Task<Library> CreateAsync(BookFactory factory)
        {
            var catalog = await factory.CreateCatalogAsync();
            var pressReleaseItems = factory.CreatePressReleaseItems(catalog);

            return new Library(catalog, pressReleaseItems);
        }
    }
}
