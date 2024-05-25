using Microsoft.AspNetCore.Mvc;

namespace ProjectVet.Areas.Admin.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
