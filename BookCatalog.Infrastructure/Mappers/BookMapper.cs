namespace BookCatalog.Infrastructure.Mappers
{
    public static class BookMapper
    {
        /// <summary>
        /// Converts Models.Entities.EBook /Entity/ to Core.Models.EBook /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.EBook </returns>
        public static Core.Models.EBook ToDomainModelEBook(this Models.Entities.EBook entity)
            => new Core.Models.EBook(entity.Title, entity.Id, entity.Authors.ToDomainModel(), new List<string>(entity.AvailableFormats));

        /// <summary>
        /// Convert Models.Entities.PaperBook /Entity/ to Core.Models.PaperBook /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.PaperBook </returns>
        public static Core.Models.PaperBook ToDomainModelPaperBook(this Models.Entities.PaperBook entity)
        {
            var isbns = new List<Core.Models.Isbn>();

            foreach(var isbn in entity.Isbns)
            {
                isbns.Add(new Core.Models.Isbn(isbn));
            }

            return new Core.Models.PaperBook(isbns, entity.Title, entity.PublicationDate, entity.Publisher, entity.Authors.ToDomainModel());
        }

        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.Entities.Book /Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.Entities.Book </returns>
        public static Models.Entities.Book ToEntity(this Core.Models.Book domainModel)
            => new Models.Entities.Book()
            {
                Title = domainModel.Title,
                Authors = domainModel.Authors.ToEntity()
            };

        /// <summary>
        /// Converts Core.Models.Book /Domain Model/ to Models.XmlEntities.Book /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Book </returns>
        public static Models.XmlEntities.Book ToXmlEntity(this Core.Models.EBook domainModel)
            => new Models.XmlEntities.Book()
            {
                Title = domainModel.Title,
                Authors = domainModel.Authors.ToXmlEntity()
            };

        /// <summary>
        /// Converts Core.Models.PaperBook /Domain Model/ to Models.XmlEntities.Book /Entity/ 
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns>  Models.XmlEntities.Book </returns>
        public static Models.XmlEntities.Book ToXmlEntity(this Core.Models.PaperBook domainModel)
            => new Models.XmlEntities.Book()
            {
                Title = domainModel.Title,
                Authors = domainModel.Authors.ToXmlEntity()
            };

        /// <summary>
        /// Converts Dictionary<string, Core.Models.Book> /Domain Models/ to Dictionary<string, Models.Entities.Book> /Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> Dictionary<string, Models.Entities.Book> </returns>
        public static Dictionary<string, Models.Entities.Book> ToEntity(this Dictionary<string, Core.Models.PaperBook> domainModels)
            => domainModels.ToDictionary(
                keyValuePair => keyValuePair.Key,
                keyValuePair => keyValuePair.Value.ToEntity());

        /// <summary>
        /// Converts Dictionary<string, Core.Models.Book> /Domain Models/ to List<Models.XmlEntities.Book> /Xml Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> List<Models.XmlEntities.Book> </returns>
        public static List<Models.XmlEntities.Book> ToXmlEntity(this Dictionary<string, Core.Models.EBook> domainModels)
            => domainModels.Select(x => x.Value.ToXmlEntity()).ToList();

        /// <summary>
        /// Converts Dictionary<string, Core.Models.PaperBook> /Domain Models/ to List<Models.XmlEntities.Book> /Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns></returns>
        public static List<Models.XmlEntities.Book> ToXmlEntity(this Dictionary<string, Core.Models.PaperBook> domainModels)
          => domainModels.Select(x => x.Value.ToXmlEntity()).ToList();
    }
}
