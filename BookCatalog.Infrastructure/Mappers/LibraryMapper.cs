namespace BookCatalog.Infrastructure.Mappers
{
    public static class LibraryMapper
    {
        public static Core.Models.Library<Core.Models.Book> ToDomainModel(this Models.Library entity)
            => new Core.Models.Library<Core.Models.Book>(entity.Catalog)    // -> REQIORES MAPPER
    }
}
