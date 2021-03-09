using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            string authorization = Request.Headers["Authorization"];
            try
            {
               string authInfo = this.decodeHeader(authorization.Replace("Basic ", ""));

               // TODO: This should be rewritten into an implementation, where the auth information
               // is stored in the application environment, not pushed to version control and is
               // not the same as the database credentials. For the sake of this demonstration,
               // security is not a concern.
               if (authInfo == "interner:password") return this._contextInternal;
               if (authInfo == "externer:password") return this._contextExternal;
            } catch {}

            return this._contextExternal;
        }

        private string decodeHeader(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
