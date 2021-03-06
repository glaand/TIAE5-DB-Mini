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
    public class GefaehrdungsController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public GefaehrdungsController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Gefaehrdungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gefaehrdung>>> Getgefaehrdungs()
        {
            return await _context.gefaehrdungs.ToListAsync();
        }

        // GET: api/Gefaehrdungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gefaehrdung>> GetGefaehrdung(int id)
        {
            var gefaehrdung = await _context.gefaehrdungs.FindAsync(id);

            if (gefaehrdung == null)
            {
                return NotFound();
            }

            return gefaehrdung;
        }

        // PUT: api/Gefaehrdungs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGefaehrdung(int id, Gefaehrdung gefaehrdung)
        {
            if (id != gefaehrdung.gefaehrdungId)
            {
                return BadRequest();
            }

            _context.Entry(gefaehrdung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GefaehrdungExists(id))
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

        // POST: api/Gefaehrdungs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gefaehrdung>> PostGefaehrdung(Gefaehrdung gefaehrdung)
        {
            _context.gefaehrdungs.Add(gefaehrdung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGefaehrdung", new { id = gefaehrdung.gefaehrdungId }, gefaehrdung);
        }

        // DELETE: api/Gefaehrdungs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gefaehrdung>> DeleteGefaehrdung(int id)
        {
            var gefaehrdung = await _context.gefaehrdungs.FindAsync(id);
            if (gefaehrdung == null)
            {
                return NotFound();
            }

            _context.gefaehrdungs.Remove(gefaehrdung);
            await _context.SaveChangesAsync();

            return gefaehrdung;
        }

        private bool GefaehrdungExists(int id)
        {
            return _context.gefaehrdungs.Any(e => e.gefaehrdungId == id);
        }
    }
}
