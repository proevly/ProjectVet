

using ProjectVet.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.Services;

namespace ProjectVet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly KlinikContext _context;
        private readonly IKullaniciService _kullaniciService;
        public AdminController(KlinikContext context, IKullaniciService kullaniciService)
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
        public IActionResult Kullanicilar()
        {
            var kullaniciList = _context.Kullanicilar.ToList();
            ViewBag.Kullanicilar = kullaniciList;
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
                // Veritabanı üzerinden kullanıcı doğrulaması
                var kullanici = _kullaniciService.Authenticate(username, password);
                if (kullanici != null)
                {
                    // Giriş başarılı, Kullanici alanına yönlendirme
                    HttpContext.Session.SetString("UserId", kullanici.KullaniciId.ToString()); // userId kullanıcıdan alınmalı
                    return RedirectToAction("Index", "Kullanici", new {area="Kullanici"});
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
}

