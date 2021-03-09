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
    public class MitarbeitersController : CaseStudyController {
        public MitarbeitersController(CaseStudyExternerContext externalCtx, CaseStudyInternerContext internalCtx) : base(externalCtx, internalCtx)
        {

        }

        // GET: api/Mitarbeiters
        [HttpGet]
        [ActionName("GET_ALL")]
        public async Task<ActionResult<IEnumerable<Mitarbeiter>>> GET_ALL()
        {
            return await GetContext().mitarbeiters.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).ToListAsync();
        }

        // GET: api/Mitarbeiters/5
        [HttpGet("{id}")]
        [ActionName("GET_ONE")]
        public async Task<ActionResult<Mitarbeiter>> GET_ONE(int id)
        {
            var mitarbeiter = await GetContext().mitarbeiters.Include(o => o.objekts).ThenInclude(o2 => o2.gefaehrdungs).FirstOrDefaultAsync(i => i.beteiligteId == id);

            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return mitarbeiter;
        }
    }
}
