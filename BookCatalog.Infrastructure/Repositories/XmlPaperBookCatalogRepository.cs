using BookCatalog.Core.Interfaces;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Mappers;
using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Repositories
{
    public class XmlPaperBookCatalogRepository : IGenericRepository<Catalog<PaperBook>>
    {
        private const string _filePath = "../../../../BookCatalog.Infrastructure/CatalogData/Xml/XmlPaperBookCatalogData.xml";

        public async Task SaveAsync(Catalog<PaperBook> catalog)
        {
            var serializer = new XmlSerializer(typeof(Models.XmlEntities.Catalog<Models.XmlEntities.Book>));

            await using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            await using (var writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, catalog.ToXmlEntity());
                await writer.FlushAsync();
            }
        }
    }
}
