namespace BookShop.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> BooksOfTheWeek { get; }
        Book? GetBookById(int bookId);
    }
}
