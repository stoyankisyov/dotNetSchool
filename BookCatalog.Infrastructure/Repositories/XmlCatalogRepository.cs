using System.Xml.Serialization;
using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;

namespace BookCatalog.Infrastructure.Repositories
{
    public class XmlCatalogRepository : IGenericRepository<Catalog>
    {
        private const string _filePath = "../../../../BookCatalog.Infrastructure/CatalogData/Xml/XmlCatalogData.xml";

        public void Add(Catalog catalog)
        {
            var serializer = new XmlSerializer(typeof(Catalog));

            using (var writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, catalog);
            }
        }

        public Catalog Get()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"The file at {_filePath} does not exist.");
            }

            var serializer = new XmlSerializer(typeof(Catalog));

            using (var reader = new StreamReader(_filePath))
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
