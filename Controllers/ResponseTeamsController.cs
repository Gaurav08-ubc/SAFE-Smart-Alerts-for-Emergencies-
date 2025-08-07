using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAFE.Models;

namespace SAFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseTeamsController : ControllerBase
    {
        private readonly SafeContext _context;

        public ResponseTeamsController(SafeContext context)
        {
            _context = context;
        }

        // GET: api/ResponseTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTeam>>> GetResponseTeams()
        {
            return await _context.ResponseTeams.ToListAsync();
        }

        // GET: api/ResponseTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseTeam>> GetResponseTeam(int id)
        {
            var responseTeam = await _context.ResponseTeams.FindAsync(id);

            if (responseTeam == null)
            {
                return NotFound();
            }

            return responseTeam;
        }

        // PUT: api/ResponseTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponseTeam(int id, ResponseTeam responseTeam)
        {
            if (id != responseTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(responseTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseTeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ResponseTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseTeam>> PostResponseTeam(ResponseTeam responseTeam)
        {
            _context.ResponseTeams.Add(responseTeam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResponseTeamExists(responseTeam.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResponseTeam", new { id = responseTeam.Id }, responseTeam);
        }

        // DELETE: api/ResponseTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponseTeam(int id)
        {
            var responseTeam = await _context.ResponseTeams.FindAsync(id);
            if (responseTeam == null)
            {
                return NotFound();
            }

            _context.ResponseTeams.Remove(responseTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponseTeamExists(int id)
        {
            return _context.ResponseTeams.Any(e => e.Id == id);
        }
    }
}
