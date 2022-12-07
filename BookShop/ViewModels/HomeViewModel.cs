using BookShop.Models;

namespace BookShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BooksOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Book> booksOfTheWeek)
        {
            BooksOfTheWeek = booksOfTheWeek;
        }
    }
}
