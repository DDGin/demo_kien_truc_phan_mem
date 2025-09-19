using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class FineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
