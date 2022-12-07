using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IBookRepository bookRepository, IShoppingCart shoppingCart)
        {
            _bookRepository = bookRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,_shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.AllBooks.FirstOrDefault(b => b.BookId == bookId);

            if(selectedBook != null)
            {
                _shoppingCart.AddToCart(selectedBook);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.AllBooks.FirstOrDefault(b => b.BookId == bookId);

            if (selectedBook != null)
            {
                _shoppingCart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");

        }
    }
}
