using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly BookShopDbContext _bookShopDbContext;

        public BookRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }

        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _bookShopDbContext.Books.Include(c => c.Category);
            }
        }
        public IEnumerable<Book> BooksOfTheWeek
        {
            get
            {
                return _bookShopDbContext.Books.Include(c => c.Category).Where(p => p.IsBookOfTheWeek);
            }
        }

       

        public Book? GetBookById(int bookId)
        {
            return _bookShopDbContext.Books.FirstOrDefault(p => p.BookId == bookId);
        }
    }
}
