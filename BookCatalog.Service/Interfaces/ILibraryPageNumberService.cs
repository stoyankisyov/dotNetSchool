namespace BookCatalog.Service.Interfaces
{
    public interface ILibraryPageNumberService
    {
        Task AddPageNumbersAsync(Core.Models.Library library);
    }
}
