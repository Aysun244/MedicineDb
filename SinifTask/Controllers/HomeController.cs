using Microsoft.AspNetCore.Mvc;

namespace SinifTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
