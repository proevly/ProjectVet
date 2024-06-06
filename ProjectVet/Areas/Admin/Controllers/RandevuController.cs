using Microsoft.AspNetCore.Mvc;
using ProjectVet.Areas.Admin.Handlers;
using ProjectVet.Areas.Admin.Services;
using ProjectVet.Interfaces;
using System;
using System.Threading.Tasks;
using static ProjectVet.Areas.Admin.Handlers.Commands;

namespace ProjectVet.Areas.Admin.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IProjectVetFacade _projectVetFacade;
            public RandevuController(IProjectVetFacade projectVetFacade)
        {
            _projectVetFacade = projectVetFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Onayla(Guid id)
        {
            var result = await _projectVetFacade.OnaylaRandevu(id);
            if (!result)
                return NotFound();

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Reddet(Guid id)
        {
            var result = await _projectVetFacade.ReddetRandevu(id);
            if (!result)
                return NotFound();

            return Ok();
        }

    }
}
