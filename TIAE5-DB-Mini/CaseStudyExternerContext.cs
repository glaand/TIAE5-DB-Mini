using Microsoft.EntityFrameworkCore;

namespace TIAE5_DB_Mini.Models
{
    public class CaseStudyExternerContext : CaseStudyGenericContext {
        public CaseStudyExternerContext(DbContextOptions<CaseStudyExternerContext> options) : base(options) { }
    }
}
