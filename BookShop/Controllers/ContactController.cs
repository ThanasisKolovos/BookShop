using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class ContactController : Controller
    {
        //GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
