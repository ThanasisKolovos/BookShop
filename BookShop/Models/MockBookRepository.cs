using System.IO.Pipelines;
using System.Net;

namespace BookShop.Models
{
    public class MockBookRepository : IBookRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Book> AllBooks =>
            new List<Book>
            {
                new Book {BookId = 1, Name="Book1", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="Images/bethanys-pie-shop-logo_horiz-white.png", InStock=true, IsBookOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg"},
                new Book {BookId = 2, Name="Book2", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypie.jpg", InStock=true, IsBookOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg"},
                new Book {BookId = 3, Name="Book3", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypie.jpg", InStock=true, IsBookOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg"},
                new Book {BookId = 4, Name="Book4", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypie.jpg", InStock=true, IsBookOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg"},
            };

        public IEnumerable<Book> BooksOfTheWeek
        {
            get
            {
                return AllBooks.Where(p => p.IsBookOfTheWeek);
            }
        }

        public Book? GetBookById(int bookId) => AllBooks.FirstOrDefault(p => p.BookId == bookId);

        public IEnumerable<Book> SearchBooks(string searchQuery)
        {
            throw new NotImplementedException();
        }

        
    }
}
