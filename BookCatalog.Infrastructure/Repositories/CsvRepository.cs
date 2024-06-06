using BookCatalog.Core.Interfaces;
using BookCatalog.Infrastructure.Mappers;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BookCatalog.Infrastructure.Repositories
{
    public class CsvRepository : ICsvRepository
    {
        private const string _cvsFilePath = "../../../../BookCatalog.Infrastructure/CatalogData/books_info.csv";

        public async Task<Core.Models.Library<Core.Models.EBook>> LoadEBooks()
        {
            var eBookCatalog = new Models.Entities.Catalog<Models.Entities.EBook>();

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(_cvsFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Context.RegisterClassMap<BookRecordMap>();
                var records = csv.GetRecordsAsync<BookRecord>();

                await foreach (var record in records)
                {
                    var url = record.Identifier;

                    if (!string.IsNullOrEmpty(url) && string.IsNullOrEmpty(record.RelatedExternalId) && !string.IsNullOrEmpty(record.Title))
                    {
                        var formatsList = new List<string>();
                        var formatsString = record.Format;

                        if (!string.IsNullOrEmpty(formatsString))
                        {
                            formatsList.AddRange(formatsString.Split(','));
                        }

                        var eBook = new Models.Entities.EBook
                        {
                            Id = url,
                            Title = record.Title,
                            AvailableFormats = formatsList,
                            Authors = GetAuthorsFromCsv(record.Creator).ToHashSet()
                        };

                        eBookCatalog.Books.Add(eBook.Id, eBook);
                    }
                }
            }

            return new Core.Models.Library<Core.Models.EBook>(eBookCatalog.ToDomainModel());
        }

        public async Task<Core.Models.Library<Core.Models.PaperBook>> LoadPaperBooks()
        {
            var paperBookCatalog = new Models.Entities.Catalog<Models.Entities.PaperBook>();

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(_cvsFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Context.RegisterClassMap<BookRecordMap>();
                var records = csv.GetRecordsAsync<BookRecord>();

                await foreach (var record in records)
                {
                    var isbnsList = new List<string>();
                    var relatedExternalIdString = record.RelatedExternalId;

                    if (!string.IsNullOrEmpty(relatedExternalIdString))
                    {
                        var ids = relatedExternalIdString.Split(',');

                        foreach (var id in ids)
                        {
                            if (id.StartsWith("urn:isbn:"))
                            {
                                var isbn = id.Substring("urn:isbn:".Length);
                                isbnsList.Add(isbn);
                            }
                        }
                    }

                    if (isbnsList.Count > 0 && !string.IsNullOrEmpty(record.Title))
                    {
                        var publicationDate = DateTime.TryParse(record.PublicDate, out DateTime parsedDate)
                            ? DateOnly.FromDateTime(parsedDate)
                            : (DateOnly?)null;

                        var paperBook = new Models.Entities.PaperBook
                        {
                            Id = isbnsList[0],
                            Title = record.Title,
                            PublicationDate = publicationDate,
                            Isbns = isbnsList,
                            Publisher = record.Publisher,
                            Authors = GetAuthorsFromCsv(record.Creator).ToHashSet()
                        };

                        if (!paperBookCatalog.Books.Any(x => x.Key == paperBook.Id))
                        {
                            paperBookCatalog.Books.Add(paperBook.Id, paperBook);
                        }
                    }
                }
            }

            return new Core.Models.Library<Core.Models.PaperBook>(paperBookCatalog.ToDomainModel());
        }

        private static List<Models.Entities.Author> GetAuthorsFromCsv(string authorsString)
        {
            var authorsList = new List<Models.Entities.Author>();

            if (!string.IsNullOrEmpty(authorsString))
            {
                var authors = authorsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < authors.Length; i++)
                {
                    var fullName = authors[i].Trim();
                    DateOnly? birthDate = null;

                    if (i + 1 < authors.Length && authors[i + 1].Any(char.IsDigit))
                    {
                        var datePart = authors[i + 1].Trim();
                        var dateSegments = datePart.Split('-');

                        if (dateSegments.Length > 0 && int.TryParse(dateSegments[0], out int year))
                        {
                            birthDate = new DateOnly(year, 1, 1);
                        }

                        i++;
                    }

                    var nameParts = fullName.Split(' ');

                    if (nameParts.Length >= 1)
                    {
                        var firstName = nameParts[0];
                        var lastName = nameParts.Length >= 2 ? nameParts[nameParts.Length - 1] : "";

                        authorsList.Add(new Models.Entities.Author
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            BirthDate = birthDate
                        });
                    }
                }
            }

            return authorsList;
        }
    }
}
