using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prestamos.Infrastructure.BackgroundServices;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Implementations;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamos.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PrestamosDBContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(PrestamosDBContext).Assembly.FullName)
            ));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*services.AddHostedService(serviceProvider =>
            new BackgroundServiceCliente(
            serviceProvider.GetRequiredService<IUnitOfWork>()));*/
        }
    }
}
