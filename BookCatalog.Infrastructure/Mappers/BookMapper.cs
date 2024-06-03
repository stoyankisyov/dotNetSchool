using BookCatalog.Core.Wrappers;

namespace BookCatalog.Infrastructure.Mappers
{
    public static class BookMapper
    {
        public static Core.Models.Book ToDomainModel(this Models.JsonEntities.Book entity)
            => new Core.Models.Book(entity.Isbn, entity.Title, entity.PublicationDate, entity.Authors.ToDomainModel());

        public static Core.Models.Book ToDomainModel(this Models.XmlEntities.Book entity)
            => new Core.Models.Book(entity.Isbn, entity.Title, entity.PublicationDate?.Date, entity.Authors.ToDomainModel());

        public static Dictionary<string, Core.Models.Book> ToDomainModel(this Dictionary<string, Models.JsonEntities.Book> entities)
             => entities.ToDictionary(
                 keyValuePair => keyValuePair.Key,
                 keyValuePair => keyValuePair.Value.ToDomainModel());

        public static IEnumerable<Core.Models.Book> ToDomainModel(this IEnumerable<Models.XmlEntities.Book> entities)
            => entities.Select(x => x.ToDomainModel());

        public static Models.JsonEntities.Book ToEntity(this Core.Models.Book domainModel)
            => new Models.JsonEntities.Book()
            {
                Isbn = domainModel.Isbn,
                Title = domainModel.Title,
                PublicationDate = domainModel.PublicationDate,
                Authors = domainModel.Authors.ToEntity()
            };

        public static Models.XmlEntities.Book ToXmlEntity(this Core.Models.Book domainModel)
        {
            return new Models.XmlEntities.Book()
            {
                Isbn = domainModel.Isbn,
                Title = domainModel.Title,
                PublicationDate = new DateOnlyXmlWrapper(domainModel.PublicationDate),
                Authors = domainModel.Authors.ToXmlEntity()
            };
        }

        public static Dictionary<string, Models.JsonEntities.Book> ToEntity(this Dictionary<string, Core.Models.Book> domainModels)
            => domainModels.ToDictionary(
                keyValuePair => keyValuePair.Key,
                keyValuePair => keyValuePair.Value.ToEntity());

        public static List<Models.XmlEntities.Book> ToXmlEntity(this Dictionary<string, Core.Models.Book> domainModels)
            => domainModels.Select(x => x.Value.ToXmlEntity()).ToList();
    }
}
