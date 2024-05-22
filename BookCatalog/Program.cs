namespace BookCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add
            var catalog = new Catalog();
            catalog.Add(new Book("123-4-56-789123-4", "TestBook1", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));
            catalog.Add(new Book("2234567894424", "TestBook3", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));
            catalog.Add(new Book("3234567852424", "TestBook2", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));

            // Get
            var firstBook = catalog["1234567891234"];

            // IEnumerable
            foreach (var book in catalog)
            {
                Console.WriteLine(book.Title);
            }

            // GetSortedBooks
            var sortedBooks = catalog.GetSortedBooks();

            // GetBooksByAuthor
            var booksByJohn = catalog.GetBooksByAuthor("John");
            var booksByMike = catalog.GetBooksByAuthor("Mike");

            // GetAllAuthorsBookCount
            var authorsBookCount = catalog.GetAllAuthorsBookCount();
        }
    }
}
