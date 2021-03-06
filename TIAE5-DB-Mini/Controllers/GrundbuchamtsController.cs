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
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Grundbuchamt>>> GET_ALL()
        {
            return await _context.grundbuchamts.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).ToListAsync();
        }

        // GET: api/Grundbuchamts/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Grundbuchamt>> GET_ONE(int id)
        {
            var grundbuchamt = await _context.grundbuchamts.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).FirstOrDefaultAsync(i => i.beteiligteId == id);

            if (grundbuchamt == null)
            {
                return NotFound();
            }

            return grundbuchamt;
        }

        // POST: api/Grundbuchamts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ActionName("POST")]
        public async Task<ActionResult<Grundbuchamt>> POST(Grundbuchamt grundbuchamt)
        {

            List<Objekt> listOfObjets = new List<Objekt>();

            if (grundbuchamt.objekts != null)
            {
                foreach (Objekt temp in grundbuchamt.objekts)
                {
                    Objekt found = await this._context.objekts.FindAsync(temp.objektId);
                    if (found != null)
                    {
                        listOfObjets.Add(found);
                    }
                    else
                    {
                        throw new Exception("Objekt existiert nicht. Bitte Objekt zuerst erstellen.");
                    }
                }
            }

            grundbuchamt.objekts = listOfObjets;

            _context.grundbuchamts.Add(grundbuchamt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = grundbuchamt.beteiligteId }, grundbuchamt);
        }
    }
}
