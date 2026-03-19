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
    public class CharactersController : ControllerBase
    {
        private readonly TeenTitansContext _context;
        private readonly TeamBuilder _teamBuilder;

        public CharactersController(TeenTitansContext context)
        {
            _context = context;
            _teamBuilder = new TeamBuilder();
        }

        [HttpPost("InitializeBaseCharacters")]
        public IActionResult InitializeBaseCharacters()
        {
            foreach (var character in _teamBuilder.characters)
            {
                if (!_context.Characters.Any(c => c.Alias == character.Alias))
                {
                    _context.Characters.Add(character);
                }
            }

            _context.SaveChanges();

            return Ok(_teamBuilder.characters);
        }

        [HttpGet("GetCharacters")]
        public IActionResult GetCharacters()
        {
            var characters = _context.Characters.ToList();
            return Ok(characters);
        }


        [HttpPost("AddCharacters")]
        public async Task<IActionResult> AddCharacters(Character character)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (_context.Characters.Any(x => x.Alias == character.Alias)) { return BadRequest("This character already exists!"); }

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteCharacters")]
        public async Task<IActionResult> DeleteCharacters(string name)
        {
            _context.Characters.Remove(_context.Characters.First(x => x.Alias == name));
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

          