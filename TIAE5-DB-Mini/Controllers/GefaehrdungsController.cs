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
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Gefaehrdung>>> GET_ALL()
        {
            return await _context.gefaehrdungs.ToListAsync();
        }

        // GET: api/Gefaehrdungs/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Gefaehrdung>> GET_ONE(int id)
        {
            var gefaehrdung = await _context.gefaehrdungs.FindAsync(id);

            if (gefaehrdung == null)
            {
                return NotFound();
            }

            return gefaehrdung;
        }

        // POST: api/Gefaehrdungs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ActionName("POST")]
        public async Task<ActionResult<Gefaehrdung>> POST(Gefaehrdung gefaehrdung)
        {
            _context.gefaehrdungs.Add(gefaehrdung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = gefaehrdung.gefaehrdungId }, gefaehrdung);
        }

        // DELETE: api/Gefaehrdungs/5
        [HttpDelete("{id}")]
        [ActionName("DELETE")]
        public async Task<ActionResult<Gefaehrdung>> DELETE(int id)
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
