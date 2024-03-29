using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TIAE5_DB_Mini.Models;
namespace TIAE5_DB_Mini
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Context for administrative operations
            services.AddDbContext<CaseStudyContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:CaseStudy"]));
            
            // Context for external people accessing
            services.AddDbContext<CaseStudyExternerContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:CaseStudyExterner"]));
            
            // Context for internal people (employees) accessing
            services.AddDbContext<CaseStudyInternerContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:CaseStudyInterner"]));
            
            // Add all controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
