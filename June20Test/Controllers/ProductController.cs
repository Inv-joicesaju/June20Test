using Microsoft.AspNetCore.Mvc;

namespace June20Test.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
