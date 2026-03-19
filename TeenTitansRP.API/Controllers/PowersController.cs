using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TeenTitansRP.API.Services;

namespace TeenTitansRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowersController : ControllerBase
    {
        private readonly TeenTitansContext _context;
        private readonly TeamBuilder _teamBuilder;

        public PowersController(TeenTitansContext context)
        {
            _context = context;
            _teamBuilder = new TeamBuilder();
        }

        [HttpPost("InitializeBasePowers")]
        public IActionResult InitializeBasePowers()
        {
            foreach (var power in _teamBuilder.powers)
            {
                if (!_context.Powers.Any(p => p.PowerType == power.PowerType))
                {
                    _context.Powers.Add(power);
                }
            }

            _context.SaveChanges();

            return Ok(_teamBuilder.powers);
        }

        [HttpGet("GetPowers")]
        public IActionResult GetPowers()
        {
            var powers = _context.Powers.ToList();
            return Ok(powers);
        }

        [HttpPost("AddPowers")]
        public async Task<IActionResult> AddPowers(Power power)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (_context.Powers.Any(x => x.PowerType == power.PowerType)) { return BadRequest("This power already exists!"); }

            _context.Powers.Add(power);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeletePowers")]
        public async Task<IActionResult> DeletePowers(string name)
        {
            _context.Powers.Remove(_context.Powers.First(x => x.PowerType == name));
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}


