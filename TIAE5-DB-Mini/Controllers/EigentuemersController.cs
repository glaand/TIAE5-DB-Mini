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
    public class EigentuemersController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public EigentuemersController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Eigentuemers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eigentuemer>>> Geteigentuemers()
        {
            return await _context.eigentuemers.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).ToListAsync();
        }

        // GET: api/Eigentuemers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eigentuemer>> GetEigentuemer(int id)
        {
            var eigentuemer = await _context.eigentuemers.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).FirstOrDefaultAsync(i => i.eigentuemerId == id);

            if (eigentuemer == null)
            {
                return NotFound();
            }

            return eigentuemer;
        }

        // PUT: api/Eigentuemers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEigentuemer(int id, Eigentuemer eigentuemer)
        {
            if (id != eigentuemer.beteiligteId)
            {
                return BadRequest();
            }

            _context.Entry(eigentuemer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EigentuemerExists(id))
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

        // POST: api/Eigentuemers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Eigentuemer>> PostEigentuemer(Eigentuemer eigentuemer)
        {
            _context.eigentuemers.Add(eigentuemer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEigentuemer", new { id = eigentuemer.beteiligteId }, eigentuemer);
        }

        // DELETE: api/Eigentuemers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eigentuemer>> DeleteEigentuemer(int id)
        {
            var eigentuemer = await _context.eigentuemers.FindAsync(id);
            if (eigentuemer == null)
            {
                return NotFound();
            }

            _context.eigentuemers.Remove(eigentuemer);
            await _context.SaveChangesAsync();

            return eigentuemer;
        }

        private bool EigentuemerExists(int id)
        {
            return _context.eigentuemers.Any(e => e.beteiligteId == id);
        }
    }
}
