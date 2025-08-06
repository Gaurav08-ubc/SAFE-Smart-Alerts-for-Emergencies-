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
    public class EmergencyReportsController : ControllerBase
    {
        private readonly SafeContext _context;

        public EmergencyReportsController(SafeContext context)
        {
            _context = context;
        }

        // GET: api/EmergencyReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmergencyReport>>> GetEmergencyReports()
        {
            return await _context.EmergencyReports.ToListAsync();
        }

        // GET: api/EmergencyReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmergencyReport>> GetEmergencyReport(int id)
        {
            var emergencyReport = await _context.EmergencyReports.FindAsync(id);

            if (emergencyReport == null)
            {
                return NotFound();
            }

            return emergencyReport;
        }

        // PUT: api/EmergencyReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergencyReport(int id, EmergencyReport emergencyReport)
        {
            if (id != emergencyReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(emergencyReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyReportExists(id))
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

        // POST: api/EmergencyReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmergencyReport>> PostEmergencyReport(EmergencyReport emergencyReport)
        {
            _context.EmergencyReports.Add(emergencyReport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmergencyReportExists(emergencyReport.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmergencyReport", new { id = emergencyReport.Id }, emergencyReport);
        }

        // DELETE: api/EmergencyReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyReport(int id)
        {
            var emergencyReport = await _context.EmergencyReports.FindAsync(id);
            if (emergencyReport == null)
            {
                return NotFound();
            }

            _context.EmergencyReports.Remove(emergencyReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmergencyReportExists(int id)
        {
            return _context.EmergencyReports.Any(e => e.Id == id);
        }
    }
}
