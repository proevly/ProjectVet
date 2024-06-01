using Microsoft.AspNetCore.Mvc;

namespace ProjectVet.Areas.Kullanici.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
