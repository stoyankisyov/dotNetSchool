namespace BookCatalog.Infrastructure.Mappers
{
    public static class CatalogMapper
    {
        /// <summary>
        /// Converts Core.Models.Catalog /Domain Model/ to Models.JsonEntities.Catalog /Json Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.JsonEntities.Catalog </returns>
        public static Models.JsonEntities.Catalog ToEntity(this Core.Models.Catalog<Core.Models.Book> domainModel)
            => new Models.JsonEntities.Catalog()
            {
                Books = domainModel.Books.ToEntity()
            };

        /// <summary>
        /// Converts Core.Models.Catalog /Domain Model/ to Models.XmlEntities.Catalog /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Catalog </returns>
        public static Models.XmlEntities.Catalog ToXmlEntity(this Core.Models.Catalog<Core.Models.Book> domainModel)
            => new Models.XmlEntities.Catalog()
            {
                Books = domainModel.Books.ToXmlEntity()
            };
    }
}
