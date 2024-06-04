

using ProjectVet.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.Interfaces;
using ProjectVet.Domain.Entities.Models;
using ProjectVet.Application.Interfaces;

namespace ProjectVet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly KlinikContext _context;
        private readonly IKullaniciService _kullaniciService;
        private readonly IRandevuKisitService _randevuKisitService;
        public AdminController(KlinikContext context, IKullaniciService kullaniciService, IRandevuKisitService randevuKisitService)
        {
            _context = context;
            _kullaniciService = kullaniciService;
            _randevuKisitService = randevuKisitService;
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


        public ActionResult RandevuKisitla()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RandevuKisitla(RandevuKisitDto model)
        {
            DateTime tarih = model.Tarih;
            bool ogledenOnceMi = model.OgledenOnceMi;

            // Verileri kullanarak işlemler yapın
            // Örneğin, _randevuKisitService.RandevuKisitEkle(model) gibi bir işlem yapabilirsiniz.

            if (ModelState.IsValid)
            {
                var kisitVarMi = _context.RandevuKisitlar
                    .FirstOrDefault(r => r.Tarih == model.Tarih && r.OgledenOnceMi == model.OgledenOnceMi);

                if (kisitVarMi != null)
                {
                     TempData["WarningMessage"] = "Bu tarih ve saat için kısıt zaten mevcut.";
                     return RedirectToAction("RandevuKisitla");
                }
                else
                {

                    _randevuKisitService.RandevuKisitEkle(model);

                    TempData["SuccessMessage"] = "Randevu saatleri başarıyla kısıtlandı.";
                    return RedirectToAction("RandevuKisitla");

                }


            }
            else
            {
                ModelState.AddModelError("OgledenOnceMi", "Lütfen geçerli bir zaman dilimi seçiniz.");
            }

            return View("RandevuKisitla");
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

