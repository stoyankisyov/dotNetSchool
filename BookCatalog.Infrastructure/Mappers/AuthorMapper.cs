﻿using BookCatalog.Infrastructure.Wrappers;

namespace BookCatalog.Infrastructure.Mappers
{
    public static class AuthorMapper
    {
        /// <summary>
        /// Converts Models.Entities.Author /Entity/ to Core.Models.Author /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Author </returns>
        public static Core.Models.Author ToDomainModel(this Models.Entities.Author entity)
            => new Core.Models.Author(entity.FirstName, entity.LastName, entity.BirthDate);

        /// <summary>
        /// Converts Models.XmlEntities.Author /Xml Entity/ to Core.Models.Author /Domain Model/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Core.Models.Author </returns>
        public static Core.Models.Author ToDomainModel(this Models.XmlEntities.Author entity)
            => new Core.Models.Author(entity.FirstName, entity.LastName, entity.BirthDate.Date);

        /// <summary>
        /// Converts HashSet<Models.Entities.Author> /Entities/ to HashSet<Core.Models.Author> /Domain Models/
        /// </summary>
        /// <param name="entities"></param>
        /// <returns> HashSet<Core.Models.Author> </returns>
        public static HashSet<Core.Models.Author> ToDomainModel(this HashSet<Models.Entities.Author> entities)
            => new HashSet<Core.Models.Author>(entities.Select(x => x.ToDomainModel()));

        /// <summary>
        /// Converts Core.Models.Author /Domain Model/ to Models.Entities.Author /Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.Entities.Author </returns>
        public static Models.Entities.Author ToEntity(this Core.Models.Author domainModel)
            => new Models.Entities.Author()
            {
                FirstName = domainModel.FirstName,
                LastName = domainModel.LastName,
                BirthDate = domainModel.BirthDate
            };

        /// <summary>
        /// Converts Core.Models.Author /Domain Model/ to Models.XmlEntities.Author /Xml Entity/
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns> Models.XmlEntities.Author </returns>
        public static Models.XmlEntities.Author ToXmlEntity(this Core.Models.Author domainModel)
            => new Models.XmlEntities.Author()
            {
                FirstName = domainModel.FirstName,
                LastName = domainModel.LastName,
                BirthDate = new DateOnlyXmlWrapper(domainModel.BirthDate)
            };

        /// <summary>
        /// Converts HashSet<Core.Models.Author> /Domain Models/ to HashSet<Models.Entities.Author> /Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> HashSet<Models.Entities.Author> </returns>
        public static HashSet<Models.Entities.Author> ToEntity(this HashSet<Core.Models.Author> domainModels)
            => new HashSet<Models.Entities.Author>(domainModels.Select(x => x.ToEntity()));

        /// <summary>
        /// Converts HashSet<Core.Models.Author> /Domain Models/ to HashSet<Models.XmlEntities.Author> /Xml Entities/
        /// </summary>
        /// <param name="domainModels"></param>
        /// <returns> HashSet<Models.XmlEntities.Author> </returns>
        public static HashSet<Models.XmlEntities.Author> ToXmlEntity(this HashSet<Core.Models.Author> domainModels)
            => new HashSet<Models.XmlEntities.Author>(domainModels.Select(x => x.ToXmlEntity()));
    }
}
