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
    public class ObjektsController : ControllerBase
    {
        private readonly CaseStudyContext _context;

        public ObjektsController(CaseStudyContext context)
        {
            _context = context;
        }

        // GET: api/Objekts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objekt>>> Getobjekts()
        {
            return await _context.objekts.Include(t => t.gefaehrdungs).ToListAsync();
        }

        // GET: api/Objekts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objekt>> GetObjekt(int id)
        {
            var objekt = await _context.objekts.Include(t => t.gefaehrdungs).FirstOrDefaultAsync(i => i.objektId == id);

            if (objekt == null)
            {
                return NotFound();
            }

            return objekt;
        }

        // PUT: api/Objekts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjekt(int id, Objekt objekt)
        {
            if (id != objekt.objektId)
            {
                return BadRequest();
            }

            _context.Entry(objekt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjektExists(id))
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

        // POST: api/Objekts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Objekt>> PostObjekt(Objekt objekt)
        {
            _context.objekts.Add(objekt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjekt", new { id = objekt.objektId }, objekt);
        }

        // DELETE: api/Objekts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objekt>> DeleteObjekt(int id)
        {
            var objekt = await _context.objekts.FindAsync(id);
            if (objekt == null)
            {
                return NotFound();
            }

            _context.objekts.Remove(objekt);
            await _context.SaveChangesAsync();

            return objekt;
        }

        private bool ObjektExists(int id)
        {
            return _context.objekts.Any(e => e.objektId == id);
        }
    }
}
