using BookCatalog.Infrastructure.Wrappers;

namespace BookCatalog.Infrastructure.Mappers
{
    public static class BookMapper
    {
        /// <summary>
        /// Converts Models.JsonEntities.Book /Json Entity/ to  Core.Models.Book /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Book </returns>
        public static Core.Models.Book ToDomainModel(this Models.JsonEntities.Book entity)
            => new Core.Models.Book(entity.Isbn, entity.Title, entity.PublicationDate, entity.Authors.ToDomainModel());

        /// <summary>
        /// Converts Models.XmlEntities.Book /Xml Entity/ to  Core.Models.Book /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Book </returns>
        public static Core.Models.Book ToDomainModel(this Models.XmlEntities.Book entity)
            => new Core.Models.Book(entity.Isbn, entity.Title, entity.PublicationDate?.Date, entity.Authors.ToDomainModel());

        /// <summary>
        /// Converts IEnumerable<Models.XmlEntities.Book> /Xml Entities/ to IEnumerable<Core.Models.Book> /Domain Models/
        /// </summary>
        /// <param name="entities"></param>
        /// <returns> IEnumerable<Core.Models.Book> </returns>
        public static IEnumerable<Core.Models.Book> ToDomainModel(this IEnumerable<Models.XmlEntities.Book> entities)
            => entities.Select(x => x.ToDomainModel());

        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.JsonEntities.Book /Json Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.JsonEntities.Book </returns>
        public static Models.JsonEntities.Book ToEntity(this Core.Models.Book domainModel)
            => new Models.JsonEntities.Book()
            {
                Isbn = domainModel.Isbn,
                Title = domainModel.Title,
                PublicationDate = domainModel.PublicationDate,
                Authors = domainModel.Authors.ToEntity()
            };

        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.XmlEntities.Book /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Book </returns>
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

        /// <summary>
        /// Converts Dictionary<string, Core.Models.Book> /Domain Models/ to Dictionary<string, Models.JsonEntities.Book> /Json Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> Dictionary<string, Models.JsonEntities.Book> </returns>
        public static Dictionary<string, Models.JsonEntities.Book> ToEntity(this Dictionary<string, Core.Models.Book> domainModels)
            => domainModels.ToDictionary(
                keyValuePair => keyValuePair.Key,
                keyValuePair => keyValuePair.Value.ToEntity());

        /// <summary>
        /// Converts Dictionary<string, Core.Models.Book> /Domain Models/ to List<Models.XmlEntities.Book> /Xml Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> List<Models.XmlEntities.Book> </returns>
        public static List<Models.XmlEntities.Book> ToXmlEntity(this Dictionary<string, Core.Models.Book> domainModels)
            => domainModels.Select(x => x.Value.ToXmlEntity()).ToList();
    }
}
