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

        [HttpGet]
        public IActionResult Appointment()
        {

            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                // Log the issue and redirect to login
                Console.WriteLine("UserId is null or empty, redirecting to login.");
                return RedirectToAction("Login", "Admin", new { area = "Admin" });
            }

            var kullaniciId = Guid.Parse(userId);
            var pets = _randevuService.GetKullaniciPets(kullaniciId);

            if (pets == null || !pets.Any())
            {
                // Log if no pets are found for the user
                Console.WriteLine("No pets found for the user.");
            }

            var model = new AppointmentViewModel
            {
                Randevu = new Randevu(),
                Pets = pets.Select(p => new Pet
                {
                    Id = p.Id,
                    KullaniciId=p.KullaniciId,
                    Tur = p.Tur,
                    Cins = p.Cins,
                }).ToList()
            };

            return View(model);
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

        [HttpGet]
        public IActionResult CheckAvailability(DateTime date)
        {
            var unavailableTimes = _randevuService.GetUnavailableTimes(date);

            return Ok(new { unavailableTimes });
        }
    }
}
