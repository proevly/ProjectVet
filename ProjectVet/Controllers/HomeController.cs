using Microsoft.AspNetCore.Mvc;
using ProjectVet.Dtos;
using ProjectVet.Models;
using ProjectVet.Services;
using System.Diagnostics;

namespace ProjectVet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            IKullaniciService kullaniciService
        )
        {
            _logger = logger;
            _kullaniciService = kullaniciService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult SignIn2()
        //{
        //     return View();
        //    //var model = new EkleGuncelleKullaniciDto();
        //    //return View(model);
        //}

        public IActionResult SignIn2()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignIn2(EkleGuncelleKullaniciDto model)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        // ModelState geçerli değilse, hata mesajlarıyla birlikte view'i tekrar göster
        //        return View(model);
        //    }
        //    try
        //    {

        //        _kullaniciService.KullaniciEkle(model);
        //        return RedirectToAction("SignIn2", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, $"Kelime eklenirken bir hata oluştu: {ex.Message}");
        //        return View(model);
        //    }
        //}



        public IActionResult Appointment()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}