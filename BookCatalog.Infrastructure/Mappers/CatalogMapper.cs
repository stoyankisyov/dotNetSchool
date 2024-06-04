namespace BookCatalog.Infrastructure.Mappers
{
    public static class CatalogMapper
    {
        /// <summary>
        /// Converts Models.JsonEntities.Catalog /Json Entity/ to Core.Models.Catalog /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Catalog </returns>
        public static Core.Models.Catalog ToDomainModel(this Models.JsonEntities.Catalog entity)
        {
            var domainModelCatalog = new Core.Models.Catalog();
            domainModelCatalog.AddRange(entity.Books.Select(x => x.Value.ToDomainModel()));

            return domainModelCatalog;
        }

        /// <summary>
        /// Converts Models.XmlEntities.Catalog /Xml Entity/ to Core.Models.Catalog /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Catalog </returns>
        public static Core.Models.Catalog ToDomainModel(this Models.XmlEntities.Catalog entity)
        {
            var domainModelCatalog = new Core.Models.Catalog();
            domainModelCatalog.AddRange(entity.Books.ToDomainModel());

            return domainModelCatalog;
        }

        /// <summary>
        /// Converts Core.Models.Catalog /Domain Model/ to Models.JsonEntities.Catalog /Json Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.JsonEntities.Catalog </returns>
        public static Models.JsonEntities.Catalog ToEntity(this Core.Models.Catalog domainModel)
            => new Models.JsonEntities.Catalog()
            {
                Books = domainModel.Books.ToEntity()
            };

        /// <summary>
        /// Converts Core.Models.Catalog /Domain Model/ to Models.XmlEntities.Catalog /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Catalog </returns>
        public static Models.XmlEntities.Catalog ToXmlEntity(this Core.Models.Catalog domainModel)
            => new Models.XmlEntities.Catalog()
            {
                Books = domainModel.Books.ToXmlEntity()
            };
    }
}
