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
    public class TeamsController : ControllerBase
    {
        private readonly TeenTitansContext _context;
        private readonly TeamBuilder _teamBuilder;

        public TeamsController(TeenTitansContext context)
        {
            _context = context;
            _teamBuilder = new TeamBuilder();
        }

        [HttpPost("InitializeBaseTeams")]
        public IActionResult InitializeBaseTeams()
        {
            foreach (var team in _teamBuilder.teams)
            {
                if (!_context.Teams.Any(t => t.TeamName == team.TeamName))
                {
                    _context.Teams.Add(team);
                }
            }

            _context.SaveChanges();

            return Ok(_teamBuilder.teams);
        }

        [HttpGet("GetTeams")]
        public IActionResult GetTeams()
        {
            var teams = _context.Teams.ToList();
            return Ok(teams);
        }

        [HttpPost("AddTeams")]
        public async Task<IActionResult> AddTeams(Team team)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (_context.Teams.Any(x => x.TeamName == team.TeamName)) { return BadRequest("This team already exists!"); }

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteTeams")]
        public async Task<IActionResult> DeleteTeams(string name)
        {
            _context.Teams.Remove(_context.Teams.First(x => x.TeamName == name));
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}