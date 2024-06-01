using Microsoft.AspNetCore.Mvc;
using ProjectVet.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Kullanicilar()
        {
            var kullaniciList =_context.Kullanicilar.ToList();
            ViewBag.Kullanicilar=kullaniciList;
            return View(kullaniciList);
            
        }


        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Kullanıcı adı ve şifre kontrolü
            if (username == "admin" && password == "admin")
            {
                // Başarılı giriş durumu
                // Burada giriş başarılı olduğunda yapılacak işlemleri ekleyebilirsiniz.
                return RedirectToAction("Index", "Admin"); // Örnek bir yönlendirme
            }
            else
            {
                // Hatalı giriş durumu
                ViewBag.Error = "Hatalı kullanıcı adı veya şifre";
                return View();
            }
        }
    }
}
