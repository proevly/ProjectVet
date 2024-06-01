using Microsoft.AspNetCore.Mvc;
using ProjectVet.EfCore;
using Microsoft.EntityFrameworkCore;
using ProjectVet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectVet.Models;

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

        public IActionResult Appointment()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Appointment(Randevu randevu)
        {
            _randevuService.RandevuEkle(randevu);
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
                ViewBag.Error = "Hatalı kullanıcı adı veya şifre";
                return View();
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
