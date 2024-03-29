﻿using System;
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
    public class BeteiligtesController : CaseStudyController {

        public BeteiligtesController(CaseStudyExternerContext externalCtx, CaseStudyInternerContext internalCtx) : base(externalCtx, internalCtx)
        {
        }

        // GET: api/Beteiligtes
        [HttpGet]
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Beteiligte>>> GET_All()
        {
            return await GetContext().beteiligtes.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).ToListAsync();
        }

        // GET: api/Beteiligtes/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Beteiligte>> GET_ONE(int id)
        {
            var beteiligte = await GetContext().beteiligtes.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).FirstOrDefaultAsync(i => i.beteiligteId == id);

            if (beteiligte == null)
            {
                return NotFound();
            }

            return beteiligte;
        }

        // POST: api/Beteiligtes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ActionName("POST")]
        public async Task<ActionResult<Beteiligte>> POST(Beteiligte model)
        {
            List<Objekt> listOfObjets = new List<Objekt>();

            if (model.objekts != null)
            {
                foreach (Objekt temp in model.objekts)
                {
                    Objekt found = await this.GetContext().objekts.FindAsync(temp.objektId);
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

            model.objekts = listOfObjets;

            GetContext().beteiligtes.Add(model);
            await GetContext().SaveChangesAsync();

            return CreatedAtAction("GET_ONE", new { id = model.beteiligteId }, model);
        }

        // PUT: api/Beteiligtes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ActionName("PUT")]
        public async Task<IActionResult> PUT(int id, Beteiligte beteiligte)
        {
            if (id != beteiligte.beteiligteId)
            {
                return BadRequest();
            }

            List<Objekt> listOfObjets = new List<Objekt>();

            if (beteiligte.objekts != null)
            {
                foreach (Objekt temp in beteiligte.objekts)
                {
                    Objekt found = await this.GetContext().objekts.FindAsync(temp.objektId);
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

            beteiligte.objekts = listOfObjets;

            GetContext().Entry(beteiligte).State = EntityState.Modified;

            try
            {
                await GetContext().SaveChangesAsync();
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

        private bool BeteiligteExists(int id)
        {
            return GetContext().beteiligtes.Any(e => e.beteiligteId == id);
        }
    }
}
