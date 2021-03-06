using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TIAE5_DB_Mini.Models;

namespace TIAE5_DB_Mini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MitarbeitersController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public MitarbeitersController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Mitarbeiters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mitarbeiter>>> Getmitarbeiters()
        {
            return await _context.mitarbeiters.ToListAsync();
        }

        // GET: api/Mitarbeiters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mitarbeiter>> GetMitarbeiter(int id)
        {
            var mitarbeiter = await _context.mitarbeiters.FindAsync(id);

            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return mitarbeiter;
        }

        // PUT: api/Mitarbeiters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMitarbeiter(int id, Mitarbeiter mitarbeiter)
        {
            if (id != mitarbeiter.beteiligteId)
            {
                return BadRequest();
            }

            _context.Entry(mitarbeiter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MitarbeiterExists(id))
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

        // POST: api/Mitarbeiters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mitarbeiter>> PostMitarbeiter(Mitarbeiter mitarbeiter)
        {
            _context.mitarbeiters.Add(mitarbeiter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMitarbeiter", new { id = mitarbeiter.beteiligteId }, mitarbeiter);
        }

        // DELETE: api/Mitarbeiters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mitarbeiter>> DeleteMitarbeiter(int id)
        {
            var mitarbeiter = await _context.mitarbeiters.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            _context.mitarbeiters.Remove(mitarbeiter);
            await _context.SaveChangesAsync();

            return mitarbeiter;
        }

        private bool MitarbeiterExists(int id)
        {
            return _context.mitarbeiters.Any(e => e.beteiligteId == id);
        }
    }
}
