using ProjectVet.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectVet.Areas.Admin.Dtos;

namespace ProjectVet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly KlinikContext _context;

        public AdminController(KlinikContext context)
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
        public IActionResult Depremzedeler()
        {
            var randevular = _context.Randevular
                .Select(r => new RandevuDto
                {
                    Id = r.Id,
                    KullaniciAd = r.Kullanici.Ad,
                    KullaniciSoyad = r.Kullanici.Soyad,
                    PetTur = r.Pet.Tur,
                    PetCins = r.Pet.Cins,
                    RandevuTarih = r.RandevuTarih,
                    RandevuSaat = r.RandevuSaat,
                    AsiMiMuayeneMi = r.AsiMiMuayeneMi,
                    OnaylandiMi = r.OnaylandiMi
                })
                .ToList();

            return View(randevular);
        }
        public IActionResult Hastahaneler()
        {
            return View();
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
