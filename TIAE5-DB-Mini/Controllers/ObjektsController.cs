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
    public class ObjektsController : CaseStudyController {
        public ObjektsController(CaseStudyExternerContext externalCtx, CaseStudyInternerContext internalCtx) : base(externalCtx, internalCtx)
        {

        }

        // GET: api/Objekts
        [HttpGet]
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Objekt>>> GET_ALL()
        {
            return await GetContext().objekts.Include(t => t.gefaehrdungs).ToListAsync();
        }

        // GET: api/Objekts/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Objekt>> GET_ONE(int id)
        {
            var objekt = await GetContext().objekts.Include(t => t.gefaehrdungs).FirstOrDefaultAsync(i => i.objektId == id);

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
        [ActionName("PUT")]
        public async Task<IActionResult> PUT(int id, Objekt objekt)
        {
            if (id != objekt.objektId)
            {
                return BadRequest();
            }

            List<Gefaehrdung> listOfGefaehrdungs = new List<Gefaehrdung>();

            if (objekt.gefaehrdungs != null)
            {
                foreach (Gefaehrdung g in objekt.gefaehrdungs)
                {
                    Gefaehrdung found = await this.GetContext().gefaehrdungs.FindAsync(g.gefaehrdungId);
                    if (found != null)
                    {
                        listOfGefaehrdungs.Add(found);
                    }
                    else
                    {
                        throw new Exception("Gefährdung existiert nicht. Bitte Gefährdung zuerst erstellen.");
                    }
                }
                objekt.gefaehrdungs = listOfGefaehrdungs;
            }

            GetContext().Entry(objekt).State = EntityState.Modified;

            try
            {
                await GetContext().SaveChangesAsync();
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
        [ActionName("POST")]
        public async Task<ActionResult<Objekt>> POST(Objekt objekt)
        {
            List<Gefaehrdung> listOfGefaehrdungs = new List<Gefaehrdung>();

            if (objekt.gefaehrdungs != null)
            {
                foreach (Gefaehrdung g in objekt.gefaehrdungs)
                {
                    Gefaehrdung found = await this.GetContext().gefaehrdungs.FindAsync(g.gefaehrdungId);
                    if (found != null)
                    {
                        listOfGefaehrdungs.Add(found);
                    }
                    else
                    {
                        throw new Exception("Gefährdung existiert nicht. Bitte Gefährdung zuerst erstellen.");
                    }
                }
            }

            objekt.gefaehrdungs = listOfGefaehrdungs;

            GetContext().objekts.Add(objekt);
            await GetContext().SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = objekt.objektId }, objekt);
        }

        private bool ObjektExists(int id)
        {
            return GetContext().objekts.Any(e => e.objektId == id);
        }
    }
}
