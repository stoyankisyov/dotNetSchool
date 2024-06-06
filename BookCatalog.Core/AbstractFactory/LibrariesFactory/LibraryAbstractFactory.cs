using BookCatalog.Core.Models;

namespace BookCatalog.Core.AbstractFactory.LibrariesFactory
{
    public abstract class LibraryAbstractFactory
    {
        public abstract Task<Library<EBook>> LoadEBookLibrary();
        public abstract Task<Library<PaperBook>> LoadPaperBookLibrary();
    }
}
