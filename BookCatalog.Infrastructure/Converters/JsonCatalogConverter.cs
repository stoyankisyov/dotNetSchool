using System.Text.Json;
using System.Text.Json.Serialization;
using BookCatalog.Core.Models;

namespace BookCatalog.Infrastructure.Converters
{
    public class JsonCatalogConverter : JsonConverter<Catalog>
    {
        public override Catalog Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var catalog = new Catalog();
            var books = JsonSerializer.Deserialize<Dictionary<string, Book>>(ref reader, options);

            if (books is not null)
            {
                foreach (var book in books)
                {
                    catalog.Add(book.Value);
                }
            }

            return catalog;
        }

        public override void Write(Utf8JsonWriter writer, Catalog value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Books, options);
        }
    }
}