using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Converters;
using BookCatalog.Infrastructure.Mappers;
using System.Text.Json;

namespace BookCatalog.Infrastructure.Repositories
{
    public class JsonPaperBookCatalogRepository : IGenericRepository<Catalog<PaperBook>>
    {
        private const string _filesPath = "../../../../BookCatalog.Infrastructure/CatalogData/Json/";

        public async Task SaveAsync(Catalog<PaperBook> catalog)
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
                var authorCatalog = new Models.Entities.Catalog<Models.Entities.Book>();
                authorCatalog.Books = entity.Books.Where(kvp => kvp.Value.Authors.Any(x => x.FirstName == author.FirstName && x.LastName == author.LastName && x.BirthDate == author.BirthDate))
                                                 .ToDictionary(kvp => kvp.Key, kvp => new Models.Entities.Book()
                                                 {
                                                     Id = kvp.Value.Id,
                                                     Title = kvp.Value.Title,
                                                     Authors = kvp.Value.Authors
                                                 });

                var authorJsonPath = "";
                if (string.IsNullOrEmpty(author.LastName))
                {
                    authorJsonPath = Path.Combine(_filesPath, $"{author.FirstName}.json");
                }
                else
                {

                    authorJsonPath = Path.Combine(_filesPath, $"{author.FirstName}_{author.LastName}.json");
                }

                var serializedAuthorCatalog = JsonSerializer.Serialize(authorCatalog.Books, options);

                await File.WriteAllTextAsync(authorJsonPath, serializedAuthorCatalog);
            }
        }
    }
}
