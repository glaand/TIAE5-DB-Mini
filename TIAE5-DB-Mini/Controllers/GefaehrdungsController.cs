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
    public class GefaehrdungsController : CaseStudyController {
        public GefaehrdungsController(CaseStudyExternerContext externalCtx, CaseStudyInternerContext internalCtx) : base(externalCtx, internalCtx)
        {

        }

        // GET: api/Gefaehrdungs
        [HttpGet]
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Gefaehrdung>>> GET_ALL()
        {
            return await GetContext().gefaehrdungs.ToListAsync();
        }

        // GET: api/Gefaehrdungs/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Gefaehrdung>> GET_ONE(int id)
        {
            var gefaehrdung = await GetContext().gefaehrdungs.FindAsync(id);

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
            GetContext().gefaehrdungs.Add(gefaehrdung);
            await GetContext().SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = gefaehrdung.gefaehrdungId }, gefaehrdung);
        }

        // DELETE: api/Gefaehrdungs/5
        [HttpDelete("{id}")]
        [ActionName("DELETE")]
        public async Task<ActionResult<Gefaehrdung>> DELETE(int id)
        {
            var gefaehrdung = await GetContext().gefaehrdungs.FindAsync(id);
            if (gefaehrdung == null)
            {
                return NotFound();
            }

            GetContext().gefaehrdungs.Remove(gefaehrdung);
            await GetContext().SaveChangesAsync();

            return gefaehrdung;
        }

        private bool GefaehrdungExists(int id)
        {
            return GetContext().gefaehrdungs.Any(e => e.gefaehrdungId == id);
        }
    }
}
