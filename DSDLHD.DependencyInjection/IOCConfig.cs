using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VPDT.Models;
using VPDT.Repository;
using VPDT.Data;
using System.Collections.Generic;
using System.Text;
using VPDT.Manager;
using Microsoft.AspNetCore.Http;

namespace VPDT.DependencyInjection
{
    public class IOCConfig
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddDbContext<VPDTDbContext>(ServiceLifetime.Scoped, ServiceLifetime.Singleton);
            services.AddTransient<IDbContextFactory<VPDTDbContext>, VPDTDbContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<INHACUNGCAPManager, NHACUNGCAPManager>();
            
            
        }
    }
}
