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
    public class GrundbuchamtsController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public GrundbuchamtsController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Grundbuchamts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grundbuchamt>>> Getgrundbuchamts()
        {
            return await _context.grundbuchamts.ToListAsync();
        }

        // GET: api/Grundbuchamts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grundbuchamt>> GetGrundbuchamt(int id)
        {
            var grundbuchamt = await _context.grundbuchamts.FindAsync(id);

            if (grundbuchamt == null)
            {
                return NotFound();
            }

            return grundbuchamt;
        }

        // PUT: api/Grundbuchamts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrundbuchamt(int id, Grundbuchamt grundbuchamt)
        {
            if (id != grundbuchamt.beteiligteId)
            {
                return BadRequest();
            }

            _context.Entry(grundbuchamt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrundbuchamtExists(id))
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

        // POST: api/Grundbuchamts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Grundbuchamt>> PostGrundbuchamt(Grundbuchamt grundbuchamt)
        {
            _context.grundbuchamts.Add(grundbuchamt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrundbuchamt", new { id = grundbuchamt.beteiligteId }, grundbuchamt);
        }

        // DELETE: api/Grundbuchamts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grundbuchamt>> DeleteGrundbuchamt(int id)
        {
            var grundbuchamt = await _context.grundbuchamts.FindAsync(id);
            if (grundbuchamt == null)
            {
                return NotFound();
            }

            _context.grundbuchamts.Remove(grundbuchamt);
            await _context.SaveChangesAsync();

            return grundbuchamt;
        }

        private bool GrundbuchamtExists(int id)
        {
            return _context.grundbuchamts.Any(e => e.beteiligteId == id);
        }
    }
}
