using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Converters;
using System.Text.Json;

namespace BookCatalog.Infrastructure.Repositories
{
    public class JsonCatalogRepository : IGenericRepository<Catalog>
    {
        private const string _filePath = "../../../../BookCatalog.Infrastructure/CatalogData/Json/JsonCatalogData.json";

        public void Add(Catalog catalog)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                Converters = { new JsonDateOnlyConverter() }
            };
            var serializedCatalog = JsonSerializer.Serialize(catalog.Books.Values, options);
            File.WriteAllText(_filePath, serializedCatalog);
        }

        public Catalog Get()
        {
            string fileContent = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonDateOnlyConverter() }
            };
            var books = JsonSerializer.Deserialize<List<Book>>(fileContent, options);
            var catalog = new Catalog();
            if (books != null)
            {
                catalog.AddRange(books);
            }
            return catalog;
        }
    }
}
