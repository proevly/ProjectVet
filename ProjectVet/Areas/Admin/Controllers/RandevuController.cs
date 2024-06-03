using Microsoft.AspNetCore.Mvc;
using ProjectVet.Areas.Admin.Handlers;
using System;
using System.Threading.Tasks;
using static ProjectVet.Areas.Admin.Handlers.Commands;
using static ProjectVet.Areas.Admin.Handlers.Queries;

namespace ProjectVet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RandevuController : Controller
    {
        private readonly RandevuCommandHandler _commandHandler;
        private readonly RandevuQueryHandler _queryHandler;

        public RandevuController(RandevuCommandHandler commandHandler, RandevuQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Onayla(Guid id)
        {
            var command = new OnaylaRandevuCommand { Id = id };
            var result = await _commandHandler.Handle(command);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Reddet(Guid id)
        {
            var command = new ReddetRandevuCommand { Id = id };
            var result = await _commandHandler.Handle(command);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
