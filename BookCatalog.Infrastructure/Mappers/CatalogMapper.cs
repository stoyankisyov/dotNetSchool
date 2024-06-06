namespace BookCatalog.Infrastructure.Mappers
{
    public static class CatalogMapper
    {
        /// <summary>
        /// Converts Models.Entities.Catalog<Models.Entities.EBook> /Entity/ to Core.Models.Catalog<Core.Models.EBook> /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Catalog<Core.Models.EBook> </returns>
        public static Core.Models.Catalog<Core.Models.EBook> ToDomainModel(this Models.Entities.Catalog<Models.Entities.EBook> entity)
        {
            var domainModelEBookCatalog = new Core.Models.Catalog<Core.Models.EBook>();

            foreach (var book in entity.Books)
            {
                if (book.Value is Models.Entities.EBook eBookEntity)
                {
                    domainModelEBookCatalog.Add(eBookEntity.ToDomainModelEBook());
                }
            }

            return domainModelEBookCatalog;
        }

        /// <summary>
        /// Converts Models.Entities.Catalog<Models.Entities.PaperBook> /Entity/ to Core.Models.Catalog<Core.Models.PaperBook> /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Catalog<Core.Models.PaperBook> </returns>
        public static Core.Models.Catalog<Core.Models.PaperBook> ToDomainModel(this Models.Entities.Catalog<Models.Entities.PaperBook> entity)
        {
            var domainModelPaperBookCatalog = new Core.Models.Catalog<Core.Models.PaperBook>();

            foreach (var book in entity.Books)
            {
                if (book.Value is Models.Entities.PaperBook paperBookEntity)
                {
                    domainModelPaperBookCatalog.Add(paperBookEntity.ToDomainModelPaperBook());
                }
            }

            return domainModelPaperBookCatalog;
        }

        /// <summary>
        /// Converts Core.Models.Catalog<Core.Models.EBook> /Domain Model/ to Models.Entities.Catalog<Models.Entities.EBook> /Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.Entities.Catalog<Models.Entities.EBook> </returns>
        public static Models.Entities.Catalog<Models.Entities.EBook> ToEntity(this Core.Models.Catalog<Core.Models.EBook> domainModel)
        {
            var entityCatalog = new Models.Entities.Catalog<Models.Entities.EBook>();

            foreach (var book in domainModel.Books)
            {
                var coreEbook = book.Value;
                var entityEBook = new Models.Entities.EBook()
                {
                    Id = coreEbook.Id,
                    Title = coreEbook.Title,
                    AvailableFormats = coreEbook.AvailableFormats,
                    Authors = coreEbook.Authors.ToEntity()
                };

                entityCatalog.Books.Add(entityEBook.Id, entityEBook);
            }

            return entityCatalog;
        }

        /// <summary>
        /// Converts Core.Models.Catalog<Core.Models.PaperBook> /Domain Model/ to Models.Entities.Catalog<Models.Entities.PaperBook> /Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.Entities.Catalog<Models.Entities.PaperBook> </returns>
        public static Models.Entities.Catalog<Models.Entities.PaperBook> ToEntity(this Core.Models.Catalog<Core.Models.PaperBook> domainModel)
        {
            var entityCatalog = new Models.Entities.Catalog<Models.Entities.PaperBook>();

            foreach (var book in domainModel.Books)
            {
                var coreEbook = book.Value;
                var entityEBook = new Models.Entities.PaperBook()
                {
                    Id = coreEbook.Id,
                    Title = coreEbook.Title,
                    Authors = coreEbook.Authors.ToEntity(),
                    Isbns = coreEbook.Isbns.Select(x => x.Value).ToList(),
                    PublicationDate = coreEbook.PublicationDate,
                    Publisher = coreEbook.Publisher
                };

                entityCatalog.Books.Add(entityEBook.Id, entityEBook);
            }

            return entityCatalog;
        }

        /// <summary>
        /// Converts Core.Models.Catalog /Domain Model/ to Models.XmlEntities.Catalog /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Catalog </returns>
        public static Models.XmlEntities.Catalog<Models.XmlEntities.Book> ToXmlEntity(this Core.Models.Catalog<Core.Models.EBook> domainModel)
            => new Models.XmlEntities.Catalog<Models.XmlEntities.Book>()
            {
                Books = domainModel.Books.ToXmlEntity()
            };

        /// <summary>
        /// Converts Core.Models.Catalog<Core.Models.PaperBook> /Domain Model/ to Models.XmlEntities.Catalog<Models.XmlEntities.Book> /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Catalog<Models.XmlEntities.Book> </returns>
        public static Models.XmlEntities.Catalog<Models.XmlEntities.Book> ToXmlEntity(this Core.Models.Catalog<Core.Models.PaperBook> domainModel)
            => new Models.XmlEntities.Catalog<Models.XmlEntities.Book>()
            {
                Books = domainModel.Books.ToXmlEntity()
            };
    }
}
