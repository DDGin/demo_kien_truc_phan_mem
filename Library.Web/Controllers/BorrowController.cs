using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BorrowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
