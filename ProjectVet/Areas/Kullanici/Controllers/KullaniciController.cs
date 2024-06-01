using Microsoft.AspNetCore.Mvc;
using ProjectVet.EfCore;
using ProjectVet.Services;

namespace ProjectVet.Areas.Kullanici.Controllers
{
    [Area("Kullanici")]
    public class KullaniciController : Controller
    {
        private readonly KlinikContext _context;
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(KlinikContext context, IKullaniciService kullaniciService)
        {
            _context = context;
            _kullaniciService = kullaniciService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
