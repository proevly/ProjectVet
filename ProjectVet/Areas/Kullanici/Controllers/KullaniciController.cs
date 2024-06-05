using Microsoft.AspNetCore.Mvc;
using ProjectVet.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectVet.Models;
using ProjectVet.Interfaces;
using ProjectVet.Application.ViewModels;
using ProjectVet.Areas.Kullanici.Dtos;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace ProjectVet.Areas.Kullanici.Controllers
{
    [Area("Kullanici")]
    public class KullaniciController : Controller
    {
        private readonly KlinikContext _context;
        private readonly IKullaniciService _kullaniciService;
        private readonly IKullaniciRandevuService _randevuService;

        public KullaniciController(KlinikContext context, IKullaniciService kullaniciService, IKullaniciRandevuService randevuService)
        {
            _context = context;
            _kullaniciService = kullaniciService;
            _randevuService = randevuService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPets()
        {
            return View();
        }

        public IActionResult Randevularim()
        {
            // Oturumdan kullanıcı ID'sini al
            var userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString == null)
            {
                // Kullanıcı oturumu yoksa, giriş yapma sayfasına yönlendir
                return RedirectToAction("Login", "Admin", new { area = "Admin" });
            }
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                // Kullanıcı ID'si geçerli değilse veya oturumda yoksa, hata döndür
                return RedirectToAction("Login", "Admin", new { area = "Admin" });
            }

            var randevular = _context.Randevular
                .Where(r => r.Kullanici.KullaniciId == userId) // Kullanıcı ID'sine göre filtreleme
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


        [HttpGet]
        public IActionResult Appointment()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString == null)
            {
                // Kullanıcı oturumu yoksa, giriş yapma sayfasına yönlendir
                return RedirectToAction("Login", "Admin", new { area = "Admin" });
            }

            // Kullanıcı kimliğini Guid türüne dönüştür
            if (!Guid.TryParse(userIdString, out Guid userId))
            {

                return RedirectToAction("Error", "Home");
            }

            // Kullanıcının oturumu varsa, kullanıcının petlerini al
            var userPets = _randevuService.GetKullaniciPets(userId);
            if (userPets == null)
            {
                return RedirectToAction("Error", "Home");
            }

            // Kullanıcının petleri varsa, AppointmentViewModel'e petlerinizi atayın
            var viewModel = new AppointmentViewModel
            {
                Pets = userPets
            };

            // Randevu oluşturma sayfasını göster
            return View(viewModel);
        }




        [HttpPost]
        public IActionResult Appointment(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                if (!string.IsNullOrEmpty(userId))
                {
                    var result = _randevuService.RandevuEkle(model.Randevu);
                    return Json(result);

                }
                return BadRequest(); // Örneğin, BadRequest (HTTP 400) durumu döndürülebilir
            }
            return Ok(); // Örneğin, OK (HTTP 200) durumu döndürülebilir


        }


        [HttpGet]
        [Route("api/check-availability")]
        public IActionResult CheckAvailability(DateTime date)
        {
            var kisit = _context.RandevuKisitlar.FirstOrDefault(k => k.Tarih == date);
            var unavailableTimes = new List<string>();

            if (kisit != null)
            {
                if (kisit.OgledenOnceMi)
                {
                    for (int i = 9; i < 13; i++)
                    {
                        unavailableTimes.Add(i.ToString("D2") + ":00");
                        unavailableTimes.Add(i.ToString("D2") + ":30");
                    }
                }
                else
                {
                    for (int i = 14; i <= 17; i++)
                    {
                        unavailableTimes.Add(i.ToString("D2") + ":00");
                        unavailableTimes.Add(i.ToString("D2") + ":30");
                    }
                }
                // 12:00, 12:30 ve 13:00 saatlerini her durumda eklenmeyecek şekilde manuel olarak ekliyoruz
                unavailableTimes.Add("13:00");
                unavailableTimes.Add("13:30");
            }

            return Ok(new { unavailableTimes });
        }




        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Veritabanı üzerinden kullanıcı doğrulaması
                var kullanici = _kullaniciService.Authenticate(username, password);
                if (kullanici != null)
                {
                    // Giriş başarılı, Kullanici alanına yönlendirme
                    return RedirectToAction("Index", "Kullanici", new { area = "Kullanici" });
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
