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
    public class BeteiligtesController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public BeteiligtesController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Beteiligtes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beteiligte>>> Getbeteiligtes()
        {
            return await _context.beteiligtes.ToListAsync();
        }

        // GET: api/Beteiligtes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beteiligte>> GetBeteiligte(int id)
        {
            var beteiligte = await _context.beteiligtes.FindAsync(id);

            if (beteiligte == null)
            {
                return NotFound();
            }

            return beteiligte;
        }

        // PUT: api/Beteiligtes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeteiligte(int id, Beteiligte beteiligte)
        {
            if (id != beteiligte.beteiligteId)
            {
                return BadRequest();
            }

            _context.Entry(beteiligte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeteiligteExists(id))
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

        // POST: api/Beteiligtes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Beteiligte>> PostBeteiligte(Beteiligte beteiligte)
        {
            _context.beteiligtes.Add(beteiligte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeteiligte", new { id = beteiligte.beteiligteId }, beteiligte);
        }

        // DELETE: api/Beteiligtes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Beteiligte>> DeleteBeteiligte(int id)
        {
            var beteiligte = await _context.beteiligtes.FindAsync(id);
            if (beteiligte == null)
            {
                return NotFound();
            }

            _context.beteiligtes.Remove(beteiligte);
            await _context.SaveChangesAsync();

            return beteiligte;
        }

        private bool BeteiligteExists(int id)
        {
            return _context.beteiligtes.Any(e => e.beteiligteId == id);
        }
    }
}
