using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Crime";
        //    //return View(_bookRepository.AllBooks);

        //    BookListViewModel bookListViewModel = new BookListViewModel(_bookRepository.AllBooks, "All Books");
            
        //    return View(bookListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string? currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                books = _bookRepository.AllBooks.OrderBy(b => b.BookId);
                currentCategory = "All Books";
            }
            else
            {
                books = _bookRepository.AllBooks
                        .Where(b => b.Category.CategoryName == category)
                        .OrderBy(b => b.BookId);

                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new BookListViewModel(books, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var book =_bookRepository.GetBookById(id);

            if(book == null)
                return NotFound();

            return View(book);
        }
    }
}
