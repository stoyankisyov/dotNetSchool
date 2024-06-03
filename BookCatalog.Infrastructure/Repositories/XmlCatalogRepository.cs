using System.Xml.Serialization;
using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Infrastructure.Repositories
{
    public class XmlCatalogRepository : IGenericRepository<Catalog>
    {
        private const string _filePath = "../../../../BookCatalog.Infrastructure/CatalogData/Xml/XmlCatalogData.xml";

        public async Task AddAsync(Catalog catalog)
        {
            var serializer = new XmlSerializer(typeof(Catalog));

            await using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            await using (var writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, catalog);
                await writer.FlushAsync();
            }
        }

        public async Task<Catalog> GetAsync()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"The file at {_filePath} does not exist.");
            }

            var serializer = new XmlSerializer(typeof(Catalog));

            await using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            {
                var catalog = (Catalog?)serializer.Deserialize(reader);

                if (catalog is null)
                {
                    throw new InvalidOperationException("Deserialization returned null.");
                }

                return catalog;
            }
        }
    }
}
