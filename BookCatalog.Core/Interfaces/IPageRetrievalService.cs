namespace BookCatalog.Core.Interfaces
{
    public interface IPageRetrievalService
    {
        Task<int> GetPageCountAsync(string identifier);
    }
}
