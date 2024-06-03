using Microsoft.AspNetCore.Mvc;
using ProjectVet.Dtos;
using ProjectVet.Interfaces;

namespace ProjectVet.Controllers
{
    public class KullaniciController : Controller
    {

        private readonly IKullaniciService _kullaniciService;
        private readonly ILogger<KullaniciController> _logger;

        public KullaniciController(
            ILogger<KullaniciController> logger,
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

        [HttpGet]
        public IActionResult SignIn2()
        {
            return View();
            //var model = new EkleGuncelleKullaniciDto();
            //return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn2(EkleGuncelleKullaniciDto model)
        {

            if (!ModelState.IsValid)
            {
                // ModelState geçerli değilse, hata mesajlarıyla birlikte view'i tekrar göster
                return View("~/Views/Home/SignIn2.cshtml", model);

            }
            try
            {

                _kullaniciService.KullaniciEkle(model);
                return RedirectToAction("Login", "Admin" ,new { area = "Admin" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Kelime eklenirken bir hata oluştu: {ex.Message}");
                return View("~/Views/Home/SignIn2.cshtml", model);
            }
        }

    }
}
