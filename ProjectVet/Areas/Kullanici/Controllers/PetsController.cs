using ProjectVet.Areas.Kullanici.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectVet.EfCore;
using ProjectVet.Models;
using System;

namespace ProjectVet.Areas.Kullanici.Controllers
{
    [Area("Kullanici")]
    public class PetsController : Controller
    {
        private readonly KlinikContext _context;
        private readonly AddPetsService _addPetsService;

        public PetsController(KlinikContext context, AddPetsService addPetsService)
        {
            _context = context;
            _addPetsService = addPetsService;
        }

        [HttpPost]
        public IActionResult AddPets(string petType, string petBreed, int petAge)
        {
            _addPetsService.AddPets(petType, petBreed, petAge);
            return RedirectToAction("AddPets", "Kullanici", new { area = "Kullanici" });
        }
    }
}
