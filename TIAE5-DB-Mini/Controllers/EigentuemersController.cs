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
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Eigentuemer>>> GET_ALL()
        {
            return await _context.eigentuemers.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).ToListAsync();
        }

        // GET: api/Eigentuemers/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Eigentuemer>> GET_ONE(int id)
        {
            var eigentuemer = await _context.eigentuemers.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).FirstOrDefaultAsync(i => i.beteiligteId == id);

            if (eigentuemer == null)
            {
                return NotFound();
            }

            return eigentuemer;
        }

        // POST: api/Eigentuemers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ActionName("POST")]
        public async Task<ActionResult<Eigentuemer>> POST(Eigentuemer eigentuemer)
        {
            List<Objekt> listOfObjets = new List<Objekt>();

            if (eigentuemer.objekts != null)
            {
                foreach (Objekt temp in eigentuemer.objekts)
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

            eigentuemer.objekts = listOfObjets;

            _context.eigentuemers.Add(eigentuemer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = eigentuemer.beteiligteId }, eigentuemer);
        }
    }
}
