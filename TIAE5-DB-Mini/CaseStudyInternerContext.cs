using Microsoft.EntityFrameworkCore;

namespace TIAE5_DB_Mini.Models
{
    public class CaseStudyInternerContext : CaseStudyGenericContext {
        public CaseStudyInternerContext(DbContextOptions<CaseStudyInternerContext> options) : base(options) { }
    }
}
