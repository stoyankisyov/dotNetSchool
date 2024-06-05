using BookCatalog.Infrastructure.Wrappers;

namespace BookCatalog.Infrastructure.Mappers
{
    public static class BookMapper
    {
        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.JsonEntities.Book /Json Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.JsonEntities.Book </returns>
        public static Models.JsonEntities.Book ToEntity(this Core.Models.Book domainModel)
            => new Models.JsonEntities.Book()
            {
                Title = domainModel.Title,
                Authors = domainModel.Authors.ToEntity()
            };

        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.XmlEntities.Book /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Book </returns>
        public static Models.XmlEntities.Book ToXmlEntity(this Core.Models.Book domainModel) 
            => new Models.XmlEntities.Book()
            {
                Title = domainModel.Title,
                Authors = domainModel.Authors.ToXmlEntity()
            };

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
