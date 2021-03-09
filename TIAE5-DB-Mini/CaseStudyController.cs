using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TIAE5_DB_Mini.Models;

namespace TIAE5_DB_Mini.Controllers {
    public class CaseStudyController : ControllerBase {

        private readonly CaseStudyExternerContext _contextExternal;
        private readonly CaseStudyInternerContext _contextInternal;

        public CaseStudyController(CaseStudyExternerContext externalCtx, CaseStudyInternerContext internalCtx)
        {
            this._contextExternal = externalCtx;
            this._contextInternal = internalCtx;
        }

        protected CaseStudyGenericContext GetContext()
        {
          return this._contextExternal;
        }
    }
}
