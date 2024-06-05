using Microsoft.AspNetCore.Mvc;
using ProjectVet.Areas.Admin.Handlers;
using ProjectVet.Areas.Admin.Services;
using System;
using System.Threading.Tasks;
using static ProjectVet.Areas.Admin.Handlers.Commands;

namespace ProjectVet.Areas.Admin.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuService _randevuService;
            public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        [HttpPost]
        public async Task<IActionResult> Onayla(Guid id)
        {
            var result = await _randevuService.OnaylaRandevu(id);
            if (!result)
                return NotFound();

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Reddet(Guid id)
        {
            var result = await _randevuService.ReddetRandevu(id);
            if (!result)
                return NotFound();

            return Ok();
        }

    }
}
