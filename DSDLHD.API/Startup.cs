using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPDT.DependencyInjection;
using VPDT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace VPDT.API
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
            services.AddDbContext<VPDTDbContext>(opt => opt.UseOracle(Configuration.GetConnectionString("connectDb")));
            IOCConfig.Register(services, Configuration);
            services.AddControllers();
           
            //services.AddDbContext<VPDTDbContext>(options =>
            //        options.UseOracle(Configuration.GetConnectionString("connectDb"),
            //        sqlServerOptionsAction: sqlOptions =>
            //        {
            //            sqlOptions.EnableRetryOnFailure(
            //            maxRetryCount: 1000,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null)
            //            .CommandTimeout(30).UseRowNumberForPaging();
            //        }), ServiceLifetime.Transient);
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
