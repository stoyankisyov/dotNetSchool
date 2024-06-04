using System.Text.Json;
using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Converters;
using BookCatalog.Infrastructure.Mappers;

namespace BookCatalog.Infrastructure.Repositories
{
    public class JsonCatalogRepository : IGenericRepository<Catalog>
    {
        private const string _filesPath = "../../../../BookCatalog.Infrastructure/CatalogData/Json/";

        public async Task AddAsync(Catalog catalog)
        {
            var entity = catalog.ToEntity();

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

            foreach (var author in entity.Books.SelectMany(kvp => kvp.Value.Authors).Distinct())
            {
                var authorCatalog = new Models.JsonEntities.Catalog();
                authorCatalog.Books = entity.Books.Where(kvp => kvp.Value.Authors.Any(x => x.FirstName == author.FirstName && x.LastName == author.LastName && x.BirthDate == author.BirthDate)).ToDictionary();

                var authorJsonPath = Path.Combine(_filesPath, $"{author.FirstName}_{author.LastName}.json");
                var serializedAuthorCatalog = JsonSerializer.Serialize(authorCatalog.Books, options);

                await File.WriteAllTextAsync(authorJsonPath, serializedAuthorCatalog);
            }
        }

        public async Task<Catalog> GetAsync()
        {
            var entityCatalog = new Models.JsonEntities.Catalog();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonDateOnlyConverter() }
            };

            var jsonFiles = Directory.GetFiles(_filesPath, "*.json");

            foreach (var jsonFile in jsonFiles)
            {
                var fileContent = await File.ReadAllTextAsync(jsonFile);
                var books = JsonSerializer.Deserialize<Dictionary<string, Models.JsonEntities.Book>>(fileContent, options);

                if (books != null)
                {
                    foreach (var book in books)
                    {
                        if (!entityCatalog.Books.ContainsKey(book.Key))
                        {
                            entityCatalog.Books.Add(book.Key, book.Value);
                        }
                    }
                }
            }

            return entityCatalog.ToDomainModel();
        }
    }
}
