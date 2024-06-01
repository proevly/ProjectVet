using ProjectVet.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjectVet.Areas.Kullanici.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly KlinikContext _context;
        public KullaniciController(KlinikContext context)
        {
            _context = context;
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
