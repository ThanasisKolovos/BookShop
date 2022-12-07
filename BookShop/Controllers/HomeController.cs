using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var booksOfTheWeek = _bookRepository.BooksOfTheWeek;
            var homeViewModel = new HomeViewModel(booksOfTheWeek);
            return View(homeViewModel);
        }
    }
}
