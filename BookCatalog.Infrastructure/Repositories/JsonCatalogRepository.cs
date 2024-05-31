using System.Text.Json;
using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Converters;

namespace BookCatalog.Infrastructure.Repositories
{
    public class JsonCatalogRepository : IGenericRepository<Catalog>
    {
        private const string _filesPath = "../../../../BookCatalog.Infrastructure/CatalogData/Json/";

        public async Task AddAsync(Catalog catalog)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                Converters = { new JsonDateOnlyConverter() }
            };

            if (!Directory.Exists(_filesPath))
            {
                Directory.CreateDirectory(_filesPath);
            }

            foreach (var author in catalog.BookList.SelectMany(book => book.Authors).Distinct())
            {
                var authorBooks = catalog.BookList.Where(book => book.Authors.Contains(author)).ToList();
                var authorCatalog = new Catalog();
                authorCatalog.AddRange(authorBooks);

                var authorJsonPath = Path.Combine(_filesPath, $"{author.FirstName}_{author.LastName}.json");
                var serializedAuthorCatalog = JsonSerializer.Serialize(authorCatalog.BookList, options);
                
                await File.WriteAllTextAsync(authorJsonPath, serializedAuthorCatalog);
            }
        }

        public async Task<Catalog> GetAsync()
        {
            var restoredCatalog = new Catalog();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonDateOnlyConverter() }
            };

            var jsonFiles = Directory.GetFiles(_filesPath, "*.json");

            foreach (var jsonFile in jsonFiles)
            {
                var fileContent = await File.ReadAllTextAsync(jsonFile);
                var books = JsonSerializer.Deserialize<List<Book>>(fileContent, options);
                if (books != null)
                {
                    restoredCatalog.AddRange(books);
                }
            }

            return restoredCatalog;
        }
    }
}
