using BookCatalog.Core.Wrappers;

namespace BookCatalog.Infrastructure.Mappers
{
    public static class CatalogMapper
    {
        public static Core.Models.Catalog ToDomainModel(this Models.JsonEntities.Catalog entity)
        {
            var domainModelCatalog = new Core.Models.Catalog();
            domainModelCatalog.AddRange(entity.Books.Select(x => x.Value.ToDomainModel()));

            return domainModelCatalog;
        }

        public static Core.Models.Catalog ToDomainModel(this Models.XmlEntities.Catalog entity)
        {
            var domainModelCatalog = new Core.Models.Catalog();
            domainModelCatalog.AddRange(entity.Books.ToDomainModel());

            return domainModelCatalog;
        }

        public static Models.JsonEntities.Catalog ToEntity(this Core.Models.Catalog domainModel)
            => new Models.JsonEntities.Catalog()
            {
                Books = domainModel.Books.ToEntity()
            };

        public static Models.XmlEntities.Catalog ToXmlEntity(this Core.Models.Catalog domainModel)
            => new Models.XmlEntities.Catalog()
            {
                Books = domainModel.Books.ToXmlEntity()
            };
    }
}
